using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : EnemyState
{
    public override void DoAction(Enemy enemy)
    {
        enemy.anim.SetFloat("Speed", Vector3.Distance(enemy.destinationPoint, enemy.currentPoint));
    }
}