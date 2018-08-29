using RedTheSettlers.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 플레이어가 자원 카드를 사용해서 HP,MP,이동력을 올리는 UI
/// </summary>

namespace RedTheSettlers.UI
{
    public class UIPlayerState : MonoBehaviour
    {
        [Header("Player's Current State")]
        [SerializeField]
        private Text playerHP;

        [SerializeField]
        private Text playerMaxHP;

        [SerializeField]
        private Text playerMP;

        [SerializeField]
        private Text playerMaxMP;

        [SerializeField]
        private Text playerStamina;

        [SerializeField]
        private Slider HPItemBar;

        [SerializeField]
        private Slider MPItemBar;

        [Header("Warning Info")]
        [SerializeField]
        private Text HPWarningInfo;

        [SerializeField]
        private Text MPWarningInfo;

        [SerializeField]
        private Text StaminaWarningInfo;

        private int playercurrentHP;
        private int playercurrentMP;
        private int playercurrentStamina;

        private int playerHPItem;
        private int playerMPItem;
        private int playerStaminaItem;

        private float playerCurrentMaxHP;
        private float playerCurrentMaxMP;

        private void OnEnable()
        {
            PutPlayerState();
            SliderChanged();
        }

        public void PutPlayerState()
        {
            PlayerData playerData = GameManager.Instance.gameData.PlayerData[0];

            playerHPItem = playerData.ItemList[(int)ItemType.Cow].Count;
            playerMPItem = playerData.ItemList[(int)ItemType.Water].Count;
            playerStaminaItem = playerData.ItemList[(int)ItemType.Wheat].Count;

            playercurrentHP = playerData.StatData.HealthPoint;
            playercurrentMP = playerData.StatData.MagicPoint;
            playercurrentStamina = playerData.StatData.StaminaPoint;

            playerCurrentMaxHP = playerData.StatData.MaxHealthPoint;
            playerCurrentMaxMP = playerData.StatData.MaxMagicPoint;

            playerHP.text = playercurrentHP.ToString();
            playerMP.text = playercurrentMP.ToString();
            playerStamina.text = playercurrentStamina.ToString();
            playerMaxHP.text = "/" + playerCurrentMaxHP.ToString();
            playerMaxMP.text = "/" + playerCurrentMaxMP.ToString();
        }

        public void SliderChanged()
        {
            HPItemBar.value = playercurrentHP / playerCurrentMaxHP;
            MPItemBar.value = playercurrentMP / playerCurrentMaxMP;
        }

        public void OnUseStateItem(int itemType)
        {
            if (itemType == 0)
            {
                if (playerHPItem == 0 && playercurrentHP < playerCurrentMaxHP)
                {
                    HPWarningInfo.text = "(*'소' 자원이 부족합니다.)";
                }
                else if (playercurrentHP < playerCurrentMaxHP)
                {
                    playerHPItem = playerHPItem - 1;
                    playercurrentHP = playercurrentHP + 20;
                    playerHP.text = playercurrentHP.ToString();
                    SliderChanged();
                }
            }
            else if (itemType == 1)
            {
                if (playerMPItem == 0 && playercurrentMP < playerCurrentMaxMP)
                {
                    MPWarningInfo.text = "(*'물' 자원이 부족합니다.)";
                }
                else if (playercurrentMP < playerCurrentMaxMP)
                {
                    playerMPItem = playerMPItem - 1;
                    playercurrentMP = playercurrentMP + 20;
                    playerMP.text = playercurrentMP.ToString();
                    SliderChanged();
                }
            }
            else if (itemType == 2)
            {
                if (playerStaminaItem == 0)
                {
                    StaminaWarningInfo.text = "(*'밀' 자원이 부족합니다.)";
                }
                else if (playerStaminaItem > 0)
                {
                    playerStaminaItem = playerStaminaItem - 1;
                    playercurrentStamina = playercurrentStamina + 1;
                    playerStamina.text = playercurrentStamina.ToString();
                }
            }
        }
    }
}