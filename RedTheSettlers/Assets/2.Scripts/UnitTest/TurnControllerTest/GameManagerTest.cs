using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTheSettlers.UnitTest
{
    /// <summary>
    /// 작성자 : 박지용
    /// TurnController 테스트를 위해 임시로 만든 게임매니저
    /// </summary>
    public class GameManagerTest : Singleton<GameManagerTest>
    {
        public Text StateText;
        public TurnControllerTest turnCtrl;
        public EventControllerTest eventCtrl;
        public ItemControllerTest itemCtrl;
        public TradeControllerTest tradeCtrl;
        public BattleControllerTest battleCtrl;

        public GameState state = GameState.TurnController;

        private void Start()
        {
            turnCtrl.Callback = new TurnCallback(TurnFinish);
            eventCtrl.Callback = new EventCallback(EventFinish);
            itemCtrl.Callback = new ItemCallback(ItemFinish);
            tradeCtrl.Callback = new UTradeCallback(TradeFinish);
            battleCtrl.Callback = new BattleCallback(BattleFinish);
            
            StartCoroutine(GameFlow());
        }

        public IEnumerator GameFlow()
        {
            yield return turnCtrl.TurnFlow();

            switch (state)
            {
                case GameState.EventController:
                    eventCtrl.EventFlow();
                    break;
                case GameState.ItemController:
                    itemCtrl.ItemFlow();
                    break;
                default: state = GameState.TurnController; break;
            }
            yield break;
        }

        public void TurnFinish()
        {
            Debug.Log("턴 컨트롤러 종료");
            StateText.text = state.ToString();
        }

        public void EventFinish()
        {
            Debug.Log("이벤트 컨트롤러 종료");
        }

        public void ItemFinish()
        {
            Debug.Log("아이템 컨트롤러 종료");
        }

        public void TradeFinish()
        {
            Debug.Log("트레이드 컨트롤러 종료");
        }

        public void BattleFinish()
        {
            Debug.Log("배틀 컨트롤러 종료");
        }
    }
}