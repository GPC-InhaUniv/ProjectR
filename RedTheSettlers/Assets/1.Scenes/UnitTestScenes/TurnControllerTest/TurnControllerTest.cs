using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.UnitTest
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

    public abstract class Controller : MonoBehaviour
    {
        ITrunObservable turnobserver;
    }

    public class TurnControllerTest : Controller
    {
        GameState state = GameState.EventController;
        private ObserverSets observer;

        public void AcceptTestMethod()
        {

        }

    }
}