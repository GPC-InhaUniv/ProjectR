using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Coordinate
{
    public Coordinate(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public int x;
    public int z;
}

public class Tile : MonoBehaviour{

    [SerializeField]
    public TileType tileType;
    public Coordinate coordinate;
    
}
