using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager ObjectPoolInstance;

        public const int TilePoolSize = 61;
        public const int CloneSetSize = 6;
        public GameObject[] TileObjects;
        public GameObject[] CloneSet;
        public GameObject SkillObject;

        [HideInInspector]
        public GameObject[] TileSet;
        public Queue<GameObject> SkillQueue;

        private void Awake()
        {
            ObjectPoolInstance = this;

            TileSet = new GameObject[TilePoolSize];

            for (int i = 0; i < 61; i++)
            {
                int randomTileIndex = Random.Range(0, CloneSetSize);

                TileSet[i] = Instantiate(TileObjects[randomTileIndex]);
                TileSet[i].transform.parent = CloneSet[randomTileIndex].transform;
            }

            SkillQueue = new Queue<GameObject>(6);
            for (int i = 0; i < 6; i++)
            {
                SkillQueue.Enqueue(SkillObject);
            }
        }

    }
}