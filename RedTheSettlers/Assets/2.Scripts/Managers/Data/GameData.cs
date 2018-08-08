using System.Collections.Generic;
using System;
using RedTheSettlers.Tiles;

namespace RedTheSettlers.GameSystem
{
    [Serializable]
    public struct StatData
    {
        public int HealthPoint;
        public int MagicPoint;
        public int StaminaPoint;
        public int WeaponLevel;
        public int ArmorLevel;
    }

    [Serializable]
    public struct SkillData
    {
        public int skillNumber;
        public int slotNumber;
    }

    [Serializable]
    public struct TileData
    {
        public TileType TileType;
        public float LocationX;
        public float LocationY;
        public int TileLevel;
    }

    [Serializable]
    public struct ItemData
    {
        public int CowNumber;
        public int WaterNumber;
        public int WheatNumber;
        public int WoodNumber;
        public int IronNumber;
        public int SoilNumber;
    }

    [Serializable]
    public struct InGameData
    {
        public int TurnCount;
        public int Weather;
        public int BossKillCount;
    }


    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public StatData StatData;
        public List<SkillData> SkillList;
        public List<TileData> TileList;
        public ItemData ResourceData;
        public InGameData InGameData;

        public PlayerData()
        {
            SkillList = new List<SkillData>();
            TileList = new List<TileData>();
        }
    }

    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    [Serializable]
    public class GameData
    {
        public const int maxResourceNum = 30;
        public const int maxItemUpgradeLevel = 3;
        public const int maxTileUpgradeLevel = 5;

        public string UserId;
        public string UserPassword;
        public PlayerData[] PlayerData;

        public GameData(int numberOfPlayer)
        {
            PlayerData = new PlayerData[numberOfPlayer];

            for (int i = 0; i < PlayerData.Length; i++)
            {
                PlayerData[i] = new PlayerData();
            }
        }

    }
}

