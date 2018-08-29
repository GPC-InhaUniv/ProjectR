using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;

namespace RedTheSettlers.UnitTest
{
    public enum GameState
    {
        EventController,
        ItemController,
        PlayerTurn,
        AI1Turn,
        AI2Turn,
        AI3Turn,
    }

    /// <summary>
    /// 작성자 : 박지용
    /// 유저와 AI의 턴 흐름을 제어한다.
    /// 보드 게임에서 턴 흐름과 UI 로그 제어를 담당한다.
    /// </summary>
    public class TurnControllerTest : MonoBehaviour
    {
        /// <summary>
        /// 현재 턴 진행중인 플레이어 번호(0 ~ 3)
        /// </summary>
        private int CurrentPlayerTurn = 0;
        [SerializeField]
        private BoardAI[] AIs;

        private FlowFinishCallback _callback;
        public FlowFinishCallback Callback
        {
            get{ return _callback; }
            set { _callback = value; }
        }
        
        public void TurnFlow(GameState gameState)
        {
            CurrentPlayerTurn = (gameState - GameState.AI1Turn + 1);

            SendGameLog();
        }

        /// <summary>
        /// AI의 턴에서 게임 화면에 게임 진행 상황을 표시하는 텍스트를 전달한다.
        /// </summary>
        public Queue<string> SendGameLog()
        {
            Queue<string> messages = null;
            if (CurrentPlayerTurn >= 0) // ai 턴일때만 CurrentPlayerTurn 값이 0 이상
            {
                messages = AIs[CurrentPlayerTurn].MessageQueue;
            }
            return messages;
        }

        public void SetAIs(User[] players)
        {
            for (int i = 0; i < AIs.Length; i++)
            {
                AIs[i] = players[i + 1].GetComponent<BoardAI>();
            }
        }

        public void OnClickTurnFinish()
        {
            Callback();
        }
    }
}