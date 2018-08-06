using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct StatData
{
    public int HealthPoint;
    public int MagicPoint;
    public int StaminaPoint;
    public int WeaponLevel;
    public int ArmorLevel;
}

[System.Serializable]
public struct SkillData
{
    public int skillNum;
    public int slotNum;
}

[System.Serializable]
public struct TileData
{
    public TileType TileType;
    public float LocationX;
    public float LocationY;
    public int TileLevel;
}

[System.Serializable]
public struct ResourceData
{
    public int CowNum;
    public int WaterNum;
    public int WheatNum;
    public int WoodNum;
    public int IronNum;
    public int SoilNum;
}

[System.Serializable]
public struct InGameData
{
    public int TurnCount;
    public int Weather;
    public int BossKillCount;
}


/// <summary>
/// 작성자 : 박준명
/// </summary>
[System.Serializable]
public class PlayerData
{
    public StatData StatData;
    public List<SkillData> SkillList;
    public List<TileData> TileList;
    public ResourceData ResourceData;
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
[System.Serializable]
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

