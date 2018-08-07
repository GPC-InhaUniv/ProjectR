using RedTheSettlers.InputManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InputState
{
    public virtual void DragMove(Vector3 direction) { }

    //----------------------UI 드래그----------------------

    public virtual void OnBeginDragUI() { }

    public virtual void OnDragUI() { }

    public virtual void EndDragUI() { }

    //----------------------UI 터치 & 클릭----------------------

    public virtual void TouchOrClickButton(InputButtonType inputButtonType) { }

    //----------------------PC 용 Battle Phase----------------------

    public virtual void DirectionKey(Vector3 direction) { }

    public virtual void BattleAttack() { }
}