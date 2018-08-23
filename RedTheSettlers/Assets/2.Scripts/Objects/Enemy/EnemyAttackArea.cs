using UnityEngine;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;

namespace RedTheSettlers.Enemys
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
            if (other.CompareTag(GlobalVariables.TAG_PLAYER))
            {
                User player = GetComponent<User>();
                //플레이어에게 타격을 준다.
            }
        }
    }
}