using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Users
{
    public class BoardAI : User
    {
        private List<BoardTile> possessedTiles;
        private PriorityQueue<BoardTile> tileQueue;
        private IAIStrategy myStrategy;

        private IEnumerator Start()
        {
            myStrategy = gameObject.AddComponent<SoftStrategy>();
            possessedTiles = new List<BoardTile>();
            tileQueue = new PriorityQueue<BoardTile>();

            yield return new WaitForSeconds(0.5f);

            //PossessTile(TileManager.Instance.TileGrid[4, 4].GetComponent<BoardTile>());
        }
        
        public void FindOptimizedPath()
        {
            BoardTile targetTile = null;

            foreach (BoardTile boardTile in possessedTiles)
            {
                BoardTile searchedTile = myStrategy.CalculateTileWeight(boardTile, inventory);

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

            inventory[(int)(boardTile.TileType)].Count++;

            transform.position = new Vector3(boardTile.transform.position.x, transform.position.y, boardTile.transform.position.z);

            int[] coordX = { 1, 0, -1, -1, 0, 1 };
            int[] coordZ = { 0, 1, 1, 0, -1, -1 };

            for (int i = 0; i < 6; i++)
            {
                BoardTile targetBoardTile = TileManager.Instance.TileGrid[boardTile.TileCoordinate.x + coordX[i], boardTile.TileCoordinate.z + coordZ[i]].GetComponent<BoardTile>();

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

        protected override void ChangeItemCount(ItemData[] itemList)
        {
            for(int i = 0; i < GlobalVariables.MaxItemNumber; i++)
            {
                inventory[i].Count += itemList[i].Count;
            }
        }
    }
}
