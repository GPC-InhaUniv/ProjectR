using RedTheSettlers.GameSystem;
using RedTheSettlers.UnitTest;

namespace RedTheSettlers.Enemys
{
    /// <summary>
    /// 일반 몬스터 클래스 생성과 동시에 SetType와 SetStatus를 같이 실행해야한다.
    /// 작업자 : 최대원
    /// </summary>
    public class NormalEnemy : Enemy
    {
        

        private void Start()
        {
            Setting();
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

        private static void ExecuteDelegate(ChangeStateCallback changeStateCallback)
        {
            changeStateCallback(EnemyStateType.Idle);
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

        /// <summary>
        /// 일반 몹 전용 스텟 설정 메서드
        /// </summary>
        /// <param name="ItemNumber"></param>
        protected override void SetStatus(int ItemNumber)
        {
            MaxHp = 10 + ItemNumber * 3;
            Power = 2 + ItemNumber * 0.5f;
            CurrentHp = MaxHp;
        }
        protected override void SetStatus(int HP, int Power, bool IsLastBoss) { }
    }
}