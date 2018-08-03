using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class DataManager : Singleton<DataManager>
{
    public GameData GameData;
    public GameDataLoader GameDataLoader;
    // Use this for initialization
    void Awake()
    {
        GameData = new GameData(4);

        string json = JsonUtility.ToJson(GameData);
        Debug.Log(json);
    }

    



}
