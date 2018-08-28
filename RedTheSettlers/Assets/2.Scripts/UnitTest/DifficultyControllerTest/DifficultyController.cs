using RedTheSettlers.Enemys;
using RedTheSettlers.Tiles;
using RedTheSettlers.Users;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RedTheSettlers.GameSystem
{
    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class DifficultyController : MonoBehaviour
    {
        private BattleLevel level;
        private ItemType tileType;

        private IEnumerator SendBattleLevel()
        {
            TileManager.Instance.CreateBattleTileGrid(tileType, (int)level);
            yield return null;
        }      
        
        /// <summary>
        /// DifficultyController의 기능이 시작되는 메인 코루틴.
        /// </summary>
        /// <param name="selectionTile"></param>
        /// <param name="PossessingTileList"></param>
        /// <returns></returns>
        public IEnumerator EstablishBattleStage(Tile selectionTile, List<Tile> PossessingTileList)
        {
            judgeLevel(selectionTile, PossessingTileList);
            yield return StartCoroutine(SendBattleLevel());
            DisposePlayerAndEnemy(true); //후에 타일클래스에 구분 bool타입 변수 생기면 변경 예정 true - > selectionTile.isBossTile
        }
        
        private void judgeLevel(Tile selectionTile, List<Tile> PossessingTileList)
        {
            tileType = selectionTile.TileType;
            int count = 0;
            for (int i = 0; i < PossessingTileList.Count; i++)
            {
                if (PossessingTileList[i].TileType == selectionTile.TileType)
                    count++;
            }
            if (count < 2)
            {
                level = BattleLevel.Level1;
            }
            else if (count == 2 || count == 3)
            {
                level = BattleLevel.Level2;
            }
            else
                level = BattleLevel.Level3;
        }

        private void DisposePlayerAndEnemy(bool isBossTile)
        {
            Vector3 playerSpotPosition = new Vector3
                (
                TileManager.Instance.BattleTileGrid[13, 1].transform.position.x + GlobalVariables.BattleAreaOriginCoord, 0,
                TileManager.Instance.BattleTileGrid[13, 1].transform.position.z + GlobalVariables.BattleAreaOriginCoord
                );
            Vector3 enemySpotPosition = new Vector3
                (
                TileManager.Instance.BattleTileGrid[1, 13].transform.position.x + GlobalVariables.BattleAreaOriginCoord, 0,
                TileManager.Instance.BattleTileGrid[1, 13].transform.position.z + GlobalVariables.BattleAreaOriginCoord
                );
            GameObject player = new GameObject();
            player.transform.position = playerSpotPosition;
            player.SetActive(true);
            List<GameObject> enemyList = new List<GameObject>();
            if (isBossTile)
            {
                enemyList.Add(new GameObject());                                       //Boss도 구현되는 방향에 따라 가져올 예정.
                //enemyList[0].GetComponent<BossEnemy>()
            }
            else
            {
                for (int i = 0; i <= (int)level; i++)
                {
                    //ObjectPoolManager.Instance.EnemyPool[(int)tileType].Dequeue();   ObjectManager에서 리스트 큐 형식으로만 쓴다면 이렇게.
                    //ObjectPoolManager.Instance.EnemyPool.Pop((int)tileType);         ObjectManager에서 Push(),Pop() 함수를 만든다면 이렇게.
                }
            }
            for(int i = 0; i < enemyList.Count; i ++)
            {
                if (i == 0)
                    enemyList[i].transform.position = enemySpotPosition;
                else if (i % 2 == 1)
                {
                    enemySpotPosition.x += 2;
                    enemySpotPosition.z += 2;
                    enemyList[i].transform.position = enemySpotPosition;
                }                
                else if(i % 2 == 0)
                {
                    enemySpotPosition.x = -enemySpotPosition.x;
                    enemySpotPosition.z = -enemySpotPosition.z;
                    enemyList[i].transform.position = enemySpotPosition;
                }
                enemyList[i].SetActive(true);
            }
        }

        /*
        DifficultyController가 해야할 일.
        1. 소유 타일에 따라 정해진 난이도를 타일 매니저에 보내줌.

        2. 플레이어가 소유하고 있는 동일한 타일 갯수마다 몬스터 스탯 및 수 증가.

        3. 보스타일일 경우엔 선택 타일이 아닌 랜덤으로 타일이 배치됨
         - 소,물,밀,철,흙,나무 중 아무거나
         - 보스의 위치는 고정.

         */
    }
}
