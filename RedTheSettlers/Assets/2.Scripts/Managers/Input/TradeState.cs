using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 담당자 : 박상원
/// 거래 화면 입력 부분
/// </summary>
public class TradeState : InputState
{
    private static GameObject[] beingDragged;
    private GameObject targetUI;
    private Sprite EmptySlot;

    private Transform startParent;
    private Vector3 startPosition;
    private Vector3 clickPoint;
    private float firstDirection;
    private float currentDirection;

    public override void OnBeginDragUI()
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
                gameObject.GetComponent<Image>();
            }
        }
        startPosition = targetUI.transform.position;
        startParent = targetUI.transform.parent;
    }

    public override void OnDragUI()
    {
        targetUI.transform.position = Input.mousePosition;
    }

    public override void EndDragUI()
    {
        if (targetUI.transform.parent != startParent)
        {
            targetUI.transform.position = startPosition;
        }
        targetUI = null;
    }
}