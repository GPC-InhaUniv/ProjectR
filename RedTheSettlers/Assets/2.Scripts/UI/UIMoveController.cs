using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace RedTheSettlers.UI
{
    public class UIMoveController : MonoBehaviour
    {
        /// <summary>
        /// 작성자 : 강다희
        /// 플레이어의 현재 Move를 노출해주는 UI스크립트
        ///
        /// [중요] Turn, move, event를 Script 분리 할 것임
        /// [중요] UI Manager 스크립트에서 각 상황에 맞게 처리 할 예정
        /// </summary>

        [Header("Player's Current Move")]
        [SerializeField]
        private Text moveText;

        private int currentMove;

        private void ChangeMove()
        {
            currentMove = 5; //Test

            moveText.text = currentMove.ToString();

            //currentTurn.text = gameData.cowcow.ToString();
            //이런식으로 현재 Move 정보를 gameData에서 가져와서 텍스트에 넣어줘야 함.
        }

        private void Start()
        {
            ChangeMove();
        }

        private void Update()
        {
        }
    }
}