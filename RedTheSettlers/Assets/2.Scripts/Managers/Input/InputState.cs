using RedTheSettlers.GameSystem;
using UnityEngine;

public interface IInputState
{
    void DragMove(float speed);
    void SkillDirection();
    void ZoomInOut(float speed);
    void TileInfo();

    //----------------------UI 드래그----------------------

    void OnStartDrag();
    void OnDragging(float speed);
    void EndStopDrag();
    void OnDropSlot();
    void OnInPointer();
    void OnOutPointer();

    //----------------------UI 터치 & 클릭----------------------

    //void TouchOrClickButton(InputButtonType inputButtonType);

    //----------------------PC 용 Battle Phase----------------------

    void DirectionKey(Vector3 direction);
    void BattleAttack();
}