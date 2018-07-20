using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestCode : MonoBehaviour,IPointerClickHandler
{
    LogManager logManager;
    void Start ()
    {
        logManager = FindObjectOfType<LogManager>();
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        logManager.TestUserLog(GetType().Name, "잘 됩니까?");
    }
}
