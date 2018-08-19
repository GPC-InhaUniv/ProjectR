using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Enemys
{
    public class Die : EnemyState
    {
        public Die(
            GameTimer deadTimer, 
            float timeToReturn, 
            DeadTimerCallback deadTimerCallback
            )
        {
            this.deadTimer = deadTimer;
            this.timeToReturn = timeToReturn;
            this.deadTimerCallback = deadTimerCallback;
        }

        public override void DoAction()
        {
            animator.SetTrigger("Dead");

            //타이머 작동 후, 타이머 다되면 객체가 풀로 반환됨
            deadTimer = GameTimeManager.Instance.PopTimer();
            deadTimer.SetTimer(timeToReturn, false);
            deadTimer.Callback = new TimerCallback(deadTimerCallback);
            deadTimer.StartTimer();
        }
    }
}