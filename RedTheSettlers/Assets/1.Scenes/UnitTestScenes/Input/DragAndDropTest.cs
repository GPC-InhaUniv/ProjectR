using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

// 컴포넌트 자동추가 객체에 직접 스크립트를 추가해야지 작동
//[RequireComponent(typeof(EventTrigger))]
public class DragAndDropTest : MonoBehaviour
{
    private static GameObject[] beingDragged;
    private Vector3 startPosition;
    private Vector3 clickPoint;
    private float firstDirection;
    private float currentDirection;
    private GameObject targetUI;

    public void OnBeginDragSlot()
    {
        clickPoint = Input.mousePosition;
        beingDragged = GameObject.FindGameObjectsWithTag("SkillIcon");
        firstDirection = Vector3.Distance(clickPoint, beingDragged[0].transform.position);
        foreach (GameObject gameObject in beingDragged)
        {
            currentDirection = Vector3.Distance(clickPoint, gameObject.transform.position);
            if(currentDirection <= firstDirection)
            {
                targetUI = gameObject;
                firstDirection = currentDirection;
            }
        }
        startPosition = targetUI.transform.position;
    }

    public void OnDragSlot()
    {
        targetUI.transform.position = Input.mousePosition;
    }

    public void EndDragSlot()
    {
        targetUI.transform.position = startPosition;
        targetUI = null;
    }
}