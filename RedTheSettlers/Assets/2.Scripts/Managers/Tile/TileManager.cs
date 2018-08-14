using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;

namespace RedTheSettlers.GameSystem
{
    public class TileManager : Singleton<TileManager>
    {

        public GameObject[,] TileGrid;

        void Start()
        {
            TileGrid = new GameObject[GlobalVariables.tileGridSize, GlobalVariables.tileGridSize];

            CreateTileGrid();
            ShowTile();
        }

        void CreateTileGrid()
        {
            int index = 0;

            for (int z = 0; z < GlobalVariables.tileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.tileGridSize; x++)
                {
                    if (z > -x + GlobalVariables.minZIntercept && z < -x + GlobalVariables.maxZIntercept)
                    {
                        float xCoord = CalculateXcoord(x, z);
                        float zCoord = CalculateZcoord(z);
                        TileGrid[x, z] = ObjectPoolManager.Instance.TileSet[index].gameObject;
                        TileGrid[x, z].transform.position = new Vector3(xCoord, 0.05f, zCoord);
                        TileGrid[x, z].GetComponent<BoardTile>().coordinate = new Coordinate(x, z);
                        index++;
                    }
                }
            }
        }

        void ShowTile()
        {
            for (int z = 0; z < GlobalVariables.tileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.tileGridSize; x++)
                {
                    if (z > -x + GlobalVariables.minZIntercept && z < -x + GlobalVariables.maxZIntercept)
                    {
                        TileGrid[x, z].SetActive(true);
                    }
                }
            }
        }

        float CalculateXcoord(float x, float z)
        {
            return (x + z * 0.5f) * 1.74f;
        }

        float CalculateZcoord(float z)
        {
            return z * 1.5f + 0.1f;
        }

    }
}

