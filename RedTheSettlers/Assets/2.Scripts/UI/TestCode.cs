using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// LogManager 테스트 완료 후 삭제 예정
/// </summary>
public class TestCode : MonoBehaviour,IPointerClickHandler
{
    LogManager logManager;
    void Start ()
    {
        logManager = FindObjectOfType<LogManager>();
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        logManager.UserDebug(LogColor.Teal, GetType().Name, "잘 됩니까?");
    }
}