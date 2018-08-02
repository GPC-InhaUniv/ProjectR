using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : EnemyState
{
    public override void DoAction(Enemy enemy)
    {
        enemy.anim.SetTrigger("Attack");
    }//하이하이하이하이 : by 김하정
}
