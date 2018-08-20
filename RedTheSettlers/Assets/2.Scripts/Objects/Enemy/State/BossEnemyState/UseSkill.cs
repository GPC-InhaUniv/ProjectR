using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys.Boss
{
    public class UseSkill : EnemyState
    {
        public UseSkill(Animator animator, FireballExplode explode, GameTimer explodeLifeTimer, float Power, float explodeLifeTime, TimerCallback pushFireball)
        {
            this.animator = animator;
            this.explode = explode;
            this.explodeLifeTimer = explodeLifeTimer;
            this.Power = Power;
            this.explodeLifeTime = explodeLifeTime;
            this.pushFireball = pushFireball;
        }

        public override void DoAction()
        {
            animator.SetTrigger("UseSkill");
            explodeLifeTimer = GameTimeManager.Instance.PopTimer();
            explodeLifeTimer.SetTimer(explodeLifeTime, false);
            explodeLifeTimer.Callback = pushFireball;
            explodeLifeTimer.StartTimer();
        }
    }
}