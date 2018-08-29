using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using RedTheSettlers.Tiles;
using RedTheSettlers.UnitTest;
using RedTheSettlers.UI;
using RedTheSettlers.Users;
using RedTheSettlers.Players;

namespace RedTheSettlers.GameSystem
{
    public delegate void FlowFinishCallback();

    /// <summary>
    /// 각 컨트롤러를 관리하고 중재하는 매니저
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        public User[] Players;
        public GameData gameData = DataManager.Instance.GameData;

        public TurnControllerTest turnCtrl;
        public EventChecker eventCtrl;
        public ItemDistributor itemCtrl;
        public TradeController tradeCtrl;
        public BattleControllerTest2 battleCtrl;
        public CameraController cameraCtrl;
        public DifficultyController difficultyController;
        public BattlePlayer battlePlayer;

        public GameState state = GameState.EventController;
        private Coroutine coroutineMove;
        private Coroutine coroutineAttack;

        private ItemType tileType;
        public ItemType TileType
        {
            get { return TileType; }
            set { tileType = value; }
        }

        private void Start()
        {
            turnCtrl.Callback = new FlowFinishCallback(GameFlowFinish);
            eventCtrl.Callback = new FlowFinishCallback(GameFlowFinish);;
            itemCtrl.Callback = new FlowFinishCallback(GameFlowFinish);
            //tradeCtrl.Callback = new TradeCallback(TradeFinish);
            battleCtrl.Callback = new BattleFinishCallback(BattleFinish);
            difficultyController.Callback = new BuildBattleTileCallback(BulidBattleStageFinish);
            cameraCtrl = new CameraController();
        }

        public void StartGameFlow()
        {
            ChangeGameFlow();
            switch (state)
            {
                case GameState.EventController:
                    eventCtrl.EventFlow();
                    break;
                case GameState.ItemController:
                    itemCtrl.ItemFlow();
                    break;
                default:
                    turnCtrl.TurnFlow(state);
                    break;
            }
        }

        public void GameFlowFinish()
        {
            StartGameFlow();
            switch (state)
            {
                case GameState.EventController:
                    break;
                case GameState.ItemController:
                    UIManager.Instance.ShowBoardUI();
                    break;
                default:
                    break;
            }
        }

        private void BulidBattleStageFinish()
        {
            //전투 시작 전 세팅
            battleCtrl.AliveEnemyCount = difficultyController.GetEnemyCount();
            ChangeGameFlow();
        }

        private void BattleFinish()
        {
            //전투 끝(메인으로 돌아가야 함)   
            ChangeGameFlow();
        }

        private void ChangeGameFlow()
        {
            if (state == GameState.AI3Turn)
            {
                state = GameState.EventController;
            }
            else
                state++;
        }

        /// <summary>
        /// 플레이어가 보유한 자원량의 합을 반환합니다.
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public int GetPlayerItemCountAll(UserType userType)
        {
            int countSum = 0;
            for (int i = 0; i < GlobalVariables.MaxItemNumber; i++)
            {
                countSum += Players[(int)userType].inventory[i].Count;
            }
            return countSum;
        }

        /// <summary>
        /// 플레이어가 보유한 특정 자원의 개수를 반환합니다.
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public int GetPlayerItemCount(UserType userType, ItemType itemType)
        {
            return Players[(int)userType].inventory[(int)itemType].Count;
        }

        /// <summary>
        /// 플레이어가 보유한 모든 타일의 개수를 반환합니다.
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public int GetPlayerTileCountAll(UserType userType)
        {
            return Players[(int)userType].PossessingTile.Count;
        }

        /// <summary>
        /// 플레이어가 보유한 특정 자원 타일의 개수를 반환합니다.
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="tiletype"></param>
        /// <returns></returns>
        public int GetPlayerTileCount(UserType userType, ItemType itemType)
        {
            int tileTileCount = 0;
            for (int i = 0; i < GetPlayerTileCountAll(userType); i++)
            {
                if (Players[(int)userType].PossessingTile[i].TileType == itemType)
                {
                    tileTileCount++;
                }
            }
            return tileTileCount;
        }

        /// <summary>
        /// 플레이어가 보유한 특정 타일의 레벨 합을 반환합니다.
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="tiletype"></param>
        /// <returns></returns>
        public int GetPlayerTileLevelCount(UserType userType, ItemType itemType)
        {
            int tileLevelCount = 0;
            for (int i = 0; i < GetPlayerTileCountAll(userType); i++)
            {
                if(Players[(int)userType].PossessingTile[i].TileType == itemType)
                {
                    tileLevelCount += Players[(int)userType].PossessingTile[i].TileLevel;
                }
            }
            return tileLevelCount;
        }

        /// <summary>
        /// 특정 플레이어의 아이템의 수량을 조절합니다.
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="itemType"></param>
        /// <param name="addItem"></param>
        public void AddItemByType(int playerNumber, ItemType itemType, int addItem)
        {
            DataManager.Instance.GameData.PlayerData[playerNumber].ItemList[(int)itemType].Count += addItem;
        }

        /// <summary>
        /// 클릭한 타일을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public void GetClickedTile(BoardTile boardTile)
        {
            UIManager.Instance.SendTileInfo(boardTile);
            cameraCtrl.LookingTile(boardTile);
        }

        /// <summary>
        /// 배틀스테이지의 타일을 배치합니다.
        /// </summary>
        /// <param name="tileinfo"></param>
        public void BulidBattleTile(BoardTile tileinfo)
        {
            TileType = tileinfo.TileType;
            StartCoroutine(difficultyController.EstablishBattleStage(tileinfo, Players[0].PossessingTile));
        }

        /// <summary>
        /// 선택된 날씨 정보를 UI로 전달합니다.
        /// </summary>
        public void SendWeatherCard(int[] weathers)
        {
            UIManager.Instance.ShowWheatherEvent(weathers);
        }

        /// <summary>
        /// 거래 정보를 가져옵니다.
        /// </summary>
        public void SendTradeData(ItemData[] itemDatas, int requestPlayer, int receivePlayer)
        {
            TradeData tradeData = new TradeData
            {
                ItemsToTrade = itemDatas,
                RequestReceiver = Players[receivePlayer],
                RequestSender = Players[requestPlayer]
            };
            tradeCtrl.DoTrade(tradeData);
        }

        /// <summary>
        /// 거래 결과를 전달합니다.
        /// </summary>
        public void SendTradeResult(OtherPlayerState otherPlayerState)
        {
            UIManager.Instance.RecieveTradeResult(otherPlayerState);
        }

        public void SetWeatherEventNumber(int eventNumber)
        {
            gameData.InGameData.Weather = eventNumber;
            DataManager.Instance.SaveGameData(gameData, true);
        }

        /// <summary>
        /// 카메라를 전환시킵니다.
        /// </summary>
        public void ChangedCamera(StateType stateType)
        {
            cameraCtrl.ChangeCamera(stateType);
        }

        /// <summary>
        /// 플레이어를 이동시킵니다.
        /// </summary>
        /// <param name="direction"></param>
        public void PlayerMove(Vector3 direction)
        {
            if (coroutineMove == null)
            {
                coroutineMove = StartCoroutine(battlePlayer.MoveToTargetPostion(direction));
            }
            else
            {
                StopCoroutine(coroutineMove);
                coroutineMove = StartCoroutine(battlePlayer.MoveToTargetPostion(direction));
            }
        }

        /// <summary>
        /// 플레이어의 공격을 실행합니다.
        /// </summary>
        public void PlayerAttack()
        {
            battlePlayer.AttackEnemy(10);
        }

        /// <summary>
        /// 플레이어의 스킬을 실행합니다.
        /// </summary>
        /// <param name="skillNumber"></param>
        public void PlayerSkill(int skillNumber)
        {
            battlePlayer.UseSkill(skillNumber);
        }

        /// <summary>
        /// AI의 진행 상황을 담은 큐를 전달합니다.
        /// </summary>
        public void SetGameLog()
        {
            Queue<string> messageQueue = turnCtrl.SendGameLog();
        }

        private void SendPlayers()
        {
            turnCtrl.SetAIs(Players);
        }

        //플레이어 무기, 방어구 레벨, 보스 카운터
        public int GetPlayersAttackLevel(int playerNum)
        {
            return DataManager.Instance.GameData.PlayerData[playerNum].StatData.WeaponLevel;
        }

        public int GetPlayersDefenseLevel(int playerNum)
        {
            return DataManager.Instance.GameData.PlayerData[playerNum].StatData.ShieldLevel;
        }

        public int GetPlayersBossKillCount(int playerNum)
        {
            return DataManager.Instance.GameData.PlayerData[playerNum].BossKillCount;
        }
    }
}