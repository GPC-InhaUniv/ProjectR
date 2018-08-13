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

    class Rain : Water
    {
        public override void GetItems()
        {
            GetWater(2);
            GetWheat(1);
            GetCow(1);
            GetWood(1);
            GetIron(1);
            GetSoil(1);
        }
    }

    class Drought : Water
    {
        public override void GetItems()
        {
            GetWater(0);
            GetWheat(1);
            GetCow(1);
            GetWood(1);
            GetIron(1);
            GetSoil(1);
        }
    }

    class RichYear : Wheat
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(2);
            GetCow(1);
            GetWood(1);
            GetIron(1);
            GetSoil(1);
        }
    }

    class SwarmOfLocusts : Wheat
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(0);
            GetCow(1);
            GetWood(1);
            GetIron(1);
            GetSoil(1);
        }
    }

    class BreedingSeason : Cow
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(2);
            GetWood(1);
            GetIron(1);
            GetSoil(1);
        }
    }

    class Plague : Cow
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(0);
            GetWood(1);
            GetIron(1);
            GetSoil(1);
        }
    }

    class FestivalOfSprits : Wood
    { 
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(1);
            GetWood(2);
            GetIron(1);
            GetSoil(1);
        }
    }

    class ForestFire : Wood
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(1);
            GetWood(0);
            GetIron(1);
            GetSoil(1);
        }
    }

    class GoldMine : Iron
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(1);
            GetWood(1);
            GetIron(2);
            GetSoil(1);
        }
    }

    class LandSlide : Iron
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(1);
            GetWood(1);
            GetIron(0);
            GetSoil(1);
        }
    }

    class GoodSoil : Soil
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(1);
            GetWood(1);
            GetIron(1);
            GetSoil(2);
        }
    }

    class Deluge : WeatherChange
    {
        public override void GetItems()
        {
            GetWater(1);
            GetWheat(1);
            GetCow(1);
            GetWood(1);
            GetIron(1);
            GetSoil(0);
        }
    }

    abstract class WeatherChange
    {
        GameData datas = DataManager.Instance.GameData;
        abstract public void GetItems();

        public void GetWater(int itemCount)
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

        public void GetWheat(int itemCount)
        {
            if (0 > itemCount || itemCount > 2)
            {
                Debug.Log("잘못된 ItemCount입니다.");
                return;
            }

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                datas.PlayerData[i].ItemData.WheatNumber += itemCount;
            }
        }

        public void GetWood(int itemCount)
        {
            if (0 > itemCount || itemCount > 2)
            {
                Debug.Log("잘못된 ItemCount입니다.");
                return;
            }

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                datas.PlayerData[i].ItemData.WoodNumber += itemCount;
            }
        }

        public void GetCow(int itemCount)
        {
            if (0 > itemCount || itemCount > 2)
            {
                Debug.Log("잘못된 ItemCount입니다.");
                return;
            }

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                datas.PlayerData[i].ItemData.CowNumber += itemCount;
            }
        }

        public void GetIron(int itemCount)
        {
            if (0 > itemCount || itemCount > 2)
            {
                Debug.Log("잘못된 ItemCount입니다.");
                return;
            }

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                datas.PlayerData[i].ItemData.IronNumber += itemCount;
            }
        }

        public void GetSoil(int itemCount)
        {
            if (0 > itemCount || itemCount > 2)
            {
                Debug.Log("잘못된 ItemCount입니다.");
                return;
            }

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                datas.PlayerData[i].ItemData.SoilNumber += itemCount;
            }
        }
    }

    abstract class Water : WeatherChange { }
    abstract class Wheat : WeatherChange { }
    abstract class Cow : WeatherChange { }
    abstract class Wood : WeatherChange { }
    abstract class Iron : WeatherChange { }
    abstract class Soil : WeatherChange { }
}