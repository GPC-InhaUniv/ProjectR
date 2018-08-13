using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public enum Weather
    {
        Rain, // water
        Drought,
        RichYear, // wheat
        SwarmOfLocusts,
        BreedingSeason, // cow
        Plague,
        FestivalOfSprits, // foreset
        ForestFire,
        GoldMine, // iron
        LandSlide,
        GoodSoil, // soil
        Deluge,
    }

    public class WeathersTest : MonoBehaviour
    {

    }

    class Rain : Water
    {
        public override void GetItems()
        {

        }
    }

    class Drought : Water
    {
        public override void GetItems()
        {

        }
    }

    class RichYear : Wheat
    {
        public override void GetItems()
        {

        }
    }

    class SwarmOfLocusts : Wheat
    {
        public override void GetItems()
        {

        }
    }

    class BreedingSeason : Cow
    {
        public override void GetItems()
        {
        }
    }

    class Plague : Cow
    {
        public override void GetItems()
        {
        }
    }

    class FestivalOfSprits : Forest
    {
        public override void GetItems()
        {
        }
    }

    class ForestFire : Forest
    {
        public override void GetItems()
        {
        }
    }

    class GoldMine : Iron
    {
        public override void GetItems()
        {
        }
    }

    class LandSlide : Iron
    {
        public override void GetItems()
        {
        }
    }

    class GoodSoil : Soil
    {
        public override void GetItems()
        {
        }
    }

    class Deluge : Soil
    {
        public override void GetItems()
        {
        }
    }


    interface IWeatherChangeable
    {
        void GetItems();
    }

    abstract class WeatherChange
    {
        GameData datas = DataManager.Instance.GameData;
        public void GetItems(int itemCount)
        {
            if(0 > itemCount || itemCount > 2)
            {
                Debug.Log("잘못된 ItemCount입니다.");
                return;
            }

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                datas.PlayerData[i].ItemData.WaterNumber += itemCount;
            }
        }
    }


    abstract class Water : IWeatherChangeable
    {
        public abstract void GetItems();
    }

    abstract class Wheat : IWeatherChangeable
    {
        public abstract void GetItems();
    }


    abstract class Cow : IWeatherChangeable
    {
        public abstract void GetItems();
    }

    abstract class Forest : IWeatherChangeable
    {
        public abstract void GetItems();
    }

    abstract class Iron : IWeatherChangeable
    {
        public abstract void GetItems();
    }

    abstract class Soil : IWeatherChangeable
    {
        public abstract void GetItems();
    }
}