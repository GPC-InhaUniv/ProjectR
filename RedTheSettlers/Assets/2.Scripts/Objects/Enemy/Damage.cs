using UnityEngine;

namespace RedTheSettlers
{
    namespace System
    {
        public class Damage : EnemyState
        {
            public override void DoAction(Enemy enemy)
            {
                enemy.anim.SetTrigger("Damage");
            }
        }
    }
}