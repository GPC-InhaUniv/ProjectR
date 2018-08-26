using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    class diffcultyManagertest : Singleton<diffcultyManagertest>
    {
        public ItemType tileType;
        public int maxEnemyCount;
    }

    public class BattleControllerTest2 : MonoBehaviour
    {
        GameTimer cattlesTimer, battleTimer;
        float cattleResawnTime = 100; // second

        private void Start()
        {
            //cattlesTimer = GameTimeManager.Instance.PopTimer();
            //cattlesTimer.SetTimer(cattleResawnTime, true);
            //cattlesTimer.Callback = new TimerCallback(SpawnHerdOfCattle);

            //battleTimer = GameTimeManager.Instance.PopTimer();


            //cattlesTimer.StartTimer();
        }

        public IEnumerator BattleFlow()
        {
            ItemType tileType = diffcultyManagertest.Instance.tileType;
            if (tileType == ItemType.Cow) SpawnHerdOfCattle();
            
            // DataManager에 전투 결과 반영
            yield return new WaitForSeconds(3);
        }

        // 일정 시간마다 소 떼가 등장한다.
        private void SpawnHerdOfCattle()
        {
            //ObjectPoolManager.Instance.SkillQueue.Enqueue();
            
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