using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.AI
{
    public class SoftStrategy : MonoBehaviour, IAIStrategy
    {
        public BoardTile CalculateTileWeight(BoardTile boardTile, Dictionary<TileType, int> resource)
        {
            int[] coordX = { 1, 1, 0, -1, -1, 0 };
            int[] coordZ = { 0, -1, -1, 0, 1, 1 };

            BoardTile targetBoardTile = null;

            for (int i = 0; i < 6; i++)
            {
                BoardTile comparerTile = TileManager.Instance.TileGrid[boardTile.coordinate.x + coordX[i], boardTile.coordinate.z + coordZ[i]].GetComponent<BoardTile>();

                if (comparerTile.tileOwner != TileOwner.None)
                {
                    continue;
                }

                comparerTile.CalculateTileWeight(resource);

                if (targetBoardTile == null)
                {
                    targetBoardTile = comparerTile;
                }
                else
                {
                    targetBoardTile = (targetBoardTile.tileWeight <= comparerTile.tileWeight) ? targetBoardTile : comparerTile;
                }
            }

            return targetBoardTile;
        }
    }
}
