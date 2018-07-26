using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardGameState : InputState
{
    private Vector3 firstClick;
    private Vector3 mouseDrag;
    private Vector3 dragDirection;

    public override void MouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstClick = Input.mousePosition;
        }
    }

    public override void MouseDrag()
    {
        if(Input.GetMouseButton(0))
        {
            mouseDrag = Input.mousePosition;
        }
    }
}
