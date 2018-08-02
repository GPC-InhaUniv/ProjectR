using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Beef,
    Iron,
    Malt,
    River,
    Soil,
    Wood,
}

public class TileManager : MonoBehaviour {

    public static TileManager TileInstance;
    
    public GameObject[,] TileGrid;

    private void Awake()
    {
        TileInstance = this;
    }

    void Start ()
    {
        TileGrid = new GameObject[9, 9];

        CreateTileGrid();
        ShowTile();
	}
	
	void CreateTileGrid()
    {
        int index = 0;

        for (int z = 0; z < 9; z++)
        {
            for (int x = 0; x < 9; x++)
            {
                if(z > - x + 3 && z < - x + 13)
                {
                    float xCoord = CalculateXcoord(x, z);
                    float zCoord = CalculateZcoord(z);
                    TileGrid[x, z] = ObjectPoolManager.ObjectPoolInstance.TileSets[index];
                    TileGrid[x, z].transform.position = new Vector3(xCoord, 0.5f, zCoord); 
                    index++;
                }
            }
        }
    }

    void ShowTile()
    {
        for (int z = 0; z < 9; z++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (z > - x + 3 && z < - x + 13)
                {
                    TileGrid[x, z].SetActive(true);
                }
            }
        }
    }

    float CalculateXcoord(float x, float z)
    {
        return (x  + z / 2) * 1.74f;
    }

    float CalculateZcoord(float z)
    {
        return z * 3 / 2f + 0.1f;
    } 

    void DropDownTile(Tile tile)
    {

    }
}
