using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public int HealthPoint;
    public int MagicPoint;
    
}

public struct SkillData
{
    public string skillName;
    public int slotNum;
}

public struct TileData
{
    
}

public class GameData
{

    public const int maxResourceNum = 30;
    public const int maxItemUpgradeLevel = 3;
    public const int maxTileUpgradeLevel = 5;

    [Header("UserData")]
    public int CowNum;
    public int WaterNum;
    public int WheatNum;
    public int WoodNum;
    public int IronNum;
    public int SoilNum;
    public int WeaponLevel;
    public int ArmorLevel;
    public int BossKillCount;
    public Tile[] PossessedTiles;
    public SkillData[] SkillDatas;
    public PlayerData PlayerStat;

    [Header("InGameData")]
    public int TurnCount;
    public int Weather;
    public int MoveCount;

}
