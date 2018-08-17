using System;
using System.Collections.Generic;

namespace RedTheSettlers.Tiles
{
    public class BoardTile : Tile, IComparable<BoardTile>
    {

        public bool isPossessed;
        public int owner;
        public int tileWeight;

        /*
        private int resourceAmount;
        private int heuristicDistance;
        private int resourcePriority;
        */

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
