using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    /// <summary>
    /// 파이어볼 발사, enemy 객체는 한번에 하나의 fireball 객체를 보유할 수 있다.
    /// </summary>
    public class AttackPattern2 : Attack
    {
        EnemyFireBall fireBall;
        const float lifeTime = 3f;
        const float speedCorrection = 50f;
        const float Yoffset = 0.55f;

        public override void DoAction(Enemy enemy)
        {
            base.DoAction(enemy);
            //pool manager로부터 fireball 객체 받아오는 코드로 수정해야 함.
            //test
            if (enemy.FireBallLifeTimer == null)
            {
                Vector3 normalVector = (enemy.TargetObject.transform.position - enemy.transform.position).normalized;
                normalVector.y = 0f;
                enemy.transform.rotation = Quaternion.LookRotation(normalVector);

                fireBall = enemy.PopFireBall();
                Vector3 fireRotationposition = enemy.transform.rotation * Vector3.forward * 0.2f + enemy.transform.position + Vector3.up;
                fireBall.transform.position = fireRotationposition;

                fireBall.rigidbodyComponent.velocity = normalVector * enemy.FireBallSpeed * GameTimeManager.Instance.DeltaTime * speedCorrection;
                
                enemy.FireBallLifeTimer = GameTimeManager.Instance.PopTimer();
                enemy.FireBallLifeTimer.SetTimer(lifeTime, false);
                enemy.FireBallLifeTimer.Callback = new TimerCallback(enemy.PushFireBall);
                enemy.FireBallLifeTimer.StartTimer();
            }            
        }
    }
}