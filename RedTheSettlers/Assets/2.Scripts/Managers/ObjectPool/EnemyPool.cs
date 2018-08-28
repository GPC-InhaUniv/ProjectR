using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class EnemyPool : MonoBehaviour
    {
        private Queue<GameObject> EnemyQueue;

        private void Start()
        {
            EnemyQueue = new Queue<GameObject>(6);
        }

        public GameObject PopEnemyObject()
        {
            return EnemyQueue.Dequeue();
        }

        public void PushEnemyObject(GameObject enemy)
        {
            EnemyQueue.Enqueue(enemy);
        }
    }
}
