using UnityEngine;
using UnityEngine.UI;
using System;

namespace RedTheSettlers.UI
{
    public class UISkillController : MonoBehaviour
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

        public void AddSkill( int buttonIndex)
        {
            if (limitCount < LIMITSLOT)
            {
                skillIcons[buttonIndex].SlotIcon.gameObject.SetActive(true);
                skillIcons[buttonIndex].SkillIcon.interactable = false;
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
