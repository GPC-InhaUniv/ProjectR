using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : EnemyState
{
    public override void DoAction(Enemy enemy)
    {
        enemy.anim.SetTrigger("Dead");
    }
}