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
        private const float shotOffset = 1.2f;

        public Attack(Animator animator, EnemyFireBall fireBall, Vector3 fireBallPosition, float bossPhase, GameTimer fireballTimer, TimerCallback timerCallback, GameObject targetObject, Transform transform, float TimeToReturn)
        {
            this.animator = animator;
            this.fireBall = fireBall;
            this.fireBallPosition = fireBallPosition;
            this.fireballTimer = fireballTimer;
            this.timerCallback = timerCallback;
            this.targetObject = targetObject;
            this.transform = transform;
            this.timeToReturn = TimeToReturn;
        }

        public override void DoAction()
        {
            animator.SetTrigger("Attack");
            fireBall.gameObject.transform.position = transform.rotation * Vector3.forward * shotOffset + transform.position;
            fireBall.gameObject.transform.rotation = transform.rotation;
            fireballTimer = GameTimeManager.Instance.PopTimer();
            fireballTimer.SetTimer(timeToReturn, false);
        }
    }
}