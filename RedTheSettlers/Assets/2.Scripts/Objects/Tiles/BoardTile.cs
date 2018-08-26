using System;
using System.Collections.Generic;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Tiles
{
    public class BoardTile : Tile, IComparable<BoardTile>
    {
        public TileOwner tileOwner;
        public int tileWeight;

        public void CalculateTileWeight(ItemData[] itemData)
        {
            int userResourceAmount;

            userResourceAmount = itemData[(int)TileType].Count;

            tileWeight = userResourceAmount;
        }

        public int CompareTo(BoardTile boardTile)
        {
            return tileWeight.CompareTo(boardTile.tileWeight);
        }
    }
}
