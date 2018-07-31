using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InputState
{
    public virtual void CurrentState() { }

    public virtual void DragMove(Vector3 direction) { }

    public virtual void UIMover(Vector3 position) { }

    public virtual void TouchOrClickButton(InputButtonType inputButtonType) { }

    public virtual void BoardBattleButton() { }

    public virtual void BoardTurnEndButton() { }

    public virtual void BoardTradeButton() { }

    public virtual void BoardStatusButton() { }

    public virtual void BoardCharacterButton() { }

    //----------------------PC 용----------------------

    public virtual void DirectionKey(Vector3 direction) { }

    public virtual void BattleAttack() { }
}