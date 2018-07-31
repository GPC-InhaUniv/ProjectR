using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardGameState : InputState
{
    private Vector3 firstClick;
    private Vector3 mouseDrag;
    private Vector3 dragDirection;
    [Range(1, 100)]
    public float moveSpeed;

    /* public override void MouseDown(Vector3 position)
     {
         firstClick = new Vector3(position.x, 0, position.z);
     }

     public override void MouseUp(Vector3 position)
     {
         firstClick = Vector3.zero;
     }

     public override void MouseDrag(Vector3 dragPos)
     {
         mouseDrag = new Vector3(dragPos.x, 0, dragPos.z);
     }

     public override void MouseEndDrag()
     {
         mouseDrag = Vector3.zero;
         firstClick = Vector3.zero;
         dragDirection = Vector3.zero;
     }*/

    /*public override void BoardBattleButton()
    {
        
    }

    public override void BoardTurnEndButton()
    {

    }

    public override void BoardTradeButton()
    {

    }

    public override void BoardStatusButton()
    {

    }

    public override void BoardCharacterButton()
    {

    }*/
    public override void DragMove(Vector3 direction)
    {
        TemporaryGameManager.Instance.CameraMove(direction);
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "넘어왔나");
    }
}
