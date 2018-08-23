using RedTheSettlers.GameSystem;
using UnityEngine.EventSystems;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// State 패턴 구현부
/// Battle 씬 유저 캐릭터 이동 및 공격 등
/// </summary>
public class BattleStageState : MonoBehaviour,IInputState
{
    private Vector3 skillDirection;
    private Vector3 dragDirection;
    private Vector2 startDragPosition;
    private Vector2 currentDragPosition;
    private Touch firstTouch;
    private Touch secondTouch;
    private bool TouchMoveActive = false;

    private void Update()
    {
        if(TouchMoveActive)
        {
            //GameManager.Instance.PlayerBattle.MoveTo(direction);
            TemporaryGameManager.Instance.PlayerMove(dragDirection);
        }
    }

    public void DirectionKey(Vector3 direction)
    {
        //GameManager.Instance.PlayerBattle.MoveTo(direction);
        TemporaryGameManager.Instance.PlayerMove(direction);
    }

    public void OnStartDrag()
    {
        startDragPosition = Input.mousePosition;
        TouchMoveActive = true;
    }

    public void OnDragging(float speed)
    {
        firstTouch = Input.GetTouch(0);
        secondTouch = Input.GetTouch(1);
        currentDragPosition = Input.mousePosition;
        dragDirection = (currentDragPosition - startDragPosition).normalized;
    }

    public void EndStopDrag()
    {
        startDragPosition = Vector3.zero;
        currentDragPosition = Vector3.zero;
        dragDirection = Vector3.zero;
        TouchMoveActive = false;
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
}