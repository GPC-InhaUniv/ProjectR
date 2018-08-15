using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

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
            get{ return _callback; }
            set { _callback = value; }
        }

        GameData datas = DataManager.Instance.GameData;

        public IEnumerator TurnFlow()
        {
            GameManagerTest.Instance.state += 1;
            PrintGameLog();
            Callback();
            yield return new WaitForSeconds(3);
        }

        /// <summary>
        /// 게임 화면에 게임 진행 상황을 표시하는 텍스트를 출력한다.
        /// UI매니저와 연동한다.
        /// </summary>
        public void PrintGameLog()
        {
            
        }
    }
}