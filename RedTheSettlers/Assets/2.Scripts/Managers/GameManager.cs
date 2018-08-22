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
        //TurnFlow의 리턴값을 받아 자기 자신을 재귀적으로 호출 하는건??
        //최초의 호출은 씬 로드가 끝난 이후 stageManager 혹은 다른 객체에게
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
            GameFlow(turnCtrl.TurnFlow());
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
        /// 모든 타일을 검색해서 각 플레이어가 가진 타일을 자원별로 분류합니다.
        /// </summary>
        /// <param name="playerNumber"></param>
        public void SortItemList(UserType player, ItemType itemType)
        {
            //for (int i = 0; i < Players[(int)player].?; i++)
            {
                
            }
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

            //인풋으로부터 입력을 받게 수정해야 한다.
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

        //추가해야 될 거
        //날씨 카드에서 무엇을 골랐는지 이벤트 컨트롤러에게
        //트레이드 패널에서 ItemData을 트레이드 컨트롤러에게
        //다른 player와의 거래 결과를 패널에게 다시 전달

        /// <summary>
        /// 선택 된 날씨 카드를 반환합니다.
        /// </summary>
        public void SelectedWeatherCard()
        {
            
        }

        /// <summary>
        /// 거래 정보를 가져옵니다.
        /// </summary>
        public void GetTradeData()
        {
            
        }
    }

    

}