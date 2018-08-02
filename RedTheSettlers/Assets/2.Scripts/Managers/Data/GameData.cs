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

[System.Serializable]
public struct AssetBundleData
{
    public Hash128 Player;
    public Hash128 Skill;
    public Hash128 Enemey;
    public Hash128 FirstBoss;
    public Hash128 SecondBoss;
    public Hash128 ThirdBoss;
    public Hash128 UI;
    public Hash128 Tile;

}


public class GameData
{

    public const int maxResourceNum = 30;
    public const int maxItemUpgradeLevel = 3;
    public const int maxTileUpgradeLevel = 5;

    public string PlayerPassword;
    public PlayerData PlayerData;
    public List<SkillData> SkillList;
    public List<TileData> TileList;
    public ResourceData ResourceData;
    public InGameData InGameData;

    public GameData()
    {
        SkillList = new List<SkillData>();
        TileList = new List<TileData>();
    }


}