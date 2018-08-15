using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public enum Weather
    {
        Rain,             // water
        Drought,
        RichYear,         // wheat
        SwarmOfLocusts,
        BreedingSeason,   // cow
        Plague,
        FestivalOfSprits, // foreset
        ForestFire,
        GoldMine,         // iron
        LandSlide,
        GoodSoil,         // soil
        Deluge,
    }

    abstract class WeatherChange
    {
        GameData datas = DataManager.Instance.GameData;
        abstract public void GetItems();

        /// <summary>
        /// 자원 타입에 따른 자원 획득을 수행한다.
        /// </summary>
        /// <param name="type">얻을 자원의 타입</param>
        /// <param name="weatherBonus">날씨에 따른 자원 추가 획득량 (1, -1)</param>
        public void GetItemByType(ItemType type, int weatherBonus)
        {
            switch (type)
            {
                case ItemType.Water:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.WaterNumber += GetItemfromCampLevel(type, weatherBonus, i);
                    break;

                case ItemType.Wheat:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.WheatNumber += GetItemfromCampLevel(type, weatherBonus, i);
                    break;

                case ItemType.Wood:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.WoodNumber += GetItemfromCampLevel(type, weatherBonus, i);
                    break;

                case ItemType.Cow:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.CowNumber += GetItemfromCampLevel(type, weatherBonus, i);
                    break;

                case ItemType.Iron:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.IronNumber += GetItemfromCampLevel(type, weatherBonus, i);
                    break;

                case ItemType.Soil:
                    for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
                        datas.PlayerData[i].ItemData.SoilNumber *= GetItemfromCampLevel(type, weatherBonus, i);
                    break;
            }
        }

        // ##수정
        // GameManager에 타입별로 자원 개수를 얻을 수 있게 되면 수정할 것
        private int GetItemfromCampLevel(ItemType type, int weatherBonus, int playerNumber)
        {
            int playerCampCount = datas.PlayerData[playerNumber].TileList.Count;
            int getItemCount = 0;

            for (int i = 0; i < playerCampCount; i++)
            {
                // 해당 타일 타입의 개수만큼, 타일 레벨 + 날씨 보너스만큼 획득 자원이 증가한다.
                if (datas.PlayerData[playerNumber].TileList[i].TileType == type)
                { getItemCount += ( datas.PlayerData[playerNumber].TileList[i].TileLevel + weatherBonus ); }
            }

            LogManager.Instance.UserDebug(LogColor.Orange, GetType().Name, "Player" + playerNumber + "의 " + type.ToString() + " 획득량 : " + getItemCount);
            return getItemCount;
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
            GetItemByType(ItemType.Water, 1);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class Drought : Water
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, -1);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class RichYear : Wheat
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 1);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class SwarmOfLocusts : Wheat
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, -1);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class BreedingSeason : Cow
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 1);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class Plague : Cow
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, -1);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class FestivalOfSprits : Wood
    { 
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 1);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class ForestFire : Wood
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, -1);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class GoldMine : Iron
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 1);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class LandSlide : Iron
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, -1);
            GetItemByType(ItemType.Soil, 0);
        }
    }

    class GoodSoil : Soil
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 1);
        }
    }

    class Deluge : WeatherChange
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, -1);
        }
    }
}