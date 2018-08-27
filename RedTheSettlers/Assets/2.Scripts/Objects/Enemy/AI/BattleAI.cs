using UnityEngine;
using RedTheSettlers.Tiles;
using System.Collections;
using System.Collections.Generic;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;

namespace RedTheSettlers.Enemys
{
    /// <summary>
    /// enemy의 행동 규칙이 정의된 클래스
    /// </summary>
    public class BattleAI
    {
        private Enemy enemy;
        private BattleTile startTile;
        private BattleTile endTile;
        private List<BattleTile> openSet;
        private List<BattleTile> closedSet;
        private Stack<BattleTile> pathTile;
        private BattleTile currnetTile;
        private GameTimer pathFindTimer;
        private const float pathFindTimerTick = 3.0f;
        private const float longAttackLength = 3.0f;
        private const float shortAttackLength = 1.0f;

        private int[] coordX = { 1, 1, 0, -1, -1, 0 };
        private int[] coordZ = { 0, -1, -1, 0, 1, 1 };

        public BattleAI(Enemy enemy)
        {
            this.enemy = enemy;
            pathFindTimer = GameTimeManager.Instance.PopTimer();
            pathFindTimer.SetTimer(pathFindTimerTick, true);
            pathFindTimer.Callback = new TimerCallback(FindTartget);
            pathFindTimer.StartTimer();
        }

        public void AIUpdate()
        {
            if (enemy.TargetObject != null && Vector3.Distance(enemy.TargetObject.transform.position, enemy.transform.position) < shortAttackLength)
            {
                if (enemy is BossEnemy && enemy.isAttackable[1])
                {
                    enemy.ChangeState(EnemyStateType.Attack2);
                }

                else if (enemy is NormalEnemy && enemy.isAttackable[0])
                {
                    enemy.ChangeState(EnemyStateType.Attack1);
                }
            }

            else if (enemy.TargetObject != null && Vector3.Distance(enemy.TargetObject.transform.position, enemy.transform.position) < longAttackLength)
            {
                if (enemy is BossEnemy && enemy.isAttackable[0])
                {
                    enemy.ChangeState(EnemyStateType.Attack1);
                }

                else if(enemy is NormalEnemy && enemy.isAttackable[1])
                {
                    enemy.ChangeState(EnemyStateType.Attack2);
                }
            }
        }

        private void MoveChar(BattleTile destination)
        {
            enemy.destinationPoint = destination.gameObject.transform.position;
            enemy.ChangeState(EnemyStateType.Move);
        }

        private void FindTartget()
        {
            currnetTile = enemy.GetCurrentTile(enemy.transform.position);

            //타겟은 있는데 경로가 없는 경우
            if (enemy.TargetObject != null && pathTile == null)
            {
                BattleTile destinationTile = enemy.GetCurrentTile(enemy.TargetObject.transform.position);
                PathFinder(destinationTile);
            }
            //타겟이 있고, 경로도 있는 경우
            else if (enemy.TargetObject != null && pathTile != null)
            {
                BattleTile destination = pathTile.Peek();

                //현재 위치가 목적지랑 같은 경우 다음 목적지로 이동
                if (destination == currnetTile)
                {
                    MoveChar(pathTile.Pop());
                }
            }
            //타겟이 없으면 주변을 배회한다.
            else if (enemy.TargetObject == null)
            {
                int randomCoord = Random.Range(0, coordX.Length);
                int XPos = currnetTile.TileCoordinate.x + coordX[randomCoord];
                int ZPos = currnetTile.TileCoordinate.z + coordZ[randomCoord];
                BattleTile battleTile;

                if ((GlobalVariables.BattleTileGridSize > XPos && 0 < XPos)
                    && (GlobalVariables.BattleTileGridSize > ZPos && 0 < ZPos))
                {
                    battleTile = TileManager.Instance.BattleTileGrid[XPos, ZPos].GetComponent<BattleTile>();
                    MoveChar(battleTile);
                }
            }
        }

        private void PathFinder(BattleTile destinationTile)
        {
            openSet = new List<BattleTile>();
            closedSet = new List<BattleTile>();

            openSet.Clear();
            closedSet.Clear();

            currnetTile = enemy.GetCurrentTile(enemy.transform.position);
            startTile = currnetTile;
            endTile = destinationTile;

            do
            {
                closedSet.Add(currnetTile);

                for (int i = 0; i < coordX.Length; i++)
                {
                    int XPos = currnetTile.TileCoordinate.x + coordX[i];
                    int ZPos = currnetTile.TileCoordinate.z + coordZ[i];
                    BattleTile battleTile;

                    if ((GlobalVariables.BattleTileGridSize > XPos && 0 < XPos)
                        && (GlobalVariables.BattleTileGridSize > ZPos && 0 < ZPos))
                    {
                        battleTile = TileManager.Instance.BattleTileGrid[XPos, ZPos].GetComponent<BattleTile>();
                    }
                    else battleTile = null;                    

                    if (battleTile != null)
                    {
                        battleTile.g = (startTile.TileCoordinate.x - battleTile.TileCoordinate.x) + (startTile.TileCoordinate.z - battleTile.TileCoordinate.z);
                        battleTile.h = (battleTile.TileCoordinate.x - endTile.TileCoordinate.x) + (battleTile.TileCoordinate.z - endTile.TileCoordinate.z);
                        battleTile.f = battleTile.g + battleTile.f;

                        battleTile.ParentTileXCoord = currnetTile.TileCoordinate.x;
                        battleTile.ParentTileZcoord = currnetTile.TileCoordinate.z;

                        if (battleTile.g < currnetTile.g)
                        {
                            battleTile.f += currnetTile.g;
                        }

                        if(!closedSet.Contains(battleTile))
                        {
                            openSet.Add(battleTile);
                        }

                        if (openSet.Count > 1)
                        {
                            openSet.Sort(delegate (BattleTile a, BattleTile b)
                            {
                                if (a.f > b.f) return 1;
                                else if (a.f < b.f) return -1;
                                return 0;
                            });
                        }
                    }
                }

                if (openSet.Count > 0)
                {
                    currnetTile = openSet[0];
                    openSet.Remove(currnetTile);
                }
                else break;

                if (currnetTile == endTile)
                {
                    CreateParh();
                }
            }
            while (currnetTile != startTile);
        } 
        
        private Stack<BattleTile> CreateParh()
        {
            pathTile = new Stack<BattleTile>();
            pathTile.Push(currnetTile);

            BattleTile parent = TileManager.Instance.BattleTileGrid[currnetTile.ParentTileXCoord, currnetTile.ParentTileZcoord].GetComponent<BattleTile>();
            while (parent != null)
            {
                pathTile.Push(parent);
                parent = TileManager.Instance.BattleTileGrid[parent.ParentTileXCoord, parent.ParentTileZcoord].GetComponent<BattleTile>();
            }

            return pathTile;
        }
    }
}
