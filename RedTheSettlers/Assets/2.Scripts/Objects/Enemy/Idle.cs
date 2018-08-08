using UnityEngine;

namespace RedTheSettlers.Monster
{
    public class Idle : EnemyState
    {
        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetFloat("Speed", Vector3.Distance(enemy.destinationPoint, enemy.currentPoint));
        }
    }
}