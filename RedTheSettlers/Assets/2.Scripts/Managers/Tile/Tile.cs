using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Water,
    Malt,
    Beef,
    Iron,
    Wood,
    Soil
}

public class Tile{

    [SerializeField]
    private TileType tileType;
    public GameObject tileObject;

    public struct Coordinate
    {
        public Coordinate(float x, float z)
        {
            this.X = x;
            this.Z = z;
        }

        public float X { get; set; }
        public float Z { get; set; }
    }

    public Tile(TileType tileType, GameObject tileObject, float x, float z)
    {
        this.tileType = tileType;
        this.tileObject = tileObject;
        Coordinate coordinate = new Coordinate(x, z);
        Vector3 tilePostion = new Vector3(coordinate.X, 0 ,coordinate.Z);
        tileObject.transform.position = tilePostion;
    }
}
