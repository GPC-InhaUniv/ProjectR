using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers
{
    public class BattlePhaseState : InputState
    {
        public override void DirectionKey(Vector3 direction)
        {
            //GameManager.Instance.PlayerBattle.MoveTo(direction);
            TemporaryGameManager.Instance.PlayerMove(direction);
        }

        public override void BattleAttack()
        {
            LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "공격");
        }
    }
}