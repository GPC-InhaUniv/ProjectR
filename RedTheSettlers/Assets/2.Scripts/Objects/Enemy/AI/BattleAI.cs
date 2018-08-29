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
        public GameTimer pathFindTimer;
        private const float pathFindTimerTick = 1.0f;
        private const float longAttackLength = 3.0f;
        private const float shortAttackLength = 1.0f;

        private int[] coordX = { 1, 1, 0, -1, -1, 0 };
        private int[] coordZ = { 0, -1, -1, 0, 1, 1 };

        public BattleAI(Enemy enemy)
        {
            this.enemy = enemy;
            openSet = new List<BattleTile>();
            closedSet = new List<BattleTile>();
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
                pathTile = null;
            }
            else if (enemy.TargetObject != null && Vector3.Distance(enemy.TargetObject.transform.position, enemy.transform.position) < longAttackLength)
            {
                if (enemy is BossEnemy && enemy.isAttackable[0])
                {
                    enemy.ChangeState(EnemyStateType.Attack1);
                }
                else if (enemy is NormalEnemy && enemy.isAttackable[1])
                {
                    enemy.ChangeState(EnemyStateType.Attack2);
                }
                pathTile = null;
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
            if (currnetTile == null)
            {
                return;
            }

            //타겟은 있는데 경로가 없는 경우
            if (enemy.TargetObject != null && pathTile == null)
            {
                BattleTile destinationTile = enemy.GetCurrentTile(enemy.TargetObject.transform.position);
                if (Vector3.Distance(enemy.TargetObject.transform.position, enemy.transform.position) < longAttackLength * 2f)
                {
                    Debug.Log("타겟은 있는데 경로가 없는 경우의 이동");
                    MoveChar(destinationTile);
                }
                else
                {
                    pathTile = null;
                    PathFinder(destinationTile);
                }
            }
            //타겟이 있고, 경로도 있는 경우
            else if (enemy.TargetObject != null && pathTile != null)
            {
                if (enemy.currentState is Idle && pathTile.Count > 0)
                {
                    Debug.Log("타겟이 있고, 경로도 있는 경우의 이동");
                    MoveChar(pathTile.Pop());
                }
                //다음 목적지가 없는 경우 도착으로 간주
                else if(pathTile.Count == 0)
                {
                    pathTile = null;
                }
            }
            //타겟이 없으면 주변을 배회한다.
            else if (enemy.TargetObject == null)
            {
                int randomCoord = Random.Range(0, coordX.Length);
                BattleTile battleTile = SearchAdjacentTiles(randomCoord);
                if (battleTile != null)
                {
                    MoveChar(battleTile);
                    Debug.Log("타겟이 없으면 주변을 배회한다.");
                }
            }
        }

        private void PathFinder(BattleTile destinationTile)
        {
            openSet.Clear();
            closedSet.Clear();

            currnetTile = enemy.GetCurrentTile(enemy.transform.position);
            startTile = currnetTile;
            startTile.ParentTileXCoord = currnetTile.TileCoordinate.x;
            startTile.ParentTileZCoord = currnetTile.TileCoordinate.z;
            endTile = destinationTile;

            do
            {
                closedSet.Add(currnetTile);

                for (int i = 0; i < coordX.Length; i++)
                {
                    BattleTile battleTile = SearchAdjacentTiles(i);

                    if (battleTile != null)
                    {
                        battleTile.g = Mathf.Abs(startTile.TileCoordinate.x - battleTile.TileCoordinate.x) + Mathf.Abs(startTile.TileCoordinate.z - battleTile.TileCoordinate.z);
                        battleTile.h = Mathf.Abs(battleTile.TileCoordinate.x - endTile.TileCoordinate.x) + Mathf.Abs(battleTile.TileCoordinate.z - endTile.TileCoordinate.z);

                        int tempG = 0;
                        if (battleTile.g < currnetTile.g)
                        {
                            tempG = currnetTile.g;
                        }
                        battleTile.f = battleTile.g + battleTile.h + tempG;

                        if (!closedSet.Contains(battleTile) && !openSet.Contains(battleTile))
                        {
                            battleTile.ParentTileXCoord = currnetTile.TileCoordinate.x;
                            battleTile.ParentTileZCoord = currnetTile.TileCoordinate.z;
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
                else return;
            }
            while (currnetTile != endTile);
            pathTile = CreateParh(startTile);
            return;
        } 
        
        private Stack<BattleTile> CreateParh(BattleTile startTile)
        {
            Stack<BattleTile> tempPathTile = new Stack<BattleTile>();
            tempPathTile.Push(currnetTile);
            BattleTile parent = TileManager.Instance.BattleTileGrid[currnetTile.ParentTileXCoord, currnetTile.ParentTileZCoord].GetComponent<BattleTile>();

            while (parent != startTile)
            {
                tempPathTile.Push(parent);
                parent = TileManager.Instance.BattleTileGrid[parent.ParentTileXCoord, parent.ParentTileZCoord].GetComponent<BattleTile>();
            }
            //tempPathTile.Push(startTile);
            //MoveChar(tempPathTile.Pop());

            return tempPathTile;
        }

        /// <summary>
        /// 인접타일 검색(매개변수로 지정된 1개 타일만 반환)
        /// </summary>
        /// <param name="coordNum"></param>
        /// <returns></returns>
        private BattleTile SearchAdjacentTiles(int coordNum)
        {
            BattleTile battleTile;
            int XPos = currnetTile.TileCoordinate.x + coordX[coordNum];
            int ZPos = currnetTile.TileCoordinate.z + coordZ[coordNum];

            if ((GlobalVariables.BattleTileGridSize > XPos && 0 < XPos)
                && (GlobalVariables.BattleTileGridSize > ZPos && 0 < ZPos))
            {
                if (TileManager.Instance.BattleTileGrid[XPos, ZPos] != null)
                {
                    battleTile = TileManager.Instance.BattleTileGrid[XPos, ZPos].GetComponent<BattleTile>();
                }
                else
                {
                    battleTile = null;
                }
            }
            else battleTile = null;

            return battleTile;
        }
    }
}
