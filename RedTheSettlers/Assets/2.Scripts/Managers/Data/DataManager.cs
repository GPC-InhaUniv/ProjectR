using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {
    GameData gameData;


    private void Start()
    {
        gameData = new GameData();
        gameData.WaterNum = 1;
        
    }
}
