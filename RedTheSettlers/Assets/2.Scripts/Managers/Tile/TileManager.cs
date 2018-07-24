using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public static TileManager TileInstance;
    
    public Tile[,] TileGrid;

    private void Awake()
    {
        TileInstance = this;
    }

    void Start ()
    {
        TileGrid = new Tile[9, 9];

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
                    float yCoord = CalculateZcoord(z);
                    TileGrid[x, z] = new Tile((TileType)(Random.Range(0, 7)), ObjectPoolManager.ObjectPoolInstance.TileSets[index], xCoord, yCoord);
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
                if (z > -x + 3 && z < -x + 13)
                {
                    TileGrid[x, z].tileObject.SetActive(true);
                }
            }
        }
    }

    float CalculateXcoord(float x, float z)
    {
        return (x  + z / 2) * 1.723f;
    }

    float CalculateZcoord(float z)
    {
        return z * 3 / 2f;
    }

    void DropDownTile(Tile tile)
    {

    }
    
}
