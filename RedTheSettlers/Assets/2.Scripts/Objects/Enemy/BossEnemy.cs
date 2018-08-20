using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class BossEnemy : Enemy
    {
        [SerializeField]
        private FireballExplode explodePrefab;
        private FireballExplode explode;
        private GameTimer explodeLifeTimer;


        private void Start()
        {
            explode = Instantiate(explodePrefab, gameObject.transform);
            explode.gameObject.SetActive(false);
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
                    currentState = new Boss.UseSkill();
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

        void BoomFireExplosion()
        {

        }

        void EndSkill()
        {

        }
    }
}

