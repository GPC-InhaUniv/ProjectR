using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Tiles
{
    public enum TileType
    {
        Beef,
        Iron,
        Malt,
        River,
        Soil,
        Wood,
    }

    [System.Serializable]
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

    public class Tile : MonoBehaviour
    {
        private const int tileTypeAmount = 6;

        public TileType tileType;
        [HideInInspector]
        public Coordinate coordinate;
        [HideInInspector]
        public GameObject[] TileBorder = new GameObject[6];

        private void Start()
        {
            for (int i = 0; i < tileTypeAmount; i++)
            {
                TileBorder[i] = transform.GetChild(i).gameObject;
            }
        }
    }
}
