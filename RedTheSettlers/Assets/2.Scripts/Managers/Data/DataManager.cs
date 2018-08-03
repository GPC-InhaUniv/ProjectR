using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public GameData GameData;
    public GameDataLoader GameDataLoader;

    // Use this for initialization
    void Awake()
    {
        GameData = new GameData();


    }



}
