using UnityEngine;
using RedTheSettlers.Enemys;
using RedTheSettlers.Tiles;
using System.Collections;
using System.Collections.Generic;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.AI
{
    /// <summary>
    /// enemy의 행동 규칙이 정의된 클래스
    /// </summary>
    public class BattleAI
    {
        private Enemy enemy;
        private Tile startTile;
        private Tile endTile;
        private Dictionary<Tile, BattleTileNode> openSet;
        private Dictionary<Tile, BattleTileNode> closedSet;
        private BattleTileNode pathNode;
        private BattleTileNode currnetNode;

        private int[] coordX = { 1, 1, 0, -1, -1, 0 };
        private int[] coordZ = { 0, -1, -1, 0, 1, 1 };

        public BattleAI(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void AIUpdate()
        {

        }

        public void PathFinder(Enemy enemySelf = null)
        {
            openSet = new Dictionary<Tile, BattleTileNode>();
            closedSet = new Dictionary<Tile, BattleTileNode>();

            openSet.Clear();
            closedSet.Clear();
            if(enemySelf != null)
            {
                startTile = enemySelf.currentTile;
            }
            currnetNode = new BattleTileNode
            {
                tile = enemy.currentTile,
                PathCost = 0f,
                heuristicCost = 0f
            };

            closedSet.Add(currnetNode.tile, currnetNode);

            do
            {
                //배틀 타일 맵 완성 이후 이어서 제작
                for (int i = 0; i < coordX.Length; i++)
                {
                    //인근 노드(타일) 탐색

                    
                }
            } while (currnetNode.tile != startTile);
        }   
    }
}
