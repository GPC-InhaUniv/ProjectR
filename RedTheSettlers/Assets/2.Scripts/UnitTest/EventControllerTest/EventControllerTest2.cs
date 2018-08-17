using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
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

            if (turnCount == GlobalVariables.MiddleBoss1AppearTurn) AppearMiddleBoss1();
            else if (turnCount == GlobalVariables.MiddleBoss2AppearTurn) AppearMiddleBoss2();
            else if (turnCount == GlobalVariables.BossAppearTurn) AppearBoss();

            if(turnCount >= GlobalVariables.WeatherEventStartTurn)
            {
                int playerNumber = GetLowestPlayer();
                if (playerNumber == 1)
                {
                    // 유저의 날씨 선택
                    // UI 기다려야 하니 코루틴으로 동작
                    //yield return PlayerSelect();
                }
                else
                {
                    // AI의 날씨 선택
                }
                //QualifyWeatherSelect(playerNumber);
            }

            yield return new WaitForSeconds(3);
        }

        public int GetTurnCount()
        {
            return datas.InGameData.TurnCount;
        }

        //private void QualifyWeatherSelect(int playerNumber)
        //{
        //    // 해당 플레이어에게 선택 패널을 띄워서 보여준다. >> UI에서 처리
            
        //    int selectedWeather = 0;
        //    datas.InGameData.Weather = selectedWeather;
        //}

        /// <summary>
        /// 12개의 날씨 이벤트 중 3가지를 뽑아 반환한다.
        /// </summary>
        /// <returns>3의 길이를 갖는 int형 배열</returns>
        public int[] PickWeatherEvent()
        {
            System.Random random = new System.Random();
            int[] weathers = { -1, -1, -1 };
            int pickedNumber;

            for (int i = 0; i < weathers.Length; i++)
            {
                pickedNumber = random.Next(0, (int)Weather.Count + 1);

                if (CheckDuplication(weathers, pickedNumber))
                    weathers[i] = pickedNumber;
                else i--;
            }
            return weathers;
        }

        private bool CheckDuplication(int[] weathers, int pickedNumber)
        {
            for (int i = 0; i < weathers.Length; i++)
            {
                if (weathers[i] == pickedNumber)
                    return false;
            }
            return true;
        }

        private int GetLowestPlayer()
        {
            int lowestPlayerNumber = 0;
            int tempCampCount = GlobalVariables.maxTileCount;

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                // 캠프 수가 같으면, 자원 수가 적은 사람이 우선권, 그것도 같으면 번호순
                if (tempCampCount > datas.PlayerData[i].TileList.Count)
                {
                    lowestPlayerNumber = i;
                }
                else if(tempCampCount == datas.PlayerData[i].TileList.Count)
                {
                    if (datas.PlayerData[lowestPlayerNumber].ItemData.SumOfItem > datas.PlayerData[i].ItemData.SumOfItem)
                        lowestPlayerNumber = i;
                }
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
