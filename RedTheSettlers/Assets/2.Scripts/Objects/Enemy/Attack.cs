namespace RedTheSettlers.Monster
{
    public class Attack : EnemyState
    {
        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetTrigger("Attack");
        }
    }
}