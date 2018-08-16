using UnityEngine;
using RedTheSettlers.UnitTest;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using RedTheSettlers.AI;

namespace RedTheSettlers.Enemys
{
    public delegate void FireballCallback(EnemyFireBall enemyFireBall);

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
    public abstract class Enemy : MonoBehaviour
    {
        public EnemyState currentState;
        protected Material[] materials;
        public GameObject FireBall;
        protected BattleAI battleAI;

        [Header("Compoenets")]
        public Animator anim;
        protected SkinnedMeshRenderer typeRenderer;
        protected EnemyAttackArea attackArea;
        protected EnemyHitArea hitArea;
        protected Collider AttackColliderComponent;
        protected Collider HitColliderComponent;
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

        private void Start()
        {
            Setting();
        }

        private void Update()
        {
            UpdatePosition();
        }

        protected void Setting()
        {
            typeRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            anim = GetComponent<Animator>();
            attackArea = GetComponentInChildren<EnemyAttackArea>();
            hitArea = GetComponentInChildren<EnemyHitArea>();
            rigidbodyComponent = GetComponent<Rigidbody>();

            ChangeState(EnemyStateType.Idle);
        }

        protected void UpdatePosition()
        {
            currentPoint = transform.position;
            StopMovement();
        }

        public virtual void ChangeState(EnemyStateType stateType)
        {
            Debug.Log("currentState : " + currentState);
            ReQuest();
        }

        public void ChangeState(int stateType)
        {
            ChangeState((EnemyStateType)stateType);
        }

        protected void ReQuest()
        {
            currentState.DoAction(this);
        }

        //자원량을 매개변수로 받아서 enemy의 스탯 설정
        //DataManager.Instance.GameData.PlayerData[0].ResourceData.SoilNumber = 123;
        protected virtual void SetStatus(int ItemNumber)
        {
            MaxHp = 10 + ItemNumber * 3;
            Power = 2 + ItemNumber * 0.5f;
            CurrentHp = MaxHp;
        }

        //피격 처리를 담당하는 메서드
        public void Damaged(int damage)
        {
            rigidbodyComponent.velocity = Vector3.zero;
            CurrentHp -= damage;
            CheckHp();
        }

        public void EndDead()
        {
            DeadTimer = null;
            //추가 될 내용
            //자기 자신을 풀로 반환한다.
            Debug.Log("enemy return to pool");
        }

        protected void CheckHp()
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

        protected void StopMovement()
        {
            if (Vector3.Distance(destinationPoint, currentPoint) <= 1.0f && currentState.ToString().Contains("Move"))
            {
                rigidbodyComponent.velocity = Vector3.zero;
                ChangeState(EnemyStateType.Idle);
            }
        }

        
    }
}