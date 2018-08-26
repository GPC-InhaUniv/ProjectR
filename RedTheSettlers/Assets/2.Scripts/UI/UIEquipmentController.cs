using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;
using System;

namespace RedTheSettlers.UI
{
    public class UIEquipmentController : MonoBehaviour
    {
        public int PlayerWood;
        public int PlayerIron;
        public int PlayerSoil;

        [Flags]
        enum UpgradeItems
        {
            Wood=1,
            Iron=2,
            Soil=4,
        }

        struct UpgradeRequestItems
        {
            public int Wood, Iron, Soil;

            public UpgradeItems CheckForItems (int wood, int iron, int soil)
            {
                UpgradeItems result = 0;
                if (Wood >= wood)
                {
                    result |= UpgradeItems.Wood;
                }
                if (Iron >= iron)
                {
                    result |= UpgradeItems.Iron;
                }
                if (Soil >= soil)
                {
                    result |= UpgradeItems.Soil;
                }
                return result;
            }
        }

        int playerWeaponLevel = 0;
        int playerShieldLevel = 0;

        const int ItemsNumber = 3;

        const int attackOneWoodValue = 3;
        const int attackOneIronValue = 5;
        const int attackOneSoilValue = 5;

        const int attackTwoWoodValue = 10;
        const int attackTwoIronValue = 15;
        const int attackTwoSoilValue = 15;

        const int shieldOneWoodValue = 5;
        const int shieldOneIronValue = 3;
        const int shieldOneSoilValue = 3;

        const int shieldTwoWoodValue = 15;
        const int shieldTwoIronValue = 10;
        const int shieldTwoSoilValue = 10;

        UpgradeRequestItems WeaponLevelOne;
        UpgradeRequestItems WeaponLevelTwo;
        UpgradeRequestItems ShieldLevelOne;
        UpgradeRequestItems ShieldLevelTwo;

        [SerializeField, Space(20)]
        private Text attackOneWood, attackOneIron, attackOneSoil;
        [SerializeField, Space(20)]
        private Text attackTwoWood, attackTwoIron, attackTwoSoil;
        [SerializeField, Space(20)]
        private Text shieldOneWood, shieldOneIron, shieldOneSoil;
        [SerializeField, Space(20)]
        private Text shieldTwoWood, shieldTwoIron, shieldTwoSoil;
        [SerializeField, Space(20)]
        private Button firstAttackButton, secondAttackButton, firstShieldButton, secondShieldButton;
        [SerializeField, Space(20)]
        private GameObject firstAttackGroup, secondAttackGroup, firstShieldGroup, secondShieldGroup;

        Color textColor = new Color(255, 0, 0, 255); // 빨간색
        Color resetTextColor = new Color(0, 0, 0);//검은색

        private void Start()
        {
            secondAttackButton.interactable = false;
            secondShieldButton.interactable = false;

            attackOneWood.text = attackOneWoodValue.ToString();
            attackOneIron.text = attackOneIronValue.ToString();
            attackOneSoil.text = attackOneSoilValue.ToString();

            attackTwoWood.text = attackTwoWoodValue.ToString();
            attackTwoIron.text = attackTwoIronValue.ToString();
            attackTwoSoil.text = attackTwoSoilValue.ToString();

            shieldOneWood.text = shieldOneWoodValue.ToString();
            shieldOneIron.text = shieldOneIronValue.ToString();
            shieldOneSoil.text = shieldOneSoilValue.ToString();

            shieldTwoWood.text = shieldTwoWoodValue.ToString();
            shieldTwoIron.text = shieldTwoIronValue.ToString();
            shieldTwoSoil.text = shieldTwoSoilValue.ToString();

            WeaponLevelOne = new UpgradeRequestItems
            {
                Wood = PlayerWood,
                Iron = PlayerIron,
                Soil = PlayerSoil,
            };

            WeaponLevelTwo = new UpgradeRequestItems
            {
                Wood = PlayerWood,//플레이어 자원
                Iron = PlayerIron,
                Soil = PlayerSoil,
            };

            ShieldLevelOne = new UpgradeRequestItems
            {
                Wood = PlayerWood,
                Iron = PlayerIron,
                Soil = PlayerSoil,
            };
            ShieldLevelTwo = new UpgradeRequestItems
            {
                Wood = PlayerWood,
                Iron = PlayerIron,
                Soil = PlayerSoil,
            };
        }

