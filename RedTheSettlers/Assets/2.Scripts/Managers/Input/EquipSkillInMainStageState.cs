using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSkillInMainStageState : InputState
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

    public override void OnStartDrag()
    {
        clickPoint = Input.mousePosition;
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

    public override void OnDragging(float speed)
    {
        targetSkill.transform.position = Input.mousePosition;
    }

    public override void EndStopDrag()
    {
        if (targetSkill.transform.parent != startParent)
        {
            targetSkill.transform.position = startPosition;
        }
        targetSkill = null;
    }

    public override void OnDropSlot()
    {
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
}
