﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Users
{
    public class BoardAI : User
    {
        private PriorityQueue<BoardTile> tileQueue;
        private IAIStrategy myStrategy;
        public Queue<string> MessageQueue;

        public delegate Queue<string> AITurnEndDelegate();
        public AITurnEndDelegate AITurnEndCallBack;

        private IEnumerator Start()
        {
            myStrategy = gameObject.AddComponent<SoftStrategy>();
            tileQueue = new PriorityQueue<BoardTile>();
            MessageQueue = new Queue<string>();

            yield return null;
        }
        
        public void FindOptimizedPath()
        {
            BoardTile targetTile = null;

            foreach (BoardTile boardTile in PossessingTile)
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

            MessageQueue.Enqueue("점령할 타일을 찾습니다...");

            PossessTile(targetTile);

            AITurnEndCallBack();
        }

        public void PossessTile(BoardTile boardTile)
        {
            boardTile.tileOwner = TileOwner.AI1;
            PossessingTile.Add(boardTile);

            inventory[(int)(boardTile.TileType)].Count++;

            transform.position = new Vector3(boardTile.transform.position.x, transform.position.y, boardTile.transform.position.z);

            int[] coordX = { 1, 0, -1, -1, 0, 1 };
            int[] coordZ = { 0, 1, 1, 0, -1, -1 };

            for (int i = 0; i < 6; i++)
            {
                BoardTile targetBoardTile = TileManager.Instance.BoardTileGrid[boardTile.TileCoordinate.x + coordX[i], boardTile.TileCoordinate.z + coordZ[i]].GetComponent<BoardTile>();

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

            MessageQueue.Enqueue(boardTile.TileType.ToString() + "타일을 점령했습니다");
        }

        public override void ChangeItemCount(ItemData[] itemList)
        {
            for(int i = 0; i < GlobalVariables.MaxItemNumber; i++)
            {
                inventory[i].Count += itemList[i].Count;
            }
        }
    }
}
