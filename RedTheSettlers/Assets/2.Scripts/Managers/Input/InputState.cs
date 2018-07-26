using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InputState : IDragHandler,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    //----------------------PC 용----------------------

    public virtual void MouseDown()
    {

    }

    public virtual void MouseOn()
    {

    }

    public virtual void MouseDrag()
    {

    }

    public virtual void MouseClick()
    {

    }

    //--------------------모바일용--------------------

    public virtual void OnDrag(PointerEventData eventData)
    {

    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }
}