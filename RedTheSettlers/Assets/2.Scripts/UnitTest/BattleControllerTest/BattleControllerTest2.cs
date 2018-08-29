using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public class BattleControllerTest2 : MonoBehaviour
    {
        float cattleResawnTime = 5; // test용
        //////   테스트용 변수 ////////////////

        private GameTimer cattlesTimer;

        [SerializeField]
        private int aliveEnemyCount; // 어디에서 받아와야하지? 
        public int AliveEnemyCount { set { aliveEnemyCount = value; } }
        //private float cattleResawnTime = 100; // second

        private void Start()
        {
            // 나중에 삭제
            BattleFlow(ItemType.Cow);
        }

        // tileType : GameMAnager에서 어떤 타일인지 받아옴 
        public void BattleFlow(ItemType tileType)
        {
            if (tileType == ItemType.Cow)
            {
                LogManager.Instance.UserDebug(LogColor.Orange, GetType().ToString(), "Cow 타이머 시작");

                cattlesTimer = GameTimeManager.Instance.PopTimer();
                cattlesTimer.SetTimer(cattleResawnTime, true);
                //cattlesTimer.Callback = new TimerCallback(SpawnHerdOfCattles);


                cattlesTimer.Callback = new TimerCallback(SpawnCattleTest); // 테스트용

                cattlesTimer.StartTimer();
            }

            if (aliveEnemyCount == 0) BattleClear();
        }

        // 일정 시간마다 소 떼가 등장한다.
        private void SpawnHerdOfCattles()
        {
            LogManager.Instance.UserDebug(LogColor.Orange, GetType().ToString(), "소 떼 출현");

            Quaternion angle = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            Vector3 spawnPoint = new Vector3
            (
                TileManager.Instance.BattleTileGrid[Random.Range(1, 14), Random.Range(1, 14)].transform.position.x + GlobalVariables.BattleAreaOriginCoord,
                0,
                TileManager.Instance.BattleTileGrid[Random.Range(1, 14), Random.Range(1, 14)].transform.position.z + GlobalVariables.BattleAreaOriginCoord
            );

            GameObject cows = ObjectPoolManager.Instance.CowObject;
            cows.transform.position = spawnPoint;
            cows.transform.rotation = angle;
        }

        /// 적을 모두 쓰러트리면 전투가 종료된다. 
        private void BattleClear()
        {
            LogManager.Instance.UserDebug(LogColor.Orange, GetType().ToString(), "전투 종료");

            cattlesTimer.StopTimer();
            GameTimeManager.Instance.PushTimer(cattlesTimer);

            // DataManager에 전투 결과 반영
            // 데이터매니저에 어떤 정보를 넘겨줘야??
        }

        /// <summary>
        /// Test용 코드. SpawnHerdOfCattles()가 원본
        /// </summary>
        public void SpawnCattleTest()
        {
            Quaternion angle = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            Vector3 spawnPoint = new Vector3(0, 0, 0);

            GameObject cowsTest = ObjectPoolManager.Instance.CowObject;
            cowsTest.transform.position = spawnPoint;
            cowsTest.transform.rotation = angle;
        }
    }
}