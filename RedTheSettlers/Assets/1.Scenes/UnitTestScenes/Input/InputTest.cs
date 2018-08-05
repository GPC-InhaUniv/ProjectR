using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private Vector3 firstClickPosition;
    private Vector3 dragPosition;
    private Vector3 dragDirection;
    [SerializeField,Range(1,100)]
    private float moveSpeed;

    private void Start()
    {

    }

    private void Update()
    {
        MouseMovement();
    }

    private void MouseMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if(Physics.Raycast(rayPoint,out checkCollision,Mathf.Infinity))
            {
                firstClickPosition = Input.mousePosition;
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, firstClickPosition);
            }
        }
        else if(Input.GetMouseButton(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                dragPosition = Input.mousePosition;
                dragDirection = (dragPosition - firstClickPosition).normalized * moveSpeed * Time.deltaTime;
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "방향 나와라 : " + dragDirection);
                InputManager.Instance.InputDrag(dragDirection);
            }
        }
        else if(!Input.GetMouseButton(0))
        {
            dragPosition = Vector3.zero;
            firstClickPosition = Vector3.zero;
            dragDirection = (dragPosition - firstClickPosition).normalized;
        }
    }

    public void BattleButton()
    {
        InputManager.Instance
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "전투");
    }

    public void TradeButton()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "거래");
    }

    public void TurnEndButton()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "턴 종료");
    }

    public void CharacterStatusButton()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "캐릭터 스테이터스");
    }

    public void MiniMapButton()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "미니 맵");
    }

    public void CharacterButton()
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "캐릭터");
    }

    /*private void ClickDownPosition()
    {
        
    }

    private void ClickUpPosition()
    {

    }

    private void DragPosition()
    {

    }*/
}
