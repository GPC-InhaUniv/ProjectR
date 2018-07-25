using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {

    public static ObjectPoolManager ObjectPoolInstance;
    
    public GameObject[] TileObjects;
    public GameObject[] CloneSet;

    [HideInInspector]
    public GameObject[] TileSets;

    private void Awake()
    {
        ObjectPoolInstance = this;
        TileSets = new GameObject[61];
        for(int i = 0; i < 61; i++)
        {
            int randomTileIndex = Random.Range(0, 6);

            TileSets[i] = Instantiate(TileObjects[randomTileIndex]);
            TileSets[i].transform.parent = CloneSet[randomTileIndex].transform;
        }
    }
    
}
