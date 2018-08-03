using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    //RectTransform tradeUI;

    private Vector3 firstClickPosition;
    private Vector3 dragPosition;
    private Vector3 dragDirection;
    [SerializeField, Range(1, 100)]
    private float moveSpeed;

    private void Start()
    {
       // tradeUI = GameObject.FindWithTag("Tile").GetComponent<RectTransform>();
    }

    private void Update()
    {
        MouseMovement();
    }

    public void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                firstClickPosition = Input.mousePosition;
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, firstClickPosition);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                dragPosition = Input.mousePosition;
                dragDirection = (dragPosition - firstClickPosition).normalized * moveSpeed * Time.deltaTime;
                InputManager.Instance.InputDrag(dragDirection);
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            dragPosition = Vector3.zero;
            firstClickPosition = Vector3.zero;
            dragDirection = (dragPosition - firstClickPosition).normalized;
        }
    }




    /*public void DragUI()
    {
        tradeUI.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        InputManager.Instance.InputTrade(tradeUI.position);
    }

    // EndDrag시 어떤 작업을 해줄지 구현해주어야 함
    public void EndDragUI()
    {
        
    }*/

    /*public void BattleButton()
    {
        //InputManager.Instance.
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

    private void ClickDownPosition()
    {
        
    }

    private void ClickUpPosition()
    {

    }

    private void DragPosition()
    {

    }*/
}
