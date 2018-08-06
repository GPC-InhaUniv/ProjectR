using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIStrategy {

    BoardTile CalculateTileWeight(BoardTile boardTile, Dictionary<TileType, int> resource);
}
