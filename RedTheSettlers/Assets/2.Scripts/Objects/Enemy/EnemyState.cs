using RedTheSettlers.System;

public abstract class EnemyState
{
    protected Enemy enemy;

    public abstract void DoAction(Enemy enemy);
}