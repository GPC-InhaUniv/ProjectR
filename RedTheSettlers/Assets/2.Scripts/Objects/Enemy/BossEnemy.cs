using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class BossEnemy : Enemy
    {
        //파이어볼과 폭발은 풀 매니저로 옮겨야 한다.
        //보스가 체력에 따라 동시에 날리는 공격의 개수가 달라지기 때문
        [SerializeField]
        private Explode explodePrefab;
        private Explode explode;
        [SerializeField]
        private GameTimer explodeLifeTimer;
        private const float explodeLifeTime = 10f;
        private Vector3 explosionLocation = new Vector3( 0.275f, 0f, 1.3f);
        [SerializeField]
        GameObject SkillRangeCircle;

        private void Start()
        {
            Setting();
            base.Setting();
        }

        protected override void Setting()
        {
            explode = Instantiate(explodePrefab, gameObject.transform);
            explode.gameObject.SetActive(false);
            explode.SkillRangeCircle = SkillRangeCircle;
            float skillRange = explode.GetComponent<SphereCollider>().radius/5;
            SkillRangeCircle.transform.localScale = new Vector3(skillRange, 0f, skillRange);
            SkillRangeCircle.SetActive(false);
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
                    currentState = new Boss.Attack();
                    break;
                case EnemyStateType.Attack2:
                    currentState = new Boss.UseSkill(
                        animator, 
                        explode, 
                        explodeLifeTimer, 
                        Power, 
                        explodeLifeTime, 
                        new TimerCallback(PushTimer));
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
        protected override void SetStatus(int HP, int Power)
        {
            MaxHp = HP;
            this.Power = Power;
        }
        protected override void SetStatus(int ItemNumber) { }

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
            SkillRangeCircle.SetActive(true);
            explode.SkillRangeCircle.SetActive(true);
            SkillRangeCircle.transform.position = explosionLocation;
        }

        void BoomFireExplosion()
        {
            explode.gameObject.SetActive(true);
            explode.gameObject.transform.position = explosionLocation;
        }

        void PushTimer()
        {
            explodeLifeTimer = null;
            explode.gameObject.SetActive(false);
            SkillRangeCircle.SetActive(false);
        }

        void EndSkill()
        {
            ChangeState(EnemyStateType.Idle);
        }
    }
}