        public void OnclickedButton(int buttonValue)
        {
            UpgradeItems upgradeItems;
            if (buttonValue == 0) //0일때는 무기 1일때는 방어구
            {
                if (playerWeaponLevel == 0)
                {
                    upgradeItems = WeaponLevelOne.CheckForItems(attackOneWoodValue, attackOneIronValue, attackOneSoilValue);
                }
                else    //playerWeaponLevel == 1
                {
                    upgradeItems = WeaponLevelTwo.CheckForItems(attackTwoWoodValue, attackTwoIronValue, attackTwoSoilValue);
                }
                EquipmentUpgrade(playerWeaponLevel, buttonValue, upgradeItems);
            }
            else //0일때는 무기 1일때는 방어구
            {
                if (playerShieldLevel == 0)
                {
                    upgradeItems = ShieldLevelOne.CheckForItems(shieldOneWoodValue, shieldOneIronValue, shieldOneSoilValue);
                }
                else     //playerShieldLevel == 1
                {
                    upgradeItems = ShieldLevelTwo.CheckForItems(shieldTwoWoodValue, shieldTwoIronValue, shieldTwoSoilValue);
                }
                EquipmentUpgrade(playerShieldLevel, buttonValue, upgradeItems);
            }
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어가 소지한 나무=" + PlayerWood + "플레이어가 소지한 철=" +
                 PlayerIron + "플레이어가 소지한 흙=" +PlayerSoil);
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);
        }

        void EquipmentUpgrade(int level, int buttonValue, UpgradeItems upgradeItems )
        {
            if (upgradeItems != (UpgradeItems.Wood | upgradeItems))
            {
                //나무 부족
                if (buttonValue == 0)
                {
                    if (level == 0 )
                    {
                        attackOneWood.color = textColor; //빠..빠..빨간색!
                        firstAttackButton.interactable = false;
                    }
                    else /*if(level == 1)*/
                    {
                        attackTwoWood.color = textColor;
                        secondAttackButton.interactable = false;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0 )
                    {
                        shieldOneWood.color = textColor; //빠..빠..빨간색!
                        firstShieldButton.interactable = false;
                    }
                    else/* if (level == 1)*/
                    {
                        shieldTwoWood.color = textColor;
                        secondShieldButton.interactable = false;
                    }
                }
            }
            if (upgradeItems != (UpgradeItems.Iron | upgradeItems))
            {
                //철 부족
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        attackOneIron.color = textColor; //빠..빠..빨간색!
                        firstAttackButton.interactable = false;
                    }
                    else  //level == 1
                    {
                        attackTwoIron.color = textColor;
                        secondAttackButton.interactable = false;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldOneIron.color = textColor; //빠..빠..빨간색!
                        firstShieldButton.interactable = false;
                    }
                    else  //level == 1
                    {
                        shieldTwoIron.color = textColor;
                        secondShieldButton.interactable = false;
                    }
                }
            }
            if (upgradeItems != (UpgradeItems.Soil | upgradeItems))
            {
                //흙 부족
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        attackOneSoil.color = textColor; //빠..빠..빨간색!
                        firstAttackButton.interactable = false;
                    }
                    else  //level == 1
                    {
                        attackTwoSoil.color = textColor;
                        secondAttackButton.interactable = false;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldOneSoil.color = textColor; //빠..빠..빨간색!
                        firstShieldButton.interactable = false;
                    }
                    else  //level == 1
                    {
                        shieldTwoSoil.color = textColor;
                        secondShieldButton.interactable = false;
                    }
                }
            }

            if (upgradeItems == (UpgradeItems.Iron | UpgradeItems.Soil | UpgradeItems.Wood))
            {
                //첫번째 업그레이드
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        PlayerWood -= attackOneWoodValue;
                        PlayerIron -= attackOneIronValue;
                        PlayerSoil -= attackOneSoilValue;
                        firstAttackGroup.SetActive(false);
                        firstAttackButton.interactable = false;
                        secondAttackButton.interactable = true;
                        playerWeaponLevel++;
                    }
                    else if (level == 1)
                    {
                        PlayerWood -= attackTwoWoodValue;
                        PlayerIron -= attackTwoIronValue;
                       PlayerSoil -= attackTwoSoilValue;
                        secondAttackGroup.SetActive(false);
                        secondAttackButton.interactable = false;
                        playerWeaponLevel++;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        PlayerWood -= shieldOneWoodValue;
                        PlayerIron -= shieldOneIronValue;
                        PlayerSoil -= shieldOneSoilValue;
                        secondShieldButton.interactable = true;
                        firstShieldGroup.SetActive(false);
                        firstShieldButton.interactable = false;
                        playerShieldLevel++;
                    }
                    else if (level == 1)
                    {
                        PlayerWood -= shieldTwoWoodValue;
                        PlayerIron -= shieldTwoIronValue;
                        PlayerSoil -= shieldTwoSoilValue;
                        secondShieldGroup.SetActive(false);
                        secondShieldButton.interactable = false;
                        playerShieldLevel++;
                    }
                }
            }
        }

        public void ResetTextsAndButtons()
        {
            if (playerWeaponLevel==0)
            {
                firstAttackButton.interactable = true;
                attackOneIron.color = resetTextColor;
                attackOneSoil.color = resetTextColor;
                attackOneWood.color = resetTextColor;
            }
            else
            {
                secondAttackButton.interactable = true;
                attackTwoIron.color = resetTextColor;
                attackTwoSoil.color = resetTextColor;
                attackTwoWood.color = resetTextColor;
            }

            if (playerShieldLevel == 0)
            {
                firstShieldButton.interactable = true;
                shieldOneIron.color = resetTextColor;
                shieldOneSoil.color = resetTextColor;
                shieldOneWood.color = resetTextColor;
            }
            else
            {
                secondShieldButton.interactable = true;
                shieldTwoIron.color = resetTextColor;
                shieldTwoSoil.color = resetTextColor;
                shieldTwoWood.color = resetTextColor;
            }
        }
    }
}