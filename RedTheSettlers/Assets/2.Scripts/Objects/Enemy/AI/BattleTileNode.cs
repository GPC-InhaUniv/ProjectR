using RedTheSettlers.Tiles;

namespace RedTheSettlers.Enemys
{
    public class BattleTileNode
    {
        public BattleTileNode parent;
        public float TotalCost, PathCost, heuristicCost;
        public Tile tile;
    }
}

