using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class BossEnemy : Enemy
    {
        [SerializeField]
        private FireballExplode explodePrefab;
        [SerializeField]
        private FireballExplode explode;
        [SerializeField]
        private GameTimer explodeLifeTimer;
        private const float explodeLifeTime = 3.5f;
        private Vector3 explosionLocation = new Vector3(0.275f, 0f, 1.3f);

        private void Start()
        {
            explode = Instantiate(explodePrefab, gameObject.transform);
            explode.gameObject.SetActive(false);
            Setting();
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

        void EndDamage()
        {

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
        }

        void EndSkill()
        {

        }
    }
}

