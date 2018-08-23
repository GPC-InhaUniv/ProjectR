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
        private const float explodeLifeTime = 10f;
        private Vector3 explosionLocation;
        [SerializeField]
        private int bossPhase;
        private const int MaxFireballNumber = 15;

        [SerializeField]
        private GameTimer explodeLifeTimer;
        private GameTimer fireballLifeTimer;
        [SerializeField]
        private Explode explodePrefab;
        private Explode explode;
        public Queue<Explode> explodeList;
        public Queue<EnemyFireBall> LaunchedFireballList;

        private void Start()
        {
            base.Setting(MaxFireballNumber);
            Setting(MaxFireballNumber);
        }

        protected override void Setting(int enemyFireballNumber)
        {
            explodeList = new Queue<Explode>();
            LaunchedFireballList = new Queue<EnemyFireBall>();
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
                        bossPhase,
                        fireballLifeTimer,
                        new TimerCallback(PushFireballTimer),
                        TargetObject,
                        transform,
                        TimeToReturn,
                        ObjectPoolManager.Instance.FireballQueue,
                        FireBallSpeed,
                        LaunchedFireballList);
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

        void PushFireballTimer()
        {
            EnemyFireBall tempfireBall = LaunchedFireballList.Dequeue();
            ObjectPoolManager.Instance.FireballQueue.Enqueue(tempfireBall);
            tempfireBall.gameObject.SetActive(false);
        }

        void EndSkill()
        {   //애니메이션 처리용 메소드
            ChangeState(EnemyStateType.Idle);
        }
    }
}

