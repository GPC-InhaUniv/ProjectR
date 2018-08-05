using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStrategy : MonoBehaviour {

    public BoardTile CalculateTileWeight(BoardTile boardTile, Dictionary<TileType, int> resource)
    {
        int[] coordX = { 1, 1, 0, -1, -1, 0 };
        int[] coordZ = { 0, -1, -1, 0, 1, 1 };

        BoardTile targetBoardTile = null;

        for(int i = 0; i < 6; i++)
        {
            BoardTile comparerTile = TileManager.TileInstance.TileGrid[boardTile.coordinate.x + coordX[i], boardTile.coordinate.z + coordZ[i]].GetComponent<BoardTile>();

            if(comparerTile.isPossessed == true)
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
                targetBoardTile = (targetBoardTile.tileWeight < comparerTile.tileWeight) ? targetBoardTile : comparerTile;
            }
        }

        return targetBoardTile;
    }
}
