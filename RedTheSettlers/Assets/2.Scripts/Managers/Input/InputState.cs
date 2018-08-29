using UnityEngine;

public interface IInputState
{
    void ZoomInOut(float speed);
    void OnStartDrag();
    void OnDragging(float speed);
    void EndStopDrag();
    void OnDropSlot();
    void TileInfo();
    void MovingPlayer(Transform player);
    void BattleAttack();
    void UseSkill(int skillSlotNumber);
}