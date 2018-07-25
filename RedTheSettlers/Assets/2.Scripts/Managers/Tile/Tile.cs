using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    [SerializeField]
    private TileType tileType;

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
}
