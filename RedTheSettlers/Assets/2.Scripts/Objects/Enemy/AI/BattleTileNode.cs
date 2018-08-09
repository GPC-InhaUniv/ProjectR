using RedTheSettlers.Tiles;

namespace RedTheSettlers.AI
{
    public class BattleTileNode
    {
        public BattleTileNode parent;
        public float TotalCost, PathCost, heuristicCost;
        public Tile tile;
    }
}

