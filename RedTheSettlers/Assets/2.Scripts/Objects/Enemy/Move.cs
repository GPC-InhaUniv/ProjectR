using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : EnemyState
{
    public override void DoAction(Enemy enemy)
    {
        enemy.anim.SetFloat("Speed", enemy.CurrentSpeed);
    }
}