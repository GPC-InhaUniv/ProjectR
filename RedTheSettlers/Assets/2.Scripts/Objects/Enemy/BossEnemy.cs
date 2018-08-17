using RedTheSettlers.GameSystem;

namespace RedTheSettlers.Enemys
{
    public class BossEnemy : Enemy
    {

        public override void ChangeState(EnemyStateType stateType)
        {
            switch (stateType)
            {
                case EnemyStateType.Idle:
                    currentState = new Boss.Idle();
                    break;
                case EnemyStateType.Die:
                    currentState = new Boss.Death();
                    break;
                case EnemyStateType.Damage:
                    currentState = new Boss.Damage();
                    break;
                case EnemyStateType.Attack1:
                    currentState = new Boss.Attack();
                    break;
                case EnemyStateType.Attack2:
                    currentState = new Boss.UseSkill();
                    break;
                case EnemyStateType.Move:
                    currentState = new Boss.Move();
                    break;
                default:
                    break;
            }
            base.ChangeState(stateType);
        }

        protected override void SetStatus(int ItemNumber)
        {
            base.SetStatus(ItemNumber);
        }

        void ShotFireball()
        {

        }

        void EndAttack()
        {

        }

        void BoomFireExplosion()
        {

        }

        void EndSkill()
        {

        }
    }
}

