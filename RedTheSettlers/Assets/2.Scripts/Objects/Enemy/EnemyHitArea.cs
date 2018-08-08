using UnityEngine;

namespace RedTheSettlers.Monster
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
                enemy.ChangeStage(EnemyStateType.Damage);
            }
            else if (other.tag == "Wall")
            {
                enemy.rigidbodyComponent.velocity = Vector3.zero;
                enemy.ChangeStage(EnemyStateType.Idle);
            }
        }
    }
}