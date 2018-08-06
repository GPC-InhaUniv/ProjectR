using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class Tile : MonoBehaviour{
    
    public TileType tileType;
    [HideInInspector]
    public Coordinate coordinate;
    public GameObject[] TileBorder = new GameObject[6];

    private void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            TileBorder[i] = transform.GetChild(i).gameObject;
        }
    }
}
