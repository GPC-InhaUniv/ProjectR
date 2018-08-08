using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Enemys
{
    public class Die : EnemyState
    {
        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetTrigger("Dead");

            //타이머 작동 후, 타이머 다되면 객체가 풀로 반환됨
            enemy.DeadTimer = GameTimeManager.Instance.PopTimer();
            enemy.DeadTimer.SetTimer(enemy.TimeToReturn, false);
            enemy.DeadTimer.Callback = new TimerCallback(enemy.EndDead);
            enemy.DeadTimer.StartTimer();
        }
    }
}