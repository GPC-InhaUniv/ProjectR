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
        Count = Deluge,
    }

    abstract class WeatherChange
    {
        GameData datas = DataManager.Instance.GameData;
        abstract public void GetItems();

        /// <summary>
        /// 자원 타입에 따른 자원 획득을 수행한다.
        /// </summary>
        /// <param name="type">얻을 자원의 타입</param>
        /// <param name="weatherBonus">날씨에 따른 자원 획득량 제어</param>
        public void GetItemByType(ItemType type, int weatherBonus)
        {
            int getItemCount = 0;

            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                getItemCount = GetItemfromCampLevel(i, type, weatherBonus);
                GameManager.Instance.SetItemByType(i, type, getItemCount);
            }
        }

        private int GetItemfromCampLevel(int playerNumber, ItemType type, int weatherBonus)
        {
            int playerCampCount = datas.PlayerData[playerNumber].TileList.Count;
            int getItemCount = 0;

            int loopCount = 0;
            switch(type)
            {
                case ItemType.Cow:
                    loopCount = GameManager.Instance.PlayerCowTileData[playerNumber].Count;
                    break;
                case ItemType.Iron:
                    loopCount = GameManager.Instance.PlayerIronTileData[playerNumber].Count;
                    break;
                case ItemType.Soil:
                    loopCount = GameManager.Instance.PlayerSoilTileData[playerNumber].Count;
                    break;
                case ItemType.Water:
                    loopCount = GameManager.Instance.PlayerWaterTileData[playerNumber].Count;
                    break;
                case ItemType.Wheat:
                    loopCount = GameManager.Instance.PlayerWheatTileData[playerNumber].Count;
                    break;
                case ItemType.Wood:
                    loopCount = GameManager.Instance.PlayerWoodTileData[playerNumber].Count;
                    break;
            }

            for (int i = 0; i < loopCount; i++)
            {
                getItemCount += GameManager.Instance.PlayerCowTileData[playerNumber][i].TileLevel + weatherBonus;
            }

            //for (int i = 0; i < playerCampCount; i++)
            //{
            //    // 해당 타일 타입의 개수만큼, 타일 레벨 + 날씨 보너스만큼 획득 자원이 증가한다.
            //    if (datas.PlayerData[playerNumber].TileList[i].TileType == type)
            //    { getItemCount += ( datas.PlayerData[playerNumber].TileList[i].TileLevel + weatherBonus ); }
            //}

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

    class GoodDay : WeatherChange // default
    {
        public override void GetItems()
        {
            GetItemByType(ItemType.Water, 0);
            GetItemByType(ItemType.Wheat, 0);
            GetItemByType(ItemType.Wood, 0);
            GetItemByType(ItemType.Cow, 0);
            GetItemByType(ItemType.Iron, 0);
            GetItemByType(ItemType.Soil, 0);
        }
    }

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
        }
    }
}