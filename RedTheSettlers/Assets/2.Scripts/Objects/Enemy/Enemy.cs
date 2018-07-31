using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    private EnemyState[] state;

    public const int idle = 0;
    public const int dead = 1;
    public const int damage = 2;
    public const int attack = 3;
    public const int move = 4;

    void Start ()
    {
        concreteState();
    }

    public void ChangeStage(int statetype)
    {
        currentState = state[statetype];
        ReQuest();
    }

    void concreteState()
    {
        state = new EnemyState[5];
        state[idle] = new Idle();
        state[dead] = new Die();
        state[damage] = new Damage();
        state[attack] = new Attack();
        state[move] = new Move();
    }

    public void ReQuest()
    {
        currentState.DoAction(this);
    }

}
