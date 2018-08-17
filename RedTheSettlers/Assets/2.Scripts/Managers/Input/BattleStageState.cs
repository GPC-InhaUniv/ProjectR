using RedTheSettlers.GameSystem;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// State 패턴 구현부
/// Battle 씬 유저 캐릭터 이동 및 공격 등
/// </summary>
public class BattleStageState : InputState
{
    private Vector3 skillDirection;

    public override void DirectionKey(Vector3 direction)
    {
        //GameManager.Instance.PlayerBattle.MoveTo(direction);
        TemporaryGameManager.Instance.PlayerMove(direction);
    }

    public override void BattleAttack()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "공격");
    }

    public override void SkillDirection()
    {
        skillDirection = Input.mousePosition;
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "방향 : " + skillDirection);
    }
}