using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;
using RedTheSettlers.Skills;
using System;


namespace RedTheSettlers.UI
{
    /// <summary>
    /// 작성자 : 김하정
    /// 스킬 UI 스크립트 : 스킬 인벤토리 창을 제작. 스킬을 장착, 제거할 수 있다.
    /// </summary>
    public class UISkill : MonoBehaviour
    {
        [Serializable]
        struct SkillIcons
        {
            public String InspectorName;
            public Button SlotIcon;
            public Button SkillIcon;
        }
        [SerializeField]
        private SkillIcons[] skillIcons;

        [SerializeField]
        private GameObject alertPopup;
        [SerializeField]
        private GameObject skillGroup;


        const int LIMITSLOT = 3;
        private int skillSlotNumber = 0;

        private void Start()
        {
            if (skillIcons.Length > GlobalVariables.MaxSkillNumber)
            {
                LogManager.Instance.UserDebug(LogColor.Red, GetType().Name, "작업자님 인스펙터 창을 확인해주세요. 스킬 아이콘의 개수가 4개를 초과했습니다.");
            }
        }

        BoardPlayer boardPlayer;

        public void AddSkill(int buttonIndex)
        {
            if (skillSlotNumber < LIMITSLOT)
            {
                skillIcons[buttonIndex].SlotIcon.gameObject.SetActive(true);
                skillIcons[buttonIndex].SkillIcon.interactable = false;
                boardPlayer.SetSkillSlot((SkillType)buttonIndex, skillSlotNumber);
                Debug.Log("버튼인덱스"+ buttonIndex + "스킬슬롯넘버"+ skillSlotNumber);
                skillSlotNumber++;
            }
        }

        public void RemoveSkill(int buttonIndex)
        {
            skillIcons[buttonIndex].SlotIcon.gameObject.SetActive(false);
            skillIcons[buttonIndex].SkillIcon.interactable = true;
            skillSlotNumber--;
        }

        public void CloseSkillSlot()
        {
            int slotCount = 0;
            for (int i = 0; i < skillIcons.Length; i++)
            {
                if (skillIcons[i].SlotIcon.gameObject.activeSelf == true)
                {
                    slotCount++;
                    if (slotCount < 3)
                    {
                        alertPopup.SetActive(true);
                        
                    }
                    else
                    {
                        skillGroup.SetActive(false);
                    }
                }
            }

        }
      
    }
}
