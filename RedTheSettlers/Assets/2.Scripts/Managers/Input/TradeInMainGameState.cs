﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 담당자 : 박상원
/// 거래 화면 입력 부분
/// </summary>
public class TradeInMainStageState : InputState
{
    private static GameObject[] beingDragged;
    private static GameObject[] Slot;
    private GameObject targetUI;
    private Image image;

    private Transform startParent;
    private Vector3 startPosition;
    private Vector3 clickPoint;
    private float firstDirection;
    private float currentDirection;

    public override void OnStartDrag()
    {
        clickPoint = Input.mousePosition;
        beingDragged = GameObject.FindGameObjectsWithTag("SkillIcon");
        firstDirection = Vector3.Distance(clickPoint, beingDragged[0].transform.position);
        foreach (GameObject gameObject in beingDragged)
        {
            currentDirection = Vector3.Distance(clickPoint, gameObject.transform.position);
            if (currentDirection <= firstDirection)
            {
                targetUI = gameObject;
                firstDirection = currentDirection;
            }
        }
        startPosition = targetUI.transform.position;
        startParent = targetUI.transform.parent;
    }

    public override void OnDragging()
    {
        targetUI.transform.position = Input.mousePosition;
    }

    public override void EndStopDrag()
    {
        /*if (targetUI.transform.parent != startParent)
        {
            targetUI.transform.position = startPosition;
        }*/
        targetUI.transform.position = startPosition;
        targetUI = null;
    }

    public override void OnDropSlot()
    {
        // 마지막 위치 정보를 넘겨주고
        // 받는 쪽에서 마지막 위치정보와 함께 거리를 계산해서 붙는다면...?

        Slot = GameObject.FindGameObjectsWithTag("Slot");
    }

    public override void OnInPointer()
    {
        base.OnInPointer();
    }

    public override void OnOutPointer()
    {
        base.OnOutPointer();
    }
}