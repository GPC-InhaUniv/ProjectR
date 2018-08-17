using RedTheSettlers.Players;
using System.Collections.Generic;
using RedTheSettlers.Tiles;
using UnityEngine;
using RedTheSettlers.UnitTest;
using System;

namespace RedTheSettlers.GameSystem
{
    /// <summary>
    /// 각 컨트롤러를 관리하고 중재하는 매니저
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        /*
        각 플레이어(보드4 + 전투1)를 가지고 있음

        컨트롤러로 부터 작업이 끝났다는 요청를 받는다.
        다음 컨트롤러로 작업을 넘겨준다.
        이 과정에서 데이터와 연동
        
        임시적 데이터 저장 및 ui 매니저로의 전달(presenter)
         */
        public List<TileData>[] PlayerCowTileData;
        public List<TileData>[] PlayerIronTileData;
        public List<TileData>[] PlayerSoilTileData;
        public List<TileData>[] PlayerWaterTileData;
        public List<TileData>[] PlayerWheatTileData;
        public List<TileData>[] PlayerWoodTileData;

        public TurnControllerTest turnCtrl;
        public EventControllerTest eventCtrl;
        public ItemControllerTest itemCtrl;
        public TradeControllerTest tradeCtrl;
        public BattleControllerTest battleCtrl;

        public GameState state = GameState.TurnController;

        private void Start()
        {
            PlayerCowTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerIronTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerSoilTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerWaterTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerWheatTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerWoodTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];

            turnCtrl.Callback = new TurnCallback(TurnFinish);
            eventCtrl.Callback = new EventCallback(EventFinish);
            itemCtrl.Callback = new ItemCallback(ItemFinish);
            tradeCtrl.Callback = new TradeCallback(TradeFinish);
            battleCtrl.Callback = new BattleCallback(BattleFinish);
        }

        public void GameFlow()
        {
            //switch (state)
            //{
            //    case GameState.EventController:
            //        eventCtrl.EventFlow();
            //        break;
            //    case GameState.ItemController:
            //        itemCtrl.ItemFlow();

            //        break;
            //    default:
            //        break;
            //}
            //yield return turnCtrl.TurnFlow();
        }

        private void BattleFinish()
        {
            throw new NotImplementedException();
        }

        private void TradeFinish()
        {
            throw new NotImplementedException();
        }

        private void ItemFinish()
        {
            throw new NotImplementedException();
        }

        private void EventFinish()
        {
            throw new NotImplementedException();
        }

        private void TurnFinish()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 모든 타일을 검색해서 각 플레이어가 가진 타일을 자원별로 분류합니다.
        /// </summary>
        /// <param name="playerNumber"></param>
        public void SortItemList(int playerNumber)
        {
            for (int i = 0; i < DataManager.Instance.GameData.PlayerData[playerNumber].TileList.Count; i++)
            {
                if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Cow)
                {//소
                    PlayerCowTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Iron)
                {//강철
                    PlayerIronTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Soil)
                {//모레
                    PlayerSoilTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Water)
                {//물
                    PlayerWaterTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Wheat)
                {//밀
                    PlayerWheatTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Wood)
                {//나무
                    PlayerWoodTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
            }
        }

        public void SetItemByType(int playerNumber, ItemType itemType, int addItem)
        {
            switch (itemType)
            {
                case ItemType.Cow:
                    DataManager.Instance.GameData.PlayerData[playerNumber].ItemData.CowNumber += addItem;
                    break;
                case ItemType.Iron:
                    DataManager.Instance.GameData.PlayerData[playerNumber].ItemData.IronNumber += addItem;
                    break;
                case ItemType.Soil:
                    DataManager.Instance.GameData.PlayerData[playerNumber].ItemData.SoilNumber += addItem;
                    break;
                case ItemType.Water:
                    DataManager.Instance.GameData.PlayerData[playerNumber].ItemData.WaterNumber += addItem;
                    break;
                case ItemType.Wheat:
                    DataManager.Instance.GameData.PlayerData[playerNumber].ItemData.WheatNumber += addItem;
                    break;
                case ItemType.Wood:
                    DataManager.Instance.GameData.PlayerData[playerNumber].ItemData.WoodNumber += addItem;
                    break;
                default:
                    Debug.Log("GameManager : 올바르지 않은 ItemType");
                    break;
            }
        }



        //필요한 기능들
        // 다희 : 선택 된 타일의 타입을 알아야 한다.
        // " : 선택 된 타일이 어느 플레이어 건지 알아야 한다.


    }
}