using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAI : MonoBehaviour {

    private List<BoardTile> possessedTiles;
    private IAIStrategy myStrategy;
    private Dictionary<TileType, int> resource;

    private void Start()
    {
        myStrategy = gameObject.AddComponent<SoftStrategy>();
        possessedTiles = new List<BoardTile>();
        resource = new Dictionary<TileType, int>();
        resource.Add(TileType.Beef, 1);
        resource.Add(TileType.Iron, 2);
        resource.Add(TileType.Malt, 3);
        resource.Add(TileType.River, 4);
        resource.Add(TileType.Soil, 5);
        resource.Add(TileType.Wood, 6);
    }

    public void FindOptimizedPath()
    {
        if (possessedTiles.Count <= 0)
        {
            PossessTile(TileManager.TileInstance.TileGrid[4, 4].GetComponent<BoardTile>());
        }

        BoardTile targetTile = null;

        foreach(BoardTile boardTile in possessedTiles)
        {
            BoardTile searchedTile = myStrategy.CalculateTileWeight(boardTile , resource);

            if(targetTile == null)
            {
                targetTile = searchedTile;
            }
            else
            {
                targetTile = (targetTile.tileWeight < searchedTile.tileWeight) ? targetTile : searchedTile;
            }
        }

        PossessTile(targetTile);
    }

    public void PossessTile(BoardTile boardTile)
    {
        boardTile.owner = 1;
        boardTile.isPossessed = true;
        possessedTiles.Add(boardTile);

        resource[boardTile.tileType]++;

        transform.position = new Vector3(boardTile.transform.position.x, transform.position.y, boardTile.transform.position.z);

        int[] coordX = { 1, 0, -1, -1, 0, 1 };
        int[] coordZ = { 0, 1, 1, 0, -1, -1 };

        for (int i = 0; i < 6; i++)
        {
            if(TileManager.TileInstance.TileGrid[boardTile.coordinate.x + coordX[i], boardTile.coordinate.z + coordZ[i]].GetComponent<BoardTile>().isPossessed == true)
            {
                boardTile.TileBorder[i].SetActive(false);
                TileManager.TileInstance.TileGrid[boardTile.coordinate.x + coordX[i], boardTile.coordinate.z + coordZ[i]].GetComponent<BoardTile>().TileBorder[(i + 3) % 6].SetActive(false);
            }
            else
            {
                boardTile.TileBorder[i].SetActive(true);
            }
        }
    }
}
