using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InputState
{
    public virtual void CurrentState()
    {

    }

    public virtual void DragMove(Vector3 direction)
    {

    }
    
    //----------------------PC 용----------------------

    /*public virtual void MouseDown(Vector3 position)
    {

    }

    public virtual void MouseUp(Vector3 position)
    {

    }

    public virtual void MouseDrag(Vector3 dragPos)
    {

    }

    public virtual void MouseEndDrag()
    {

    }*/

    public virtual void DirectionKey()
    {

    }

    public virtual void BoardBattleButton()
    {

    }

    public virtual void BoardTurnEndButton()
    {

    }

    public virtual void BoardTradeButton()
    {

    }

    public virtual void BoardStatusButton()
    {

    }

    public virtual void BoardCharacterButton()
    {

    }

    //--------------------모바일용--------------------

    /*public virtual void OnDrag(PointerEventData eventData)
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

    }*/
}