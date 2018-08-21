using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.AI
{
    public class BoardAI : MonoBehaviour
    {
        private List<BoardTile> possessedTiles;
        private PriorityQueue<BoardTile> tileQueue;
        private IAIStrategy myStrategy;
        private Dictionary<TileType, int> resource;
        private ItemData itemData;

        private IEnumerator Start()
        {
            myStrategy = gameObject.AddComponent<SoftStrategy>();
            possessedTiles = new List<BoardTile>();
            tileQueue = new PriorityQueue<BoardTile>();

            resource = new Dictionary<TileType, int>();
            resource.Add(TileType.Cow, 1);
            resource.Add(TileType.Iron, 2);
            resource.Add(TileType.Soil, 3);
            resource.Add(TileType.Water, 4);
            resource.Add(TileType.Wheat, 5);
            resource.Add(TileType.Wood, 6);

            yield return new WaitForSeconds(0.5f);

            //PossessTile(TileManager.Instance.TileGrid[4, 4].GetComponent<BoardTile>());
        }
        
        public Dictionary<TileType, int> SendTradeData()
        {
            Dictionary<TileType, int> tradeData = new Dictionary<TileType, int>();

            return tradeData;
        }
        
        public void FindOptimizedPath()
        {
            BoardTile targetTile = null;

            foreach (BoardTile boardTile in possessedTiles)
            {
                BoardTile searchedTile = myStrategy.CalculateTileWeight(boardTile, resource);

                if (targetTile == null)
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
            boardTile.tileOwner = TileOwner.AI1;
            possessedTiles.Add(boardTile);

            resource[boardTile.tileType]++;

            transform.position = new Vector3(boardTile.transform.position.x, transform.position.y, boardTile.transform.position.z);

            int[] coordX = { 1, 0, -1, -1, 0, 1 };
            int[] coordZ = { 0, 1, 1, 0, -1, -1 };

            for (int i = 0; i < 6; i++)
            {
                BoardTile targetBoardTile = TileManager.Instance.TileGrid[boardTile.coordinate.x + coordX[i], boardTile.coordinate.z + coordZ[i]].GetComponent<BoardTile>();

                if (targetBoardTile.tileOwner == TileOwner.AI1)
                {
                    boardTile.TileBorder[i].SetActive(false);
                    targetBoardTile.TileBorder[(i + 3) % 6].SetActive(false);
                }
                else
                {
                    boardTile.TileBorder[i].SetActive(true);
                }
            }

        }
    }
}
