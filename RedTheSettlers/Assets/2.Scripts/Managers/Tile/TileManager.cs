using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;

namespace RedTheSettlers.GameSystem
{
    public class TileManager : Singleton<TileManager>
    {
        public GameObject[,] TileGrid;

        public void IntializeTileSet()
        {
            TileGrid = new GameObject[GlobalVariables.TileGridSize + 8, GlobalVariables.TileGridSize + 8];

            CreateBoardTileGrid();
            ShowTile();
        }

        public void CreateBoardTileGrid()
        {
            int index = 0;

            for (int z = 0; z < GlobalVariables.TileGridSize + 8; z++)
            {
                for (int x = 0; x < GlobalVariables.TileGridSize + 8; x++)
                {
                    if (z > -x + GlobalVariables.MinZIntercept && z < -x + GlobalVariables.MaxZIntercept)
                    {
                        float xCoord = CalculateXcoord(x, z);
                        float zCoord = CalculateZcoord(z);
                        TileGrid[x, z] = ObjectPoolManager.Instance.TileSet[index].gameObject;
                        TileGrid[x, z].transform.position = new Vector3(xCoord, 0.05f, zCoord);
                        TileGrid[x, z].GetComponent<BoardTile>().TileCoordinate = new Coordinate(x, z);
                        index++;
                    }
                }
            }
        }

        public void CreateBattleTileGrid()
        {

        }

        public void ShowTile()
        {
            for (int z = 0; z < GlobalVariables.TileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.TileGridSize; x++)
                {
                    if (z > -x + GlobalVariables.MinZIntercept && z < -x + GlobalVariables.MaxZIntercept)
                    {
                        TileGrid[x, z].SetActive(true);
                    }
                }
            }
        }

        public float CalculateXcoord(float x, float z)
        {
            return (x + z * 0.5f) * 1.74f;
        }

        public float CalculateZcoord(float z)
        {
            return z * 1.5f + 0.1f;
        }
    }
}

