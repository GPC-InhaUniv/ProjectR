using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class Idle : EnemyState
    {
        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetFloat("Speed", enemy.rigidbodyComponent.velocity.magnitude);
        }
    }
}