using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using RedTheSettlers.Tiles;
using RedTheSettlers.UnitTest;
using RedTheSettlers.UI;
using RedTheSettlers.Users;

namespace RedTheSettlers.GameSystem
{
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
        public BattleControllerTest battleCtrl;
        public CameraController cameraCtrl;
        public DifficultyController difficultyController;
        
        public GameState state = GameState.TurnController;

        private void Start()
        {
            turnCtrl.Callback = new TurnCallback(TurnFinish);
            //eventCtrl.Callback = new EventCallback(EventFinish);
            //itemCtrl.Callback = new ItemCallback(ItemFinish);
            tradeCtrl.Callback = new TradeCallback(TradeFinish);
            battleCtrl.Callback = new BattleCallback(BattleFinish);

            cameraCtrl = new CameraController();
            //TileManager.Instance.InitializeTileSet();
        }

        //게임 매니저가 타일 매니저를 통해 타일 배치(보드, 전투)을 지시해야 한다.

        //어떻게 턴의 흐름을 제어 할 것인지 고민
        public void GameFlow(IEnumerator Flow)
        {
            switch (state)
            {
                case GameState.EventController:
                    eventCtrl.EventFlow();
                    break;
                case GameState.ItemController:
                    itemCtrl.ItemFlow();
                    break;
                default:
                    break;
            }
            //GameFlow(turnCtrl.TurnFlow());
        }

        public void BulidBattleStage()
        {
            
        }

        private void BattleFinish()
        {
            
        }

        private void TradeFinish()
        {
            
        }

        private void ItemFinish()
        {
            
        }

        private void EventFinish()
        {
            
        }

        private void TurnFinish()
        {
            
        }

        private void InsinstallationBoardTile()
        {
            TileManager.Instance.CreateBoardTileGrid();
            TileManager.Instance.ShowBoardTile();
        }

        private void InsinstallationBattleTile(ItemType itemType, int difficulty)
        {
            TileManager.Instance.CreateBattleTileGrid(itemType, difficulty);
            TileManager.Instance.ShowBattleTile();
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
            //cameraCtrl.
        }

    }
}