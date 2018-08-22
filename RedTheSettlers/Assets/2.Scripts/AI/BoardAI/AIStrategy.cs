using RedTheSettlers.Tiles;
using System.Collections.Generic;

namespace RedTheSettlers.Users
{
    public interface IAIStrategy
    {
        BoardTile CalculateTileWeight(BoardTile boardTile, Dictionary<TileType, int> resource);
    }
}
