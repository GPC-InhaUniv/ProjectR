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
        public const int FireballSize = 20;
        public const int ExplodeSize = 5;

        [Header("Tiles")]
        public GameObject[] TileObjects;
        public GameObject[] CloneSet;

        [Header("Player Skill")]
        public GameObject SkillObject;

        [Header("Enemy Skills")]
        public EnemyFireBall FireballPrefab;
        public Explode ExplodePrefab;

        [HideInInspector]
        public GameObject[] TileSet;
        public Queue<GameObject> SkillQueue;
        public Queue<EnemyFireBall> FireballQueue;
        public Queue<Explode> ExplodeQueue;

        private void Awake()
        {
            //enemy only -----------
            FireballQueue = new Queue<EnemyFireBall>(FireballSize);
            for (int i = 0; i < FireballSize; i++)
            {
                FireballQueue.Enqueue(Instantiate(FireballPrefab, gameObject.transform));
            }

            ExplodeQueue = new Queue<Explode>(ExplodeSize);
            for (int i = 0; i < FireballSize; i++)
            {
                ExplodeQueue.Enqueue(Instantiate(ExplodePrefab, gameObject.transform));
            }
            //-----------------------


            TileSet = new GameObject[TilePoolSize];

            for (int i = 0; i < 100; i++)
            {
                //int randomTileIndex = DataManager.Instance.GameData.TileData[i];
                int randomTileIndex = Random.Range(0, 6);

                TileSet[i] = Instantiate(TileObjects[randomTileIndex]);
                TileSet[i].SetActive(false);
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