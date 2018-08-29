using RedTheSettlers.GameSystem;
using UnityEngine;

public interface IInputState
{
    void DragMove(float speed);
    void UseSkill(int skillSlotNumber);
    void ZoomInOut(float speed);
    void TileInfo();

    //----------------------드래그----------------------

    void OnStartDrag();
    void OnDragging(float speed);
    void EndStopDrag();
    void OnDropSlot();
    void OnInPointer();
    void OnOutPointer();

    //----------------------UI 터치 & 클릭----------------------

    //void TouchOrClickButton(InputButtonType inputButtonType);

    //----------------------PC 용 Battle Phase----------------------

    void MovingPlayer(Transform player);
    void BattleAttack();
}