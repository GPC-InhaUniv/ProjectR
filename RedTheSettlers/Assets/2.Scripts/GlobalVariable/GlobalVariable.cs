using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public enum ItemType
    {
        Cow = 0,
        Iron = 1,
        Soil = 2,
        Water = 3,
        Wheat = 4,
        Wood = 5,
    }

    public enum AssetBundleNumbers
    {
        Player,
        Skill,
        Enemy, // unload(false)
        MiddleBoss1,
        MiddleBoss2,
        Boss,
        Tile, // unload(false)
        UI,
    }

    static class GlobalVariables
    {
        public const int tileGridSize = 9;
        public const int minZIntercept = 11;
        public const int maxZIntercept = 21;
        public const int maxItemNum = 30;
        public const int maxEquipmentUpgradeLevel = 3;
        public const int maxTileUpgradeLevel = 3;
        public const int maxTileCount = 39;

        public const int maxPlayerNumber = 4;
        public const int maxItemNumber = 6;
        public const int MiddleBoss1AppearTurn = 12;
        public const int MiddleBoss2AppearTurn = 24;
        public const int BossAppearTurn = 36;
        public const int WeatherEventStartTurn = 5;
    }
}