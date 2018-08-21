using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;

/// <summary>
/// 담당자 : 박상원
/// 거래 화면 입력 부분
/// </summary>
public class TradeInMainStageState : InputState
{
    private static GameObject[] tradeCards;
    private static GameObject[] cardAreas;
    private GameObject targetCard;
    private GameObject targetArea;
    private Transform startParent;
    private Transform parentToReturnTo = null;
    private Vector3 startPosition;
    private Vector3 clickPoint;
    private Vector3 dropPoint;
    private float cardDistance;
    private float currentCardDistance;
    private float areaDistance;
    private float currentAreaDistance;

    public override void OnStartDrag()
    {
        clickPoint = Input.mousePosition;
        tradeCards = GameObject.FindGameObjectsWithTag("UIIcon");
        cardDistance = Vector3.Distance(clickPoint, tradeCards[0].transform.position);
        foreach (GameObject tradeCard in tradeCards)
        {
            currentCardDistance = Vector3.Distance(clickPoint, tradeCard.transform.position);
            if (currentCardDistance <= cardDistance)
            {
                targetCard = tradeCard;
                cardDistance = currentCardDistance;
            }
        }
        startPosition = targetCard.transform.position;
        targetCard.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        parentToReturnTo = targetCard.transform.parent;
        targetCard.transform.SetParent(targetCard.transform.parent.parent);
    }

    public override void OnDragging()
    {
        targetCard.transform.position = Input.mousePosition;
    }

    public override void EndStopDrag()
    {
        /*if (targetUI.transform.parent != startParent)
        {
            targetUI.transform.position = startPosition;
        }*/
        targetCard.transform.SetParent(parentToReturnTo);
        targetCard.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //targetUI = null;
    }

    public override void OnDropSlot()
    {
        dropPoint = Input.mousePosition;
        cardAreas = GameObject.FindGameObjectsWithTag("CardArea");
        areaDistance = Vector3.Distance(dropPoint, cardAreas[0].transform.position);
        foreach(GameObject cardArea in cardAreas)
        {
            currentAreaDistance = Vector3.Distance(dropPoint, cardArea.transform.position);
            if(currentAreaDistance <= areaDistance)
            {
                targetArea = cardArea;
                areaDistance = currentAreaDistance;
            }
        }
        targetCard.transform.SetParent(targetArea.transform);
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "OnDrop To " + targetArea);
        if (parentToReturnTo != null)
        {
            parentToReturnTo = targetArea.transform;
        }
    }

    public override void OnInPointer()
    {
        
    }

    public override void OnOutPointer()
    {
        
    }
}