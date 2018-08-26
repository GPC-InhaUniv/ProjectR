using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 공격, 스킬 공격 버튼 이벤트
/// </summary>

namespace RedTheSettlers.UI
{
    public enum AttackType
    {
        Attack,
        Skill01,
        Skill02,
        Skill03,
    }

    public class UIAttackController : MonoBehaviour
    {
        [Header("Attack Button")]
        [SerializeField]
        private Button AttackButton;

        [Header("Skill Attack Button")]
        [SerializeField]
        private Button SkillSlot1Button;

        [SerializeField]
        private Button SkillSlot2Button;

        [SerializeField]
        private Button SkillSlot3Button;

        public void OnAttackButtonClick(AttackType attackType)
        {
            switch (attackType) //이거 버튼이랑 연결해서 OnClick이벤트 어케 실행할지 모르겠음 ㅠㅠ
            {
                case AttackType.Attack:
                    {
                        Debug.Log("Attack Click!"); //데이터 매니저에 저장되어 있는 어택 가져옴
                    }
                    break;

                case AttackType.Skill01:
                    {
                    }
                    break;

                case AttackType.Skill02:
                    {
                    }
                    break;

                case AttackType.Skill03:
                    {
                    }
                    break;
            }
        }

        private void Start()
        {
        }

        private void Update()
        {
        }
    }
}