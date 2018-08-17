using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys.Normal
{
    /// <summary>
    /// 파이어볼 발사, enemy 객체는 한번에 하나의 fireball 객체를 보유할 수 있다.
    /// </summary>
    public class AttackPattern2 : Attack
    {
        const float lifeTime = 3f;
        const float speedCorrection = 50f;
        const float Yoffset = 0.55f;

        public AttackPattern2(
            EnemyFireBall fireBall,
            GameTimer gameTimer,
            Animator animator,
            Quaternion rotation,
            Vector3 velocity,
            Vector3 targetPosition,
            Vector3 position,
            float fireballSpeed,
            TimerCallback pushFireball,
            ChangeStateCallback changeStateCallback
            ) : base(animator)
        {
            this.fireBall = fireBall;
            this.fireballTimer = gameTimer;
            this.animator = animator;
            this.rotation = rotation;
            this.velocity = velocity;
            this.targetPosition = targetPosition;
            this.position = position;
            this.fireballSpeed = fireballSpeed;
            this.pushFireball = pushFireball;
            this.changeStateCallback = changeStateCallback;
        }

        public override void DoAction()
        {
            if (fireballTimer == null)
            {
                base.DoAction();

                Vector3 normalVector = (targetPosition - position).normalized;
                normalVector.y = 0f;
                rotation = Quaternion.LookRotation(normalVector);

                Vector3 fireRotationposition = rotation * Vector3.forward * 0.2f + position + Vector3.up;
                fireBall.transform.position = fireRotationposition;
                fireBall.rigidbodyComponent.velocity = normalVector * fireballSpeed * GameTimeManager.Instance.DeltaTime * speedCorrection;

                fireballTimer = GameTimeManager.Instance.PopTimer();
                fireballTimer.SetTimer(lifeTime, false);
                fireballTimer.Callback = pushFireball;
                fireballTimer.StartTimer();
            }
            else
            {
                changeStateCallback(EnemyStateType.Idle);
            }
                
        }
    }
}