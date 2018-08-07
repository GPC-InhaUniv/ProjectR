using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.UnitTest
{
    interface ITrunObservable
    {
        void SetObserver(ObserverSets observer);
        void NotifyObserver();
    }

    public class GameManagerTest : MonoBehaviour, ITrunObservable
    {
        TurnControllerTest turnCtrl = new TurnControllerTest();

        public void GameUpdate()
        {
            turnCtrl.AcceptTestMethod();
        }

        public void SetObserver(ObserverSets observer)
        {
            //this.observer = observer;
        }

        public void NotifyObserver()
        {
            //observer.SendState(state); // 상태 변경을 전달?
        }
    }
}