using UnityEngine;

namespace RedTheSettlers.Monster
{
    public class EnemyAttackArea : MonoBehaviour
    {
        public Collider AttackCollider;

        private void Start()
        {
            AttackCollider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //플레이어에게 타격을 준다.
                //GameManager 통해서 처리
            }
        }
    }
}