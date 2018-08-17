using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

public class UITempData : MonoBehaviour {

    private GameData gameData;
    public GameData TempData()
    {
       
        gameData = new GameData(4);

        //>>Resource<<
        gameData.PlayerData[0].ItemData.CowNumber = 1;
        gameData.PlayerData[1].ItemData.CowNumber = 2;
        gameData.PlayerData[2].ItemData.CowNumber = 3;
        gameData.PlayerData[3].ItemData.CowNumber = 4;

        gameData.PlayerData[0].ItemData.WaterNumber = 5;
        gameData.PlayerData[1].ItemData.WaterNumber = 15;
        gameData.PlayerData[2].ItemData.WaterNumber = 20;
        gameData.PlayerData[3].ItemData.WaterNumber = 25;

        gameData.PlayerData[0].ItemData.WheatNumber = 5;
        gameData.PlayerData[1].ItemData.WheatNumber = 6;
        gameData.PlayerData[2].ItemData.WheatNumber = 7;
        gameData.PlayerData[3].ItemData.WheatNumber = 8;

        gameData.PlayerData[0].ItemData.WoodNumber = 2;
        gameData.PlayerData[1].ItemData.WoodNumber = 4;
        gameData.PlayerData[2].ItemData.WoodNumber = 6;
        gameData.PlayerData[3].ItemData.WoodNumber = 8;

        gameData.PlayerData[0].ItemData.IronNumber = 4;
        gameData.PlayerData[1].ItemData.IronNumber = 8;
        gameData.PlayerData[2].ItemData.IronNumber = 12;
        gameData.PlayerData[3].ItemData.IronNumber = 16;

        gameData.PlayerData[0].ItemData.SoilNumber = 3;
        gameData.PlayerData[1].ItemData.SoilNumber = 6;
        gameData.PlayerData[2].ItemData.SoilNumber = 9;
        gameData.PlayerData[3].ItemData.SoilNumber = 12;
        //<<

        //>>Equipement
        gameData.PlayerData[0].StatData.WeaponLevel = 2;
        gameData.PlayerData[1].StatData.WeaponLevel = 1;
        gameData.PlayerData[2].StatData.WeaponLevel = 3;
        gameData.PlayerData[3].StatData.WeaponLevel = 2;

        gameData.PlayerData[0].StatData.ShieldLevel = 1;
        gameData.PlayerData[1].StatData.ShieldLevel = 3;
        gameData.PlayerData[2].StatData.ShieldLevel = 2;
        gameData.PlayerData[3].StatData.ShieldLevel = 3;
        //<<

        // >>Player Tents Count And Kill Monsters Count

        TileData tileData;
        tileData.LocationX = 8;
        tileData.LocationY = 21;
        tileData.TileLevel = 2;
        tileData.TileType = ItemType.Wood;

        TileData tileData2;
        tileData2.LocationX = 8;
        tileData2.LocationY = 21;
        tileData2.TileLevel = 2;
        tileData2.TileType = ItemType.Wood;

        gameData.PlayerData[0].TileList.Add(tileData);
        gameData.PlayerData[0].TileList.Add(tileData2);
        gameData.PlayerData[1].TileList.Add(tileData);
        gameData.PlayerData[2].TileList.Add(tileData);
        gameData.PlayerData[3].TileList.Add(tileData);

        gameData.PlayerData[0].BossKillCount = 3;
        gameData.PlayerData[1].BossKillCount = 5;
        gameData.PlayerData[2].BossKillCount = 7;
        gameData.PlayerData[3].BossKillCount = 9;
        //<<
        return gameData;
    }
}
