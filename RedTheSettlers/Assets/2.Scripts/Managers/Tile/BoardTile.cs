using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : Tile {
    
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
}
