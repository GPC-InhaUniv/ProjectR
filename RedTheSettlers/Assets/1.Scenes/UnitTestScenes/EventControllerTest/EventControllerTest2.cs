using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public struct InGameData
    {
        public int TurnCount;
        public int Weather;
        public int BossKillCount;
    }

    
    /// <summary>
    /// 작성자 : 박지용
    /// 날씨 선택이나 보스 출현 등 보드게임에서 발생하는 이벤트를 제어한다.
    /// </summary>
    public class EventControllerTest2 : MonoBehaviour
    {
        InGameData data = new InGameData();

        public IEnumerator TradeFlow()
        {
            int turnCount = GetTurnCount();

            if (turnCount == 12) AppearMiddleBoss1();
            else if (turnCount == 24) AppearMiddleBoss2();
            else if (turnCount == 36) AppearBoss();

            if(turnCount >= 5)


            yield return new WaitForSeconds(3);
        }

        public int GetTurnCount()
        {
            return data.TurnCount;
        }

        private void QualifyWeatherSelect()
        {

        }

        //private Player GetLowestPlayer()
        //{
        //    Player lowestPlayer;
        //    //DataManager

        //    return lowestPlayer;
        //}

        private void AppearMiddleBoss1()
        {
            Debug.Log("중간보스 1 등장");
        }

        private void AppearMiddleBoss2()
        {
            Debug.Log("중간보스 2 등장");
        }

        private void AppearBoss()
        {
            Debug.Log("보스 등장");
        }

    }
}
