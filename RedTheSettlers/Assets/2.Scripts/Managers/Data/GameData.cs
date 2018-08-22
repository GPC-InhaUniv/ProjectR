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
        public int ShieldLevel;
    }

    [Serializable]
    public struct SkillData
    {
        public int SkillNumber;
        public QuickSlot SlotNumber;
    }

    [Serializable]
    public struct TileData
    {
        public ItemType TileType;
        public float LocationX;
        public float LocationY;
        public int TileLevel;
    }

    [Serializable]
    public struct ItemData
    {
        public ItemType ItemType;
        public int Count;
    }

    [Serializable]
    public struct InGameData
    {
        public int TurnCount;
        public int Weather;
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
        public ItemData[] ItemList;
        public int BossKillCount;
        public PlayerData()
        {
            SkillList = new List<SkillData>();
            TileList = new List<TileData>();
            ItemList = new ItemData[6];
            for (int i = 0; i < 6; i++)
            {
                ItemList[i].ItemType = (ItemType)i;
            }
        }
    }

    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    [Serializable]
    public class GameData
    {
        public string UserId;
        public string UserPassword;
        public InGameData InGameData;
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

