﻿using System.Collections;
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

    public override void MouseDown(Vector3 position)
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
    }
    public override void DragMove()
    {
        dragDirection = (mouseDrag - firstClick).normalized;
    }
}
