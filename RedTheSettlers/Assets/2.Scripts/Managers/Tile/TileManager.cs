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

        private void Awake()
        {
            BoardTileGrid = new GameObject[GlobalVariables.BoardTileGridSize, GlobalVariables.BoardTileGridSize];
            BattleTileGrid = new GameObject[GlobalVariables.BattleTileGridSize, GlobalVariables.BattleTileGridSize];
        }

        public void InitializeTileSet()
        {
            CreateBoardTileGrid();
            ShowBoardTile();
            CreateBattleTileGrid(ItemType.Cow, 1);
            ShowBattleTile();
        }
        
        public void LoadTileGrid()
        {
            int maxCount = DataManager.Instance.GameData.InGameData.BoardTileList.Length;

            PlayerData[] playerData = DataManager.Instance.GameData.PlayerData;

            for(int i = 0; i < maxCount; i++)
            {
                TileData tileData = DataManager.Instance.GameData.InGameData.BoardTileList[i];

                int x = tileData.LocationX;
                int z = tileData.LocationY;
                BoardTileGrid[x, z] = ObjectPoolManager.Instance.TileObjectPool.PopBoardTile(tileData.TileType);
                BoardTileGrid[x, z].GetComponent<BoardTile>().TileLevel = tileData.TileLevel;
                for(int j = 0; j < playerData.Length; j++)
                {
                    for(int k = 0; k < playerData[j].TileList.Count; k++)
                    {
                    
                    }
                }
            }
        }

        public void CreateBoardTileGrid()
        {
            for (int z = 0; z < GlobalVariables.BoardTileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.BoardTileGridSize; x++)
                {
                    if (z > - x + GlobalVariables.BoardTileMinZIntercept && z < -x + GlobalVariables.BoardTileMaxZIntercept)
                    {
                        float xCoord = CalculateXcoord(x, z);
                        float zCoord = CalculateZcoord(z);
                        BoardTileGrid[x, z] = ObjectPoolManager.Instance.TileObjectPool.PopBoardTile((ItemType)Random.Range(0, 6));
                        BoardTileGrid[x, z].transform.position = new Vector3(xCoord, 0.05f, zCoord);
                        BoardTileGrid[x, z].GetComponent<BoardTile>().TileCoordinate = new Coordinate(x, z);
                    }
                }
            }
        }

        public void CreateBattleTileGrid(ItemType itemType, int difficulty)
        {
            for (int z = 0; z < GlobalVariables.BattleTileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.BattleTileGridSize; x++)
                {
                    if (z > - x + GlobalVariables.BattleTileMinZIntercept && z < - x + GlobalVariables.BattleTileMaxZIntercept)
                    {
                        float xCoord = CalculateXcoord(x, z) + GlobalVariables.BattleAreaOriginCoord;
                        float zCoord = CalculateZcoord(z) + GlobalVariables.BattleAreaOriginCoord;
                        BattleTileGrid[x, z] = ObjectPoolManager.Instance.TileObjectPool.PopBattleTile(itemType);
                        BattleTileGrid[x, z].transform.position = new Vector3(xCoord, 0.05f, zCoord);
                        BattleTileGrid[x, z].GetComponent<BattleTile>().TileCoordinate = new Coordinate(x, z);
                    }
                }
            }
        }

        public void ShowBoardTile()
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

        public void ShowBattleTile()
        {
            for (int z = 0; z < GlobalVariables.BattleTileGridSize; z++)
            {
                for (int x = 0; x < GlobalVariables.BattleTileGridSize; x++)
                {
                    if (z > -x + GlobalVariables.BattleTileMinZIntercept && z < -x + GlobalVariables.BattleTileMaxZIntercept)
                    {
                        BattleTileGrid[x, z].SetActive(true);
                    }
                }
            }
        }

        public void ClearBattleTileGrid()
        {

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

