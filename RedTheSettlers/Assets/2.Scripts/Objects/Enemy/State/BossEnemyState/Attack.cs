using RedTheSettlers.GameSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Enemys.Boss
{
    public class Attack : EnemyState
    {
        private Vector3 fireBallPosition;
        private GameTimer fireballTimer;
        private TimerCallback timerCallback;
        private const float shotOffset = 1.2f;
        private const float AngleOffset = 15f;
        private Queue<EnemyFireBall> FireballList;
        private Queue<EnemyFireBall> LaunchedFireballList;

        public Attack(Animator animator, int bossPhase, GameTimer fireballTimer, TimerCallback timerCallback, GameObject targetObject, Transform transform, float TimeToReturn, Queue<EnemyFireBall> fireballList, float FireBallSpeed, Queue<EnemyFireBall> LaunchedFireballList)
        {
            this.animator = animator;
            this.fireballTimer = fireballTimer;
            this.timerCallback = timerCallback;
            this.targetObject = targetObject;
            this.transform = transform;
            this.timeToReturn = TimeToReturn;
            this.bossPhase = bossPhase;
            this.FireballList = fireballList;
            this.fireballSpeed = FireBallSpeed;
            this.LaunchedFireballList = LaunchedFireballList;
        }

        public override void DoAction()
        {
            animator.SetTrigger("Attack");
            
            Vector3 normalVector = (targetObject.transform.position - transform.position).normalized;
            normalVector.y = 0f;
            transform.rotation = Quaternion.LookRotation(normalVector);

            int ShotCount = (2 * bossPhase) + 1;
            float angle = ((ShotCount - 1) * 0.5f) * AngleOffset;

            for (int i = 0; i < ShotCount; i++)
            {
                EnemyFireBall enemyFireBall = FireballList.Dequeue();
                LaunchedFireballList.Enqueue(enemyFireBall);
                enemyFireBall.gameObject.SetActive(true);
                SetFireball(enemyFireBall, normalVector, angle);

                fireballTimer = GameTimeManager.Instance.PopTimer();
                fireballTimer.SetTimer(timeToReturn, false);
                fireballTimer.Callback = timerCallback;
                fireballTimer.StartTimer();

                angle -= AngleOffset;
            }
        }

        private void SetFireball(EnemyFireBall enemyFireBall, Vector3 normalVector, float angle)
        {
            enemyFireBall.gameObject.transform.position = (transform.rotation * Vector3.forward * shotOffset) + transform.position;
            enemyFireBall.transform.rotation = Quaternion.LookRotation(normalVector);
            enemyFireBall.transform.Rotate(0, angle, 0);
            enemyFireBall.rigidbodyComponent.velocity = enemyFireBall.gameObject.transform.rotation * Vector3.forward * fireballSpeed;
        }
    }
}