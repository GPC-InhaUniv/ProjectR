using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers
{
    public enum GameState
    {
        //TurnController,
        EventController,
        ItemController,
        Player1, 
        Player2,
        Player3,
        Player4,
    }

    namespace UnitTest
    {
        interface IInformable
        {
            void SetObserver(ObserverSets observer);
            void NotifyObserver();
        }

        public class TurnControllerTest : MonoBehaviour, IInformable
        {
            GameState state = GameState.EventController;
            private ObserverSets observer;

            public void SetObserver(ObserverSets observer)
            {
                this.observer = observer;
            }

            public void NotifyObserver()
            {
                observer.SendState(state); // 상태 변경을 전달?
            }
            
        }
    }
}