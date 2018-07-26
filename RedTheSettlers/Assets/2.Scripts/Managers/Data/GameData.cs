using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Resource
{
    public int CowNum;
    public int WaterNum;
    public int WheatNum;
    public int WoodNum;
    public int IronNum;
    public int SoilNum;
}



public class GameData
{
    
    public const int maxHpLevel = 10;
    public const int maxBulletLevel = 20;
    public const int maxCritLevel = 20;
    public const int maxTotalLevel = 50;

    [Header("UserData")]
    public int WeaponLevel;
    public int ArmorLevel;
    public int HaveTileNum;
    public int BossKillCount;
    

    [Header("InGameData")]
    public int TurnCount;
    public int Weather;
}
