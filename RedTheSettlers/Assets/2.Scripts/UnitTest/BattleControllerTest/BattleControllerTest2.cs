using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public class BattleControllerTest2 : MonoBehaviour
    {
        public GameObject Cattle;

        GameTimer cattlesTimer, battleTimer;
        float cattleResawnTime = 100; // second

        private void Start()
        {
            //cattlesTimer = GameTimeManager.Instance.PopTimer();
            //cattlesTimer.SetTimer(cattleResawnTime, true);
            //cattlesTimer.Callback = new TimerCallback(SpawnHerdOfCattles);

            //battleTimer = GameTimeManager.Instance.PopTimer();


            //cattlesTimer.StartTimer();
        }

        // GameMAnager에서 어떤 타일인지 받아옴
        public void BattleFlow(ItemType tlieType)
        {
            // diffucltcontroller에서 받아가야함
            //ItemType tileType = diffcultyManagertest.Instance.tileType;
            //if (tileType == ItemType.Cow) SpawnHerdOfCattles();
            
            // DataManager에 전투 결과 반영
            //yield return new WaitForSeconds(3);
        }

        // 일정 시간마다 소 떼가 등장한다.
        private void SpawnHerdOfCattles()
        {
            Quaternion angle = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            Vector3 spawnPoint = new Vector3
            (
                TileManager.Instance.BattleTileGrid[Random.Range(1, 14), Random.Range(1, 14)].transform.position.x + GlobalVariables.BattleAreaOriginCoord,
                0,
                TileManager.Instance.BattleTileGrid[Random.Range(1, 14), Random.Range(1, 14)].transform.position.z + GlobalVariables.BattleAreaOriginCoord
            );
            GameObject cow = ObjectPoolManager.Instance.CowObject;

            cow.transform.position = spawnPoint;
            cow.transform.rotation = angle;
        }

        /// <summary>
        /// Test용 코드. SpawnHerdOfCattles()가 원본
        /// </summary>
        public void SpawnCattleTest()
        {
            Quaternion angle = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            GameObject cow = Instantiate(Cattle);
            cow.transform.position = spawnPoint;
            cow.transform.rotation = angle;
        }

        /// <summary>
        /// 적을 모두 쓰러트리면 전투가 종료된다. 
        /// </summary>
        public void BattleClear()
        {
            cattlesTimer.StopTimer();
            GameTimeManager.Instance.PushTimer(cattlesTimer);
        }
    }
}