using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class Idle : EnemyState
    {
        public Idle(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public override void DoAction()
        {
            enemy.anim.SetFloat("Speed", enemy.rigidbodyComponent.velocity.magnitude);
        }
    }
}