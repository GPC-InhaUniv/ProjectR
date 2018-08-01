using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerData
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
    public string skillName;
    public int slotNum;
}

[System.Serializable]
public struct TileData
{
    public string TileName;
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
    public int MoveCount;
    public int BossKillCount;
}


public class GameData
{

    public const int maxResourceNum = 30;
    public const int maxItemUpgradeLevel = 3;
    public const int maxTileUpgradeLevel = 5;

    public PlayerData PlayerData;
    public SkillData[] SkillDatas;
    public TileData[] TileDatas;
    public ResourceData ResourceData;
    public InGameData InGameData;


}
