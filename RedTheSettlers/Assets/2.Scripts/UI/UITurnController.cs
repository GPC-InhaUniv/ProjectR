using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UI
{
    public class UITurnController : MonoBehaviour
    {
        /// <summary>
        /// 작성자 : 강다희
        /// 플레이어의 현재 turn수를 노출해주는 UI스크립트
        ///
        /// [중요] Turn, move, event를 Script 분리 할 것임
        /// [중요] UI Manager 스크립트에서 각 상황에 맞게 처리 할 예정
        /// </summary>

        [Header("Player's Current Turn")]
        [SerializeField]
        private Text currentTurnText;

        private int currentTurn;

        private void changeTurn()
        {
            currentTurn = 15;//test
            currentTurnText.text = currentTurn.ToString();

            //currentTurn.text = gameData.cowcow.ToString();
            //이런식으로 현재 Turn 정보를 gameData에서 가져와서 텍스트에 넣어줘야 함.
            LogManager.Instance.UserDebug(LogColor.Olive, GetType().Name, "현재 Turn : " + currentTurn);
        }

        private void Start()
        {
            changeTurn();
        }

        private void Update()
        {
        }
    }
}