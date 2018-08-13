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

    abstract class WeatherChange
    {
        GameData datas = DataManager.Instance.GameData;
        abstract public void GetItems();

        // 캠프 개수 정보를 알 수 없어서 ItemData로 일단 짰음.
        public void GetItemfromWeather(ItemType type, int itemCount)
        {
            switch (type)
            {
                case ItemType.Water:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.WaterNumber *= itemCount;
                    break;

                case ItemType.Wheat:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.WheatNumber *= itemCount;
                    break;

                case ItemType.Wood:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.WoodNumber *= itemCount;
                    break;

                case ItemType.Cow:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.CowNumber *= itemCount;
                    break;

                case ItemType.Iron:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.IronNumber *= itemCount;
                    break;

                case ItemType.Soil:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.SoilNumber *= itemCount;
                    break;
            }
        }
    }

    abstract class Water : WeatherChange { }
    abstract class Wheat : WeatherChange { }
    abstract class Cow : WeatherChange { }
    abstract class Wood : WeatherChange { }
    abstract class Iron : WeatherChange { }
    abstract class Soil : WeatherChange { }

    class Rain : Water
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 2);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class Drought : Water
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 0);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class RichYear : Wheat
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 2);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class SwarmOfLocusts : Wheat
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 0);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class BreedingSeason : Cow
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 2);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class Plague : Cow
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 0);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class FestivalOfSprits : Wood
    { 
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 2);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class ForestFire : Wood
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 0);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class GoldMine : Iron
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 2);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class LandSlide : Iron
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 0);
            GetItemfromWeather(ItemType.Soil, 1);
        }
    }

    class GoodSoil : Soil
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 2);
        }
    }

    class Deluge : WeatherChange
    {
        public override void GetItems()
        {
            GetItemfromWeather(ItemType.Water, 1);
            GetItemfromWeather(ItemType.Wheat, 1);
            GetItemfromWeather(ItemType.Wood, 1);
            GetItemfromWeather(ItemType.Cow, 1);
            GetItemfromWeather(ItemType.Iron, 1);
            GetItemfromWeather(ItemType.Soil, 0);
        }
    }
}