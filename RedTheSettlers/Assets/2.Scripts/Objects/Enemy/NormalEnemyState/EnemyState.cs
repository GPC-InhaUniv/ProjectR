namespace RedTheSettlers.Enemys
{
    public abstract class EnemyState
    {
        protected Enemy enemy;

        public abstract void DoAction();
    }
}