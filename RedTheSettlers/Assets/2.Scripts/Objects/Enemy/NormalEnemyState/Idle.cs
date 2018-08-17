using UnityEngine;

namespace RedTheSettlers.Enemys.Normal
{
    public class Idle : EnemyState
    {
        public override void DoAction()
        {
            animator.SetFloat("Speed", velocity.magnitude);
        }
    }
}