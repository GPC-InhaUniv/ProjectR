using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;

namespace RedTheSettlers.GameSystem
{
    public class TileManager : Singleton<TileManager>
    {
        public GameObject[,] BoardTileGrid;
        public GameObject[,] BattleTileGrid;

        public void IntializeTileSet()
        {
            BoardTileGrid = new GameObject[GlobalVariables.BoardTileGridSize, GlobalVariables.BoardTileGridSize];

            CreateBoardTileGrid();
            ShowTileBoardTile();
        }

        public void CreateBoardTileGrid()
        {
            int index = 0;

            for (int z = 0; z < GlobalVariables.BoardTileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.BoardTileGridSize; x++)
                {
                    if (z > - x + GlobalVariables.BoardTileMinZIntercept && z < -x + GlobalVariables.BoardTileMaxZIntercept)
                    {
                        float xCoord = CalculateXcoord(x, z);
                        float zCoord = CalculateZcoord(z);
                        BoardTileGrid[x, z] = ObjectPoolManager.Instance.TileSet[index].gameObject;
                        BoardTileGrid[x, z].transform.position = new Vector3(xCoord, 0.05f, zCoord);
                        BoardTileGrid[x, z].GetComponent<BoardTile>().TileCoordinate = new Coordinate(x, z);
                        index++;
                    }
                }
            }
        }

        public void CreateBattleTileGrid(ItemType itemType, int difficulty)
        {
            
        }

        public void ShowTileBoardTile()
        {
            for (int z = 0; z < GlobalVariables.BoardTileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.BoardTileGridSize; x++)
                {
                    if (z > -x + GlobalVariables.BoardTileMinZIntercept && z < -x + GlobalVariables.BoardTileMaxZIntercept)
                    {
                        BoardTileGrid[x, z].SetActive(true);
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

