using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.UnitTest
{
    public enum GameState
    {
        TurnController,
        EventController,
        ItemController,
        TradeController,
        BattleController,
        Player1,
        Player2,
        Player3,
        Player4,
    }

    public delegate void TurnCallback();

    /// <summary>
    /// 작성자 : 박지용
    /// 보드 게임에서 턴 흐름과 UI 로그 제어를 담당한다.
    /// </summary>
    public class TurnControllerTest : MonoBehaviour
    {
        private TurnCallback _callback;
        public TurnCallback Callback
        {
            get
            {
                GameManagerTest.Instance.state += 1;
                return _callback;
            }
            set { _callback = value; }
        }

        public IEnumerator TurnFlow()
        {
            Callback();
            yield return new WaitForSeconds(3);
        }
    }
}