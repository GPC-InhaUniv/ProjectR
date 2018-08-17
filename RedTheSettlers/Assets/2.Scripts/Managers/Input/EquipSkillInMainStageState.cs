using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkillInMainStageState : InputState
{
    private static GameObject[] beingDragged;
    private static GameObject[] Slot;
    private GameObject targetUI;

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
        if (targetUI.transform.parent != startParent)
        {
            targetUI.transform.position = startPosition;
        }
        targetUI = null;
    }

    public override void OnDropSlot()
    {
        Slot = GameObject.FindGameObjectsWithTag("Slot");
    }
}
