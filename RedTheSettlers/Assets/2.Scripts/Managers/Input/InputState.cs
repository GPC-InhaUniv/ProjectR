using RedTheSettlers.GameSystem;
using UnityEngine;

public abstract class InputState
{
    public virtual void DragMove(float speed) { }
    public virtual void SkillDirection() { }
    public virtual void ZoomInOut(float speed) { }
    public virtual void TileInfo() { }

    //----------------------UI 드래그----------------------

    public virtual void OnStartDrag() { }
    public virtual void OnDragging(float speed) { }
    public virtual void EndStopDrag() { }
    public virtual void OnDropSlot() { }
    public virtual void OnInPointer() { }
    public virtual void OnOutPointer() { }

    //----------------------UI 터치 & 클릭----------------------

    public virtual void TouchOrClickButton(InputButtonType inputButtonType) { }

    //----------------------PC 용 Battle Phase----------------------

    public virtual void DirectionKey(Vector3 direction) { }
    public virtual void BattleAttack() { }
}