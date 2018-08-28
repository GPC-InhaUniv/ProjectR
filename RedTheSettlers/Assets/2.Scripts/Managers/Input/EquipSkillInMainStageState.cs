using RedTheSettlers.GameSystem;
using UnityEngine;
using UnityEngine.UI;

public class EquipSkillInMainStageState : MonoBehaviour,IInputState
{
    private static GameObject[] skills;
    private static GameObject[] skillSlots;
    private GameObject targetSkill;
    private GameObject targetSlot;
    private Sprite skillImage;
    private Sprite slotEmptyImage;
    private Sprite slotChangeImage;
    private Transform startParent;
    private Vector3 startPosition;
    private Vector3 clickPoint;
    private Vector3 dropPoint;
    private float startDistance;
    private float currentDistance;
    private float firstSlotDistance;
    private float nearSlotDistance;

    public void OnStartDrag()
    {
        clickPoint = Input.mousePosition;
        // FindGameObjectWithTag는 임시방편으로 UI및 패널을 찾기 위해 작성한 코드로 추후 수정 예정
        skills = GameObject.FindGameObjectsWithTag("SkillIcon");
        startDistance = Vector3.Distance(clickPoint, skills[0].transform.position);
        foreach (GameObject skill in skills)
        {
            currentDistance = Vector3.Distance(clickPoint, skill.transform.position);
            if (currentDistance <= startDistance)
            {
                targetSkill = skill;
                startDistance = currentDistance;
            }
        }
        startPosition = targetSkill.transform.position;
        //startParent = targetSkill.transform.parent;
    }

    public void OnDragging(float speed)
    {
        targetSkill.transform.position = Input.mousePosition;
    }

    public void EndStopDrag()
    {
        if (targetSkill.transform.parent != startParent)
        {
            targetSkill.transform.position = startPosition;
        }
        targetSkill = null;
    }

    public void OnDropSlot()
    {
        // FindGameObjectWithTag는 임시방편으로 UI및 패널을 찾기 위해 작성한 코드로 추후 수정 예정
        skillSlots = GameObject.FindGameObjectsWithTag("SkillSlot");
        dropPoint = Input.mousePosition;
        firstSlotDistance = Vector3.Distance(dropPoint, skillSlots[0].transform.position);
        foreach (GameObject skillSlot in skillSlots)
        {
            nearSlotDistance = Vector3.Distance(dropPoint, skillSlot.transform.position);
            if(nearSlotDistance <= firstSlotDistance)
            {
                targetSlot = skillSlot;
                firstSlotDistance = nearSlotDistance;
            }
        }
        slotEmptyImage = targetSlot.gameObject.GetComponent<Image>().sprite;
        slotChangeImage = targetSkill.gameObject.GetComponent<Image>().sprite;
    }

    // 이 밑으로 해당 클래스에서는 사용하지 않음.
    // 추후 구조 변경시 필요치 않은 메서드들은 해당 클래스에서 사라질 예정

    public void DragMove(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void SkillDirection()
    {
        throw new System.NotImplementedException();
    }

    public void ZoomInOut(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void TileInfo()
    {
        throw new System.NotImplementedException();
    }

    public void OnInPointer()
    {
        throw new System.NotImplementedException();
    }

    public void OnOutPointer()
    {
        throw new System.NotImplementedException();
    }

    public void MovingPlayer(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void BattleAttack()
    {
        throw new System.NotImplementedException();
    }

    public void UseSkill(int skillSlotNumber)
    {
        throw new System.NotImplementedException();
    }
}
