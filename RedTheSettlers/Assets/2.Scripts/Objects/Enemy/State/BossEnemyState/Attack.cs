using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys.Boss
{
    public class Attack : EnemyState
    {
        private Vector3 fireBallPosition;
        private float bossPhase;
        private GameTimer fireballTimer;
        private TimerCallback timerCallback;

        public Attack(Animator animator, EnemyFireBall fireBall, Vector3 fireBallPosition, float bossPhase, GameTimer fireballTimer, TimerCallback timerCallback)
        {
            this.animator = animator;
            this.fireBall = fireBall;
            this.fireBallPosition = fireBallPosition;
            this.fireballTimer = fireballTimer;
            this.timerCallback = timerCallback;
        }

        public override void DoAction()
        {
            animator.SetTrigger("Attack");

        }
    }
}