using RedTheSettlers.Enemys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        public const int TilePoolSize = 61;
        public const int CloneSetSize = 6;
        public const int FireballSize = 10;
        public GameObject[] TileObjects;
        public GameObject[] CloneSet;
        public GameObject SkillObject;
        public EnemyFireBall FireballPrefab;

        [HideInInspector]
        public GameObject[] TileSet;
        public Queue<GameObject> SkillQueue;
        public Queue<EnemyFireBall> FireballQueue;

        private void Awake()
        {
            TileSet = new GameObject[TilePoolSize];

            for (int i = 0; i < 61; i++)
            {
                int randomTileIndex = Random.Range(0, 0);

                TileSet[i] = Instantiate(TileObjects[randomTileIndex]);
                TileSet[i].transform.parent = CloneSet[randomTileIndex].transform;
            }

            SkillQueue = new Queue<GameObject>(6);
            for (int i = 0; i < 6; i++)
            {
                SkillQueue.Enqueue(SkillObject);
            }

            FireballQueue = new Queue<EnemyFireBall>(FireballSize);
            for (int i = 0; i < FireballSize; i++)
            {
                FireballQueue.Enqueue(Instantiate(FireballPrefab));
            }
        }

    }
}