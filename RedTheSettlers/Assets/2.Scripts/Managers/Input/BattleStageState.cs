using RedTheSettlers.GameSystem;
using UnityEngine.EventSystems;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// State 패턴 구현부
/// Battle 씬 유저 캐릭터 이동 및 공격 등
/// </summary>
public class BattleStageState : MonoBehaviour, IInputState
{
    private Vector3 skillDirection;
    private Vector3 playerDirection;
    private Vector2 startDragPosition;
    private Vector2 currentDragPosition;
    private Vector2 startSkillDirection;
    private Vector2 currentSkillDirection;
    private Touch firstTouch;
    private Touch secondTouch;
    private bool TouchMoveActive = false;
    private int reversValue = -1;
    private float playerRotate;
    private float skillRotate;
    private float moveSpeed;

    private void Update()
    {
        /*if (TouchMoveActive)
        {
            //GameManager.Instance.PlayerBattle.MoveTo(direction);
            //TemporaryGameManager.Instance.PlayerMove(dragDirection, rotateAngle, moveSpeed);
        }*/
        MultiTouchCheck();
    }

    public void MultiTouchCheck()
    {
        if(Input.touchCount >= 2)
        {
            TouchMoveActive = true;
        }
    }

    public void DirectionKey(Vector3 direction)
    {
        //GameManager.Instance.PlayerBattle.MoveTo(direction);
        //TemporaryGameManager.Instance.PlayerMove(direction);
    }

    public void OnStartDrag()
    {
        startDragPosition = Input.mousePosition;
        if(TouchMoveActive==true)
        {
            startSkillDirection = Input.mousePosition;
        }
    }

    public void OnDragging(float speed)
    {
        moveSpeed = speed;
        currentDragPosition = Input.mousePosition;
        Vector3 dragDistance = startDragPosition - currentDragPosition;
        playerRotate = (Mathf.Atan2(dragDistance.y, dragDistance.x) * Mathf.Rad2Deg) * reversValue - 90f;
        playerDirection = Quaternion.Euler(0f, playerRotate, 0f) * Vector3.forward;
        TemporaryGameManager.Instance.PlayerMove(playerDirection, playerRotate, speed);
        //dragDirection = (currentDragPosition - startDragPosition).normalized;

        if(TouchMoveActive==true)
        {
            currentSkillDirection = Input.mousePosition;
            Vector3 skillDragDistance = startSkillDirection - currentSkillDirection;
            skillRotate = (Mathf.Atan2(skillDragDistance.y, skillDragDistance.x) * Mathf.Rad2Deg) * reversValue - 90f;
        }
    }

    public void EndStopDrag()
    {
        startDragPosition = Vector3.zero;
        currentDragPosition = Vector3.zero;
        playerDirection = Vector3.zero;
        TemporaryGameManager.Instance.PlayerMove(playerDirection, playerRotate, moveSpeed);
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