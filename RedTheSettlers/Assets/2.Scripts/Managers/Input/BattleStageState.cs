using RedTheSettlers.GameSystem;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 담당자 : 박상원
/// State 패턴 구현부
/// Battle 씬 유저 캐릭터 이동 및 공격 등
/// </summary>
public class BattleStageState : MonoBehaviour,IInputState
{
    private Vector3 skillDirection;
    private Vector2 startDragPosition;
    private Vector2 currentDragPosition;
    private Vector3 dragDirection;

    private void Start()
    {

    }

    public void DirectionKey(Vector3 direction)
    {
        //GameManager.Instance.PlayerBattle.MoveTo(direction);
        TemporaryGameManager.Instance.PlayerMove(direction);
    }

    public void OnStartDrag()
    {
        startDragPosition = Input.mousePosition;
    }

    public void OnDragging(float speed)
    {
        currentDragPosition = Input.mousePosition;
        dragDirection = (currentDragPosition - startDragPosition).normalized;
        TemporaryGameManager.Instance.PlayerMove(dragDirection);
    }

    public void EndStopDrag()
    {
        startDragPosition = Vector3.zero;
        currentDragPosition = Vector3.zero;
        dragDirection = Vector3.zero;
    }

    public void BattleAttack()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "공격");
    }

    public void SkillDirection()
    {
        skillDirection = Input.mousePosition;
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "방향 : " + skillDirection);
    }

    public void DragMove(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void ZoomInOut(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void TileInfo()
    {
        throw new System.NotImplementedException();
    }

    public void OnDropSlot()
    {
        throw new System.NotImplementedException();
    }

    public void OnInPointer()
    {
        throw new System.NotImplementedException();
    }

    public void OnOutPointer()
    {
        throw new System.NotImplementedException();
    }

    public void TouchOrClickButton(InputButtonType inputButtonType)
    {
        throw new System.NotImplementedException();
    }
}