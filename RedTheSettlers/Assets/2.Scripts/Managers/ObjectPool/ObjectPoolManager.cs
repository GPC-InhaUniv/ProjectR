using RedTheSettlers.Enemys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        public const int TilePoolSize = 200;
        public const int CloneSetSize = 6;
        public const int FireballSize = 10;
        public GameObject[] TileObjects;
        public GameObject[] CloneSet;
        public GameObject SkillObject;
        //Enemy only prefabs
        //public EnemyFireBall FireballPrefab;
        //public Explode ExplodePrefab;

        [HideInInspector]
        public GameObject[] TileSet;
        public Queue<GameObject> SkillQueue;

        //Enemy only queues
        public Queue<EnemyFireBall> FireballQueue;
        public Queue<Explode> ExplodeQueue;

        private void Awake()
        {
            /*
            FireballQueue = new Queue<EnemyFireBall>(FireballSize);
            for (int i = 0; i < FireballSize; i++)
            {
                FireballQueue.Enqueue(Instantiate(FireballPrefab));
            }
            */

            TileSet = new GameObject[TilePoolSize];

            for (int i = 0; i < 200; i++)
            {
                int randomTileIndex = Random.Range(0, 0);

                TileSet[i] = Instantiate(TileObjects[randomTileIndex]);
                TileSet[i].transform.parent = CloneSet[randomTileIndex].transform;

            }

            TileManager.Instance.IntializeTileSet();

            SkillQueue = new Queue<GameObject>(6);
            for (int i = 0; i < 6; i++)
            {
                SkillQueue.Enqueue(SkillObject);
            }

            
        }

    }
}