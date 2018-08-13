using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public class ItemControllerTest2 : MonoBehaviour
    {
        IWeatherChangeable weather;
        WeatherChange weather2;
        GameData datas = DataManager.Instance.GameData;

        public IEnumerator ItemFlow()
        {
            ChangeWeather();
            weather2.GetItems();
            weather.GetItems();

            yield return new WaitForSeconds(3);
        }

        public void ChangeWeather()
        {
            switch((Weather)datas.InGameData.Weather)
            {
                case Weather.Rain:
                    weather = new Rain(); break;
                case Weather.Drought:
                    weather = new Drought(); break;
                default: Debug.Log("존재하지 않는 날씨 상태입니다."); break;
            }
        }
    }
}