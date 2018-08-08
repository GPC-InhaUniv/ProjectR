namespace RedTheSettlers.Enemys
{
    public class Damage : EnemyState
    {
        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetTrigger("Damage");
        }
    }
}