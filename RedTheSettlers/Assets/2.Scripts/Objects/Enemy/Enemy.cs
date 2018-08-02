using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Idle,
    Die,
    Damage,
    Attack1,
    Attack2,
    Move,
}

/// <summary>
/// 몬스터 클래스
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;

    public EnemyState currentState;
    private SkinnedMeshRenderer typeRenderer;
    public Animator anim;

    //collider
    private EnemyAttackArea attackArea;
    private EnemyHitArea hitArea;
    private Collider AttackColliderComponent;
    private Collider HitColliderComponent;
    public Rigidbody rigidbodyComponent;

    //move
    public Vector3 destinationPoint;
    public Vector3 currentPoint;

    //Enemy Status
    public float MoveSpeed;
    public int CurrentHp;
    public int MaxHp;

    //test
    [SerializeField]
    testEnemyController testEnemyController;
 
    void Start ()
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

        if (Vector3.Distance(destinationPoint, currentPoint) <= 1.0f && currentState.ToString() == EnemyStateType.Move.ToString())
        {
            rigidbodyComponent.velocity = Vector3.zero;
            ChangeStage(EnemyStateType.Idle);
        }
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
}