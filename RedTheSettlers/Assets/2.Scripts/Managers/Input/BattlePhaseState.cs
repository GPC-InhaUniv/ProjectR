using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhaseState : InputState
{
    public override void DirectionKey(Vector3 direction)
    {
        TemporaryGameManager.Instance.moveDirection = direction;
    }

    public override void BattleAttack()
    {
        
    }
}
