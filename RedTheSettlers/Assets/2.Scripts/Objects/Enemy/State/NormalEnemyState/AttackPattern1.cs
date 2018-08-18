using UnityEngine;

namespace RedTheSettlers.Enemys.Normal
{
    /// <summary>
    /// 기본 공격
    /// </summary>
    public class AttackPattern1 : Attack
    {
        public AttackPattern1(Animator animator) : base(animator)
        {
            this.animator = animator;
        }

        public override void DoAction()
        {
            base.DoAction();
        }
    }
}