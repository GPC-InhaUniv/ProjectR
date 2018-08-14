namespace RedTheSettlers.Enemys
{
    public class Damage : EnemyState
    {
        public Damage(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public override void DoAction()
        {
            enemy.anim.SetTrigger("Damage");
        }
    }
}