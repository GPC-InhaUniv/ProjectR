using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers
{
    namespace UnitTest
    {
        public class GameManager : MonoBehaviour
        {
            TurnControllerTest turnCtrl;
            ObserverSets observer;

            private void Start()
            {
                turnCtrl.SetObserver(observer);

            }

            public void GameUpdate()
            {

            }
        }
    }
}
