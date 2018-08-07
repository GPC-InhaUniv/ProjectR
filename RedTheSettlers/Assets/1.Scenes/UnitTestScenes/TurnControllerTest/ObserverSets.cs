using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers
{
    namespace UnitTest
    {
        public class ObserverSets : MonoBehaviour
        {
            public GameManagerTest gm;
            public TurnControllerTest turn;


            delegate void TurnObserver();
            delegate void BattleObserver();
            delegate void ItemObserver();
            delegate void TradeObserver();
            delegate void EventObserver();

            TurnObserver _turnObserver;
            BattleObserver _battleObserver;
            ItemObserver _itemObserver;
            TradeObserver _tradeObserver;
            EventObserver _eventObserver;

            private void Start()
            {
                _turnObserver += new TurnObserver(turn.NotifyObserver);
            }

            public void SendState(GameState state)
            {
                gm.GameUpdate();
            }

            
        }
    }
}
