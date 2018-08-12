using UnityEngine;
using RedTheSettlers.UnitTest;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using RedTheSettlers.AI;

namespace RedTheSettlers.Enemys
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

    /// <summary>
    /// 몬스터 클래스
    /// 담당자 : 최대원
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        public EnemyState currentState;
        private Material[] materials;
        public GameObject FireBall;
        private BattleAI battleAI;

        [Header("Compoenets")]
        public Animator anim;
        private SkinnedMeshRenderer typeRenderer;
        private EnemyAttackArea attackArea;
        private EnemyHitArea hitArea;
        private Collider AttackColliderComponent;
        private Collider HitColliderComponent;
        public Rigidbody rigidbodyComponent;
        public GameObject TargetObject;

        [Header("Moving Points")]
        public Vector3 destinationPoint;
        public Vector3 currentPoint;
        public Tile currentTile;

        [Header("Status")]
        public float MoveSpeed;
        public int CurrentHp;
        public int MaxHp;
        public float TimeToReturn = 3.0f;
        public float Power;
        [ReadOnly]
        public float FireBallSpeed = 4.0f;

        [Header("Timers")]
        public GameTimer DeadTimer;
        public GameTimer Pattern1Timer;
        public GameTimer Pattern2Timer;
        public GameTimer FireBallLifeTimer;

        [SerializeField, Header("test fields")]
        testEnemyController testEnemyController;
        public EnemyFireBall tempFireBallPool;
        public EnemyFireBall FireBallPrefab;

        void Start()
        {
            typeRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            anim = GetComponent<Animator>();
            attackArea = GetComponentInChildren<EnemyAttackArea>();
            hitArea = GetComponentInChildren<EnemyHitArea>();
            rigidbodyComponent = GetComponent<Rigidbody>();

            ChangeState(EnemyStateType.Idle);

            //test
            tempFireBallPool = Instantiate(FireBallPrefab);
            //tempFireBallPool.gameObject.SetActive(false);
        }

        //fireball test용 pool method
        public EnemyFireBall PopFireBall()
        {
            tempFireBallPool.gameObject.SetActive(true);
            return tempFireBallPool;
        }

        //fireball test용 pool method2
        public void PushFireBall()
        {
            FireBallLifeTimer = null;
            tempFireBallPool.gameObject.SetActive(false);
        }

        private void Update()
        {
            currentPoint = transform.position;
            StopMovement();
        }

        public void ChangeState(EnemyStateType stateType)
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

        public void ChangeState(int stateType)
        {
            ChangeState((EnemyStateType)stateType);
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
            ChangeState(EnemyStateType.Idle);
            attackArea.AttackCollider.enabled = false;
        }

        public void StartAttack2()
        {
            ChangeState(EnemyStateType.Attack2);
        }

        //피격 처리를 담당하는 메서드
        public void Damaged(int damage)
        {
            rigidbodyComponent.velocity = Vector3.zero;
            CurrentHp -= damage;
            CheckHp();
        }

        private void EndDamage()
        {
            ChangeState(EnemyStateType.Idle);
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
            if (CurrentHp <= 0)
            {
                ChangeState(EnemyStateType.Die);
            }

            if (CurrentHp > MaxHp)
            {
                CurrentHp = MaxHp;
            }
        }

        private void StopMovement()
        {
            if (Vector3.Distance(destinationPoint, currentPoint) <= 1.0f && currentState.ToString().Contains("Move"))
            {
                rigidbodyComponent.velocity = Vector3.zero;
                ChangeState(EnemyStateType.Idle);
            }
        }

        void SetStatus(int playerNumber, ItemType type)
        {
            //자원량을 매개변수로 받아서 enemy의 스탯 설정
            //DataManager.Instance.GameData.PlayerData[0].ResourceData.SoilNumber = 123;
        }

        private void OnEnable()
        {
            //SetStatus();
        }
    }
}