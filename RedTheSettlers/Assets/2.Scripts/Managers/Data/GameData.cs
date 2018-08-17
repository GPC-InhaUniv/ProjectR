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
        public int skillNumber;
        public int slotNumber;
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
        public int CowNumber;
        public int WaterNumber;
        public int WheatNumber;
        public int WoodNumber;
        public int IronNumber;
        public int SoilNumber;
        public int MaxItemNumber;
        public int SumOfItem
        {
            get { return CowNumber + WaterNumber + WheatNumber + WoodNumber + IronNumber + SoilNumber; }
        }
        private int[] itemList;
        public int GetMaxItemNumber()
        {
            itemList = new int[6];
            itemList[0] = CowNumber;
            itemList[1] = WaterNumber;
            itemList[2] = WheatNumber;
            itemList[3] = WoodNumber;
            itemList[4] = IronNumber;
            itemList[5] = SoilNumber;
            Array.Sort(itemList);
            return itemList[5];

        }  
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
        public ItemData ItemData;
        public int BossKillCount;


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

