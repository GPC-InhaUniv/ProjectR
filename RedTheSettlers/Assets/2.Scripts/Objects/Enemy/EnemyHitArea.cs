using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Enemys
{
    public class EnemyHitArea : MonoBehaviour
    {
        Enemy enemy;

        private void Start()
        {
            enemy = GetComponentInParent<Enemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "PlayerAttack")
            {
                enemy.ChangeState(EnemyStateType.Damage);
            }
            else if (other.tag == GlobalVariables.TAG_WALL)
            {
                enemy.rigidbodyComponent.velocity = Vector3.zero;
                enemy.ChangeState(EnemyStateType.Idle);
            }
        }
    }
}