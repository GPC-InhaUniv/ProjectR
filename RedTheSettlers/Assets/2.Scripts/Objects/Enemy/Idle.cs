using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : EnemyState
{
    public override void DoAction(Enemy enemy)
    {
        Debug.Log("Idle");
    }
}