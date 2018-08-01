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
    Attack,
    move,
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    private SkinnedMeshRenderer typeRenderer;
    public Animator anim;
    [SerializeField]
    private Material[] materials;
    private EnemyAttackArea attackArea;
    private EnemyHitArea hitArea;

    //Enemy Stats
    public float CurrentSpeed;
    public int CurrentHp;
    public int MaxHp;

    void Start ()
    {

        typeRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponent<Animator>();
        attackArea = GetComponent<EnemyAttackArea>();
        hitArea = GetComponent<EnemyHitArea>();

        ChangeStage(EnemyStateType.Attack);
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
            case EnemyStateType.Attack:
                currentState = new Attack();
                break;
            case EnemyStateType.move:
                currentState = new Move();
                break;
            default:
                break;
        }
        
        ReQuest();
    }

    private void ReQuest()
    {
        Debug.Log("currentState : " + currentState);
        currentState.DoAction(this);
    }

    public void SetType(EnemyType enemyType)
    {
        typeRenderer.material = materials[(int)enemyType];
    }

    void AttackEnd()
    {
        ChangeStage(EnemyStateType.Idle);
    }

}