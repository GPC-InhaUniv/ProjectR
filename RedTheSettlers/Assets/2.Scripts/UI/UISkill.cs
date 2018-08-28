using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;
using RedTheSettlers.Skills;
using System;
 

namespace RedTheSettlers.UI
{
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

        const int LIMITSLOT = 3;
        private int limitCount = 0 ;

        private void Start()
        {
            if (skillIcons.Length > GlobalVariables.MaxSkillNumber)
            {
                LogManager.Instance.UserDebug(LogColor.Red, GetType().Name, "작업자님 인스펙터 창을 확인해주세요. 스킬 아이콘의 개수가 4개를 초과했습니다.");
            }
        }

        BoardPlayer boardPlayer;
        Skill skill;
        public void AddSkill( int buttonIndex)
        {
            if (limitCount < LIMITSLOT)
            {
                skillIcons[buttonIndex].SlotIcon.gameObject.SetActive(true);
                skillIcons[buttonIndex].SkillIcon.interactable = false;
           
                boardPlayer.SkillList.Add(skill);
               
                //스킬리스트에서 add를 어떻게하지.ㅣ
                 limitCount++;
            }
        }

        public void RemoveSkill(int buttonIndex)
        {
            skillIcons[buttonIndex].SlotIcon.gameObject.SetActive(false);
            skillIcons[buttonIndex].SkillIcon.interactable = true;
            limitCount--;
        }
    }
}
