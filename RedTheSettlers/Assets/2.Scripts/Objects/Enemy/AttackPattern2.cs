using RedTheSettlers.System;
using UnityEngine;

/// <summary>
/// 파이어볼 발사, enemy 객체는 한번에 하나의 fireball 객체를 보유할 수 있다.
/// </summary>
public class AttackPattern2 : Attack
{
    EnemyFireBall fireBall;
    const float lifeTime = 5f;

    public override void DoAction(Enemy enemy)
    {
        base.DoAction(enemy);
        //pool manager로부터 fireball 객체 받아오는 코드로 수정해야 함.
        
        //test
        fireBall = enemy.PopFireBall();
        fireBall.rigidbodyComponent.velocity = (enemy.TargetObject.transform.position - enemy.transform.position).normalized * enemy.FireBallSpeed * GameTimeManager.Instance.DeltaTime;
        enemy.FireBallLifeTimer = GameTimeManager.Instance.PopTimer();
        enemy.FireBallLifeTimer.SetTimer(lifeTime, false);
        enemy.FireBallLifeTimer.Callback = new TimerCallback(enemy.PushFireBall);
    }
}