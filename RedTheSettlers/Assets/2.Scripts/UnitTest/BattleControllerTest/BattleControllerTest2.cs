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
        GameTimer cattlesTimer;
        float cattleResawnTime = 100000;

        private void Start()
        {
            cattlesTimer = GameTimeManager.Instance.PopTimer();
            cattlesTimer.SetTimer(cattleResawnTime, true);
        }

        public IEnumerator BattleFlow()
        {
            ItemType tileType = diffcultyManagertest.Instance.tileType;
            if (tileType == ItemType.Cow) SpawnHerdOfCattle();

            DisappearMapTile();
            
            // DataManager에 전투 결과 반영
            yield return new WaitForSeconds(3);
        }

        // 일정 시간마다 소 떼가 등장한다.
        public void SpawnHerdOfCattle()
        {
            //GameTimeManager.Instance.
            cattlesTimer.StartTimer();
        }

        // 일정 시간 경과 후부터 맵타일이 점점 사라진다.
        public IEnumerator DisappearMapTile()
        {
            //GameTimeManager.Instance.
            yield return new WaitForSeconds(3);
        }

        public void BattleClear()
        {

        }
    }
}