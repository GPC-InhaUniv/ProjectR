namespace RedTheSettlers.Enemys
{
    public class Attack : EnemyState
    {
        public override void DoAction()
        {
            enemy.anim.SetTrigger("Attack");
        }
    }
}