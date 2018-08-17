namespace RedTheSettlers.Enemys.Normal
{
    public class Damage : EnemyState
    {
        public override void DoAction()
        {
            animator.SetTrigger("Damage");
        }
    }
}