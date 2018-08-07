using RedTheSettlers.UnitTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터 클래스
/// 담당자 : 최대원
/// </summary>
namespace RedTheSettlers
{
    namespace System
    {
        public enum EnemyType
        {
            Iron = 0,
            Soil = 1,
            Spot = 2,
            Water = 3,
            Wheat = 4,
            Wood = 5,
        }

        public enum EnemyStateType
        {
            Idle = 0,
            Die = 1,
            Damage = 2,
            Attack1 = 3,
            Attack2 = 4,
            Move = 5,
        }

        public class Enemy : MonoBehaviour
        {
            public EnemyState currentState;
            [SerializeField]
            private Material[] materials;
            //EnemyBattleAI battleAI;

            [Header("Compoenets")]
            public Animator anim;
            private SkinnedMeshRenderer typeRenderer;
            private EnemyAttackArea attackArea;
            private EnemyHitArea hitArea;
            private Collider AttackColliderComponent;
            private Collider HitColliderComponent;
            public Rigidbody rigidbodyComponent;

            [Header("Moving Points")]
            public Vector3 destinationPoint;
            public Vector3 currentPoint;

            [Header("Status")]
            public float MoveSpeed;
            public int CurrentHp;
            public int MaxHp;
            public float TimeToReturn = 3.0f;
            public float Power;

            [Header("Timers")]
            public GameTimer DeadTimer;
            public GameTimer Pattern1Timer;
            public GameTimer Pattern2Timer;

            [SerializeField, Header("test srcript")]
            testEnemyController testEnemyController;

            void Start()
            {
                typeRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                anim = GetComponent<Animator>();
                attackArea = GetComponentInChildren<EnemyAttackArea>();
                hitArea = GetComponentInChildren<EnemyHitArea>();
                rigidbodyComponent = GetComponent<Rigidbody>();

                ChangeStage(EnemyStateType.Idle);
            }

            private void Update()
            {
                currentPoint = transform.position;
                StopMovement();
            }

            public void ChangeStage(EnemyStateType stateType)
            {
                switch (stateType)
                {
                    case EnemyStateType.Idle:
                        currentState = new Idle();
                        break;
                    case EnemyStateType.Die:
                        currentState = new Die();
                        break;
                    case EnemyStateType.Damage:
                        currentState = new Damage();
                        break;
                    case EnemyStateType.Attack1:
                        currentState = new AttackPattern1();
                        break;
                    case EnemyStateType.Attack2:
                        currentState = new AttackPattern2();
                        break;
                    case EnemyStateType.Move:
                        currentState = new Move();
                        break;
                    default:
                        break;
                }
                Debug.Log("currentState : " + currentState);
                ReQuest();
            }

            public void ChangeStage(int stateType)
            {
                ChangeStage((EnemyStateType)stateType);
            }

            private void ReQuest()
            {
                currentState.DoAction(this);
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
                ChangeStage(EnemyStateType.Idle);
                attackArea.AttackCollider.enabled = false;
            }

            //피격 처리를 담당하는 메서드
            public void StartDamage(int damage)
            {
                if (currentState.ToString() == EnemyStateType.Damage.ToString())
                {
                    rigidbodyComponent.velocity = Vector3.zero;
                    CurrentHp -= damage;
                    CheckHp();
                }
            }

            private void EndDamage()
            {
                ChangeStage(EnemyStateType.Idle);
            }

            public void EndDead()
            {
                DeadTimer = null;
                //추가 될 내용
                //자기 자신을 풀로 반환한다.
                Debug.Log("enemy return to pool");
            }

            private void CheckHp()
            {
                if (CurrentHp <= 0 && currentState.ToString() != EnemyStateType.Die.ToString())
                {
                    ChangeStage(EnemyStateType.Die);
                }

                if (CurrentHp > MaxHp)
                {
                    CurrentHp = MaxHp;
                }
            }

            private void StopMovement()
            {
                if (Vector3.Distance(destinationPoint, currentPoint) <= 1.0f && currentState.ToString() == EnemyStateType.Move.ToString())
                {
                    rigidbodyComponent.velocity = Vector3.zero;
                    ChangeStage(EnemyStateType.Idle);
                }
            }
        }
    }
}