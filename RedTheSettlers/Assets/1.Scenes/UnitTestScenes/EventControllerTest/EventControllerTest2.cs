using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    // 필요한 데이터 리스트 적어놓은 것. 나중에 지움
    public struct needInfos
    {
        public int TurnCount;
        public int Weather;
        
        public int MaxPlayer; // 4
        public int MiddleBoss1AppearTurn; // 12
        public int MiddleBoss2AppearTurn; // 24
        public int BossAppearTurn; // 36
        public int WeatherEventStartTurn; // 5
    }

    /// <summary>
    /// 작성자 : 박지용
    /// 날씨 선택이나 보스 출현 등 보드게임에서 발생하는 이벤트를 제어한다.
    /// </summary>
    public class EventControllerTest2 : MonoBehaviour
    {
        GameData datas = DataManager.Instance.GameData;

        public IEnumerator EventFlow()
        {
            int turnCount = GetTurnCount();

            if (turnCount == 12) AppearMiddleBoss1();
            else if (turnCount == 24) AppearMiddleBoss2();
            else if (turnCount == 36) AppearBoss();

            if(turnCount >= 5)
            {
                int playerNumber = GetLowestPlayer();
                QualifyWeatherSelect(playerNumber);
            }

            yield return new WaitForSeconds(3);
        }

        public int GetTurnCount()
        {
            return datas.InGameData.TurnCount;
        }

        private void QualifyWeatherSelect(int playerNumber)
        {
            // 해당 플레이어에게 선택 패널을 띄워서 보여준다.
            // 플레이어의 선택 결과에 따라 값을 돌려받는다.
            var selectedWeather = 0;
            datas.InGameData.Weather = selectedWeather;
        }

        private int GetLowestPlayer()
        {
            int lowestPlayerNumber = 0;
            int tempCampCount = 50; // tempValue

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                if (tempCampCount > datas.PlayerData[i].TileList.Count)
                    lowestPlayerNumber = i;
            }
            return lowestPlayerNumber;
        }

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
