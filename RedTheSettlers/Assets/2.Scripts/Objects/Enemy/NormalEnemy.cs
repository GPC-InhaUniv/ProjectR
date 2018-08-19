using RedTheSettlers.GameSystem;
using RedTheSettlers.UnitTest;

namespace RedTheSettlers.Enemys
{
    public class NormalEnemy : Enemy
    {
        EnemyFireBall enemyFireBall;

        private void Start()
        {
            Setting();
            //SetStatus();
        }

        private void Update()
        {
            UpdatePosition();
        }

        public override void ChangeState(EnemyStateType stateType)
        {
            switch (stateType)
            {
                case EnemyStateType.Idle:
                    currentState = new Idle(animator, rigidbodyComponent);
                    break;
                case EnemyStateType.Die:
                    currentState = new Die(DeadTimer, TimeToReturn, new DeadTimerCallback(EndDead));
                    break;
                case EnemyStateType.Damage:
                    currentState = new Damage(animator);
                    break;
                case EnemyStateType.Attack1:
                    currentState = new Normal.AttackPattern1(animator);
                    break;
                case EnemyStateType.Attack2:
                    currentState = new Normal.AttackPattern2(
                        PopFireBall(),
                        FireBallLifeTimer,
                        animator,
                        transform,
                        rigidbodyComponent,
                        TargetObject,
                        currentPoint,
                        FireBallSpeed,
                        new TimerCallback(PushFireBall),
                        new ChangeStateCallback(ChangeState));
                    break;
                case EnemyStateType.Move:
                    currentState = new Move(
                        animator,
                        transform,
                        rigidbodyComponent,
                        destinationPoint,
                        currentPoint,
                        MoveSpeed,
                        currentTile);
                    break;
                default:
                    break;
            }
            base.ChangeState(stateType);
        }

        private static void executeDelegate(ChangeStateCallback changeStateCallback)
        {
            changeStateCallback(EnemyStateType.Idle);
        }


        public void SetType(EnemyType enemyType)
        {
            typeRenderer.material = materials[(int)enemyType];
        }

        private void StartAttack1()
        {
            attackArea.AttackCollider.enabled = true;
        }

        private void EndAttack()
        {
            ChangeState(EnemyStateType.Idle);
            attackArea.AttackCollider.enabled = false;
        }

        public void StartAttack2()
        {
            ChangeState(EnemyStateType.Attack2);
        }

        private void EndDamage()
        {
            ChangeState(EnemyStateType.Idle);
        }

        public EnemyFireBall PopFireBall()
        {
            enemyFireBall = ObjectPoolManager.Instance.FireballQueue.Dequeue();
            enemyFireBall.gameObject.SetActive(true);
            return enemyFireBall;
        }

        public void PushFireBall()
        {
            FireBallLifeTimer = null;
            enemyFireBall.gameObject.SetActive(false);
            ObjectPoolManager.Instance.FireballQueue.Enqueue(enemyFireBall);
        }

        protected override void SetStatus(int ItemNumber)
        {
            base.SetStatus(ItemNumber);
        }
    }
}