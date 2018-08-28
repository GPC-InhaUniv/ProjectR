﻿using RedTheSettlers.Enemys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        public const int TilePoolSize = 400;
        public const int TileListSize = 6;
        public const int TileQueueSize = 60;

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
        public List<Queue<GameObject>> BoardTileQueueList;
        public List<Queue<GameObject>> BattleTileQueueList;
        public List<Queue<GameObject>> EnemyQueueList;
        public Queue<GameObject> SkillQueue;
        public Queue<EnemyFireBall> FireballQueue;
        public Queue<Explode> ExplodeQueue;

        public TilePool TileObjectPool;
        public EnemyPool EnemyObjectPool;

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

            BoardTileQueueList = new List<Queue<GameObject>>(TileListSize);

            for(int i = 0; i < TileListSize; i++)
            {
                BoardTileQueueList[i] = new Queue<GameObject>();
                
                for(int index = 0; index < TileQueueSize; index++)
                {
                    BoardTileQueueList[i].Enqueue(Instantiate(TileObjects[i], CloneSet[i].transform));
                }
            }

            TileSet = new GameObject[TilePoolSize];

            for (int i = 0; i < TilePoolSize; i++)
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