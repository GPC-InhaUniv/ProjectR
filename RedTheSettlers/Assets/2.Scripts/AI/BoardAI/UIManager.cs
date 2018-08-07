using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    private void Start()
    {
        GameObject image = GameObject.Find("Image");
        EventTrigger eventTrigger = image.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((data) => { MoveToDragEnd((PointerEventData)data, image); });
        eventTrigger.triggers.Add(entry);
    }

    void MoveToDragEnd(PointerEventData data, GameObject gameObject)
    {
        gameObject.transform.position = data.position;
    }
}
