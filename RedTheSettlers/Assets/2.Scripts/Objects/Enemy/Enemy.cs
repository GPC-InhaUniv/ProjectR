using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private EnemyState state;

    void Start ()
    {
        ChangeStage(EnemyStateType.Idle);
    }

    public void ChangeStage(EnemyStateType statetype)
    {
        switch (statetype)
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

    public void ReQuest()
    {
        currentState.DoAction(this);
    }

}