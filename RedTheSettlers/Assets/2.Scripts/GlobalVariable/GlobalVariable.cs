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
        Wood = 5
    }

    public enum TileOwner
    {
        Player = 0,
        AI1 = 1,
        AI2 = 2,
        AI3 = 3,
        None = 4
    }

    public enum UserType
    {
        Player = 0,
        AI1 = 1,
        AI2 = 2,
        AI3 = 3,
    }

    public enum QuickSlot
    {
        First = 0,
        Second = 1,
        Third = 2,
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
        Count,
    }

    static class GlobalVariables
    {
        public const int TileGridSize = 9;
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

        public const string TAG_PLAYER = "Player";
        public const string TAG_ENEMY = "Enemy";
        public const string TAG_GAMECONTROLLER = "GameController";
        public const string TAG_TILE = "Tile";
        public const string TAG_FIRE = "Fire";
        public const string TAG_SKILLICON = "SkillIcon";
        public const string TAG_WALL = "Wall";
        public const string TAG_MAINCAMERA = "MainCamera";

    }
}