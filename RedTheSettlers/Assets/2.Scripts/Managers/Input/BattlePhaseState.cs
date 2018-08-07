using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// State 패턴 구현부
/// Battle 씬 유저 캐릭터 이동 및 공격 등
/// </summary>
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