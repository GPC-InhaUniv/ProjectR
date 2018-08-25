using RedTheSettlers.GameSystem;
using System.Collections.Generic;
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
        public Queue<Explode> explodeList;
        public Queue<EnemyFireBall> FireballList;

        private Vector3 explosionLocationOffset;
        private Vector3 fireballPositionOffset;

        private void Start()
        {
            base.Setting();
            Setting();
            
        }

        protected override void Setting()
        {
            explosionLocationOffset = new Vector3(0.275f, 0f, 1.3f);
            fireballPositionOffset = new Vector3(-0.173f, 1f, 1.591f);
            explodeList = new Queue<Explode>();
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
                        new TimerCallback(pushFireballTimer),
                        TargetObject,
                        transform,
                        TimeToReturn);
                    break;
                case EnemyStateType.Attack2:
                    currentState = new Boss.UseSkill(
                        animator,
                        explode,
                        explodeLifeTimer,
                        Power,
                        explodeLifeTime,
                        new TimerCallback(UseSkillEnd),
                        bossPhase);
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
            if(currentState is Boss.UseSkill)
            {
                explodeList.Enqueue(currentState.explode);
                currentState.explode.SkillRangeCircle.SetActive(true);
                currentState.explode.gameObject.transform.position = explosionLocation;
                currentState.explode.isViewingCircle = true;
            }
        }

        void UsingSkill()
        {
            if (currentState is Boss.UseSkill)
            {
                currentState.explode.particle.gameObject.SetActive(true);
                currentState.explode.isViewingCircle = false;
            }
        }

        void UseSkillEnd()
        {
            Explode tempExplode = explodeList.Dequeue();
            ObjectPoolManager.Instance.ExplodeQueue.Enqueue(tempExplode);
            tempExplode.gameObject.SetActive(false);

        }

        void pushFireballTimer()
        {

        }

        void EndSkill()
        {   //애니메이션 처리용 메소드
            ChangeState(EnemyStateType.Idle);
        }
    }
}

