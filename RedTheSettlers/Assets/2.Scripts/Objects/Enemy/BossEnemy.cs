using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    /// <summary>
    /// 보스 클래스, 생성과 동시에 SetType와 SetStatus를 같이 실행해야한다.
    /// 작업자 : 최대원
    /// </summary>
    public class BossEnemy : Enemy
    {
        //파이어볼과 폭발은 풀 매니저로 옮겨야 한다.
        //보스가 체력에 따라 동시에 날리는 공격의 개수가 달라지기 때문

        private const float explodeLifeTime = 10f;
        private Vector3 explosionLocation;
        private int bossPhase;
        private Vector3 fireballPosition;


        [SerializeField]
        private GameTimer explodeLifeTimer;
        private GameTimer fireballLifeTimer;
        [SerializeField]
        private Explode explodePrefab;
        private Explode explode;

        private void Start()
        {
            base.Setting();
            Setting();
            
        }

        protected override void Setting()
        {
            explosionLocation = new Vector3(transform.position.x + 0.275f, 0f, transform.position.z + 1.3f);
            fireballPosition = new Vector3(transform.position.x + -0.173f, 1.043f, transform.position.z + 1.591f);
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
                    currentState = new Boss.Attack(
                        animator,
                        PopFireBall(),
                        fireballPosition,
                        bossPhase,
                        fireballLifeTimer,
                        new TimerCallback(pushFireballTimer)
                        );
                    break;
                case EnemyStateType.Attack2:
                    currentState = new Boss.UseSkill(
                        animator, 
                        explode, 
                        explodeLifeTimer, 
                        Power, 
                        explodeLifeTime, 
                        new TimerCallback(PushExplodeTimer));
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

        /// <summary>
        /// 보스 전용 스탯 설정 메서드
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="Power"></param>
        protected override void SetStatus(int HP, int Power, bool isLastBoss)
        {
            MaxHp = HP;
            this.Power = Power;
            this.IsLastBoss = isLastBoss;
        }
        protected override void SetStatus(int ItemNumber) { }

        public void Damaged(int damaged)
        {
            float tempHP = CurrentHp / MaxHp;
            if(tempHP > 0.8f)
            { 
                bossPhase = 0;
            }
            else if(tempHP > 0.5f)
            {
                bossPhase = 1;
            }
            else if(tempHP > 0.2)
            {
                bossPhase = 2;
            }
            else
            {
                bossPhase = 3;
            }
            base.Damaged(damaged);
        }

        void ShotFireball()
        {

        }

        void EndAttack()
        {
            ChangeState(EnemyStateType.Idle);
        }

        void EndDamage()
        {
            ChangeState(EnemyStateType.Idle);
        }

        void UseSkillStart()
        {

        }

        void BoomFireExplosion()
        {
            currentState.explode.gameObject.SetActive(true);
            currentState.explode.gameObject.transform.position = explosionLocation;
        }

        void PushExplodeTimer()
        {
            explodeLifeTimer = null;
            ObjectPoolManager.Instance.ExplodeQueue.Enqueue(currentState.explode);
            currentState.explode = null;
        }

        void pushFireballTimer()
        {

        }

        void EndSkill()
        {
            ChangeState(EnemyStateType.Idle);
        }
    }
}

