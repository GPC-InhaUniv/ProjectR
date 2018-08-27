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

        public TurnControllerTest turnCtrl;
        public EventControllerTest eventCtrl;
        public ItemControllerTest itemCtrl;
        public TradeControllerTest tradeCtrl;
        public BattleControllerTest battleCtrl;
        public CameraController cameraCtrl;
        
        public GameState state = GameState.TurnController;

        private void Start()
        {
            turnCtrl.Callback = new TurnCallback(TurnFinish);
            eventCtrl.Callback = new EventCallback(EventFinish);
            itemCtrl.Callback = new ItemCallback(ItemFinish);
            tradeCtrl.Callback = new TradeCallback(TradeFinish);
            battleCtrl.Callback = new BattleCallback(BattleFinish);
        }

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
        /// 클릭한 타일을 반환합니다.(임시 기능)
        /// </summary>
        /// <returns></returns>
        public BoardTile GetClickedTile()
        {
            //인풋 매니저로부터 입력을 받게 수정해야 한다.
            BoardTile tile;
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 1f) && (hitInfo.collider.tag == GlobalVariables.TAG_TILE))
                {
                    tile = hitInfo.collider.GetComponent<BoardTile>();
                }
                else tile = null;
            }
            else tile = null;

            return tile;
        }

        /// <summary>
        /// 선택된 날씨 정보를 UI로 전달합니다.
        /// </summary>
        public void SendWeatherCard(int[] weathers)
        {
            
        }

        /// <summary>
        /// 거래 정보를 가져옵니다.
        /// </summary>
        public void SendTradeData(ItemData itemData)
        {
            //트레이드 패널에서 ItemData을 트레이드 컨트롤러에게
        }

        /// <summary>
        /// 거래 결과를 전달합니다.
        /// </summary>
        public void SendTradeResult()
        {
            //다른 player와의 거래 결과를 패널에게 다시 전달
        }
    }
}