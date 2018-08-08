using RedTheSettlers.GameSystem;
using UnityEngine;

public abstract class InputState
{
    public virtual void DragMove(Vector3 direction) { }

    //----------------------UI 드래그----------------------

    public virtual void OnBeginDragUI() { }

    public virtual void OnDragUI() { }

    public virtual void EndDragUI() { }

    public virtual void OnDropUI() { }

    //----------------------UI 터치 & 클릭----------------------

    public virtual void TouchOrClickButton(InputButtonType inputButtonType) { }

    //----------------------PC 용 Battle Phase----------------------

    public virtual void DirectionKey(Vector3 direction) { }

    public virtual void BattleAttack() { }
}