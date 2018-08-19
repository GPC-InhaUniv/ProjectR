using System;
using System.Collections.Generic;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Tiles
{
    public class BoardTile : Tile, IComparable<BoardTile>
    {
        public TileOwner tileOwner;
        public int tileWeight;

        public void CalculateTileWeight(Dictionary<TileType, int> resource)
        {
            int userResourceAmount;

            resource.TryGetValue(tileType, out userResourceAmount);

            tileWeight = userResourceAmount;
        }

        public int CompareTo(BoardTile boardTile)
        {
            return tileWeight.CompareTo(boardTile.tileWeight);
        }
    }
}
