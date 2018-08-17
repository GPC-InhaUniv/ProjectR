using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;
using System;

namespace RedTheSettlers.UI
{
    public class UIEquipmentScript_ : MonoBehaviour
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

        const int weaponLevelOneWoodValue = 3;
        const int weaponLevelOneIronValue = 5;
        const int weaponLevelOneSoilValue = 5;

        const int weaponLevelTwoWoodValue = 10;
        const int weaponLevelTwoIronValue = 15;
        const int weaponLevelTwoSoilValue = 15;

        const int shieldLevelOneWoodValue = 5;
        const int shieldLevelOneIronValue = 3;
        const int shieldLevelOneSoilValue = 3;

        const int shieldLevelTwoWoodValue = 15;
        const int shieldLevelTwoIronValue = 10;
        const int shieldLevelTwoSoilValue = 10;

        UpgradeRequestItems WeaponLevelOne;
        UpgradeRequestItems WeaponLevelTwo;
        UpgradeRequestItems ShieldLevelOne;
        UpgradeRequestItems ShieldLevelTwo;

        [SerializeField, Space(20)]
        private Text weaponLevelOneWood, weaponLevelOneIron, weaponLevelOneSoil;
        [SerializeField, Space(20)]
        private Text weaponLevelTwoWood, weaponLevelTwoIron, weaponLevelTwoSoil;
        [SerializeField, Space(20)]
        private Text shieldLevelOneWood, shieldLevelOneIron, shieldLevelOneSoil;
        [SerializeField, Space(20)]
        private Text shieldLevelTwoWood, shieldLevelTwoIron, shieldLevelTwoSoil;
        [SerializeField, Space(20)]
        private Button firstWeaponLevelButton, secondWeaponLevelButton, firstShieldLevelButton, secondShieldLevelButton;
        [SerializeField, Space(20)]
        private GameObject firstWeaponLevelGroup, secondWeaponLevelGroup, firstShieldLevelGroup, secondShieldLevelGroup;

        Color textColor = new Color(255, 0, 0, 255); // 빨간색
        Color resetTextColor = new Color(0, 0, 0);//검은색

        private void Start()
        {
            secondWeaponLevelButton.interactable = false;
            secondShieldLevelButton.interactable = false;

            weaponLevelOneWood.text = weaponLevelOneWoodValue.ToString();
            weaponLevelOneIron.text = weaponLevelOneIronValue.ToString();
            weaponLevelOneSoil.text = weaponLevelOneSoilValue.ToString();

            weaponLevelTwoWood.text = weaponLevelTwoWoodValue.ToString();
            weaponLevelTwoIron.text = weaponLevelTwoIronValue.ToString();
            weaponLevelTwoSoil.text = weaponLevelTwoSoilValue.ToString();

            shieldLevelOneWood.text = shieldLevelOneWoodValue.ToString();
            shieldLevelOneIron.text = shieldLevelOneIronValue.ToString();
            shieldLevelOneSoil.text = shieldLevelOneSoilValue.ToString();

            shieldLevelTwoWood.text = shieldLevelTwoWoodValue.ToString();
            shieldLevelTwoIron.text = shieldLevelTwoIronValue.ToString();
            shieldLevelTwoSoil.text = shieldLevelTwoSoilValue.ToString();

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
                    upgradeItems = WeaponLevelOne.CheckForItems(weaponLevelOneWoodValue, weaponLevelOneIronValue, weaponLevelOneSoilValue);
                }
                else //if (playerWeaponLevel == 1)
                {
                    upgradeItems = WeaponLevelTwo.CheckForItems(weaponLevelTwoWoodValue, weaponLevelTwoIronValue, weaponLevelTwoSoilValue);
                }
                EquipmentUpgrade(playerWeaponLevel, buttonValue, upgradeItems);
            }
            else //0일때는 무기 1일때는 방어구
            {
                if (playerShieldLevel == 0)
                {
                    upgradeItems = ShieldLevelOne.CheckForItems(shieldLevelOneWoodValue, shieldLevelOneIronValue, shieldLevelOneSoilValue);
                }
                else //if (playerShieldLevel == 1)
                {
                    upgradeItems = ShieldLevelTwo.CheckForItems(shieldLevelTwoWoodValue, shieldLevelTwoIronValue, shieldLevelTwoSoilValue);
                }
                EquipmentUpgrade(playerShieldLevel, buttonValue, upgradeItems);
            }
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어가 소지한 나무=" + PlayerWood + "플레이어가 소지한 철=" +
                 PlayerIron + "플레이어가 소지한 흙=" +PlayerSoil);
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);
        }

        void EquipmentUpgrade(int level, int buttonValue, UpgradeItems upgradeItems )
        {
            if (upgradeItems != (UpgradeItems.Wood & upgradeItems))
            {
                //나무 부족
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        weaponLevelOneWood.color = textColor; //빠..빠..빨간색!
                        firstWeaponLevelButton.interactable = false;
                    }
                    else if(level == 1)
                    {
                        weaponLevelTwoWood.color = textColor;
                        secondWeaponLevelButton.interactable = false;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldLevelOneWood.color = textColor; //빠..빠..빨간색!
                        firstShieldLevelButton.interactable = false;
                    }
                    else if (level == 1)
                    {
                        shieldLevelTwoWood.color = textColor;
                        secondShieldLevelButton.interactable = false;
                    }
                }
            }
            if (upgradeItems != (UpgradeItems.Iron & upgradeItems))
            {
                //철 부족
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        weaponLevelOneIron.color = textColor; //빠..빠..빨간색!
                        firstWeaponLevelButton.interactable = false;
                    }
                    else if (level == 1)
                    {
                        weaponLevelTwoIron.color = textColor;
                        secondWeaponLevelButton.interactable = false;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldLevelOneIron.color = textColor; //빠..빠..빨간색!
                    }
                    else if (level == 1)
                    {
                        shieldLevelTwoIron.color = textColor;
                    }
                }
            }
            if (upgradeItems != (UpgradeItems.Soil & upgradeItems))
            {
                //흙 부족
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        weaponLevelOneSoil.color = textColor; //빠..빠..빨간색!
                    }
                    else if (level == 1)
                    {
                        weaponLevelTwoSoil.color = textColor;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldLevelOneSoil.color = textColor; //빠..빠..빨간색!
                    }
                    else if (level == 1)
                    {
                        shieldLevelTwoSoil.color = textColor;
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
                        PlayerWood -= weaponLevelOneWoodValue;
                        PlayerIron -= weaponLevelOneIronValue;
                        PlayerSoil -= weaponLevelOneSoilValue;
                        firstWeaponLevelGroup.SetActive(false);
                        firstWeaponLevelButton.interactable = false;
                        secondWeaponLevelButton.interactable = true;
                        playerWeaponLevel++;
                    }
                    else if (level == 1)
                    {
                        PlayerWood -= weaponLevelTwoWoodValue;
                        PlayerIron -= weaponLevelTwoIronValue;
                       PlayerSoil -= weaponLevelTwoSoilValue;
                        secondWeaponLevelGroup.SetActive(false);
                        secondWeaponLevelButton.interactable = false;
                        playerWeaponLevel++;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        PlayerWood -= shieldLevelOneWoodValue;
                        PlayerIron -= shieldLevelOneIronValue;
                        PlayerSoil -= shieldLevelOneSoilValue;
                        secondShieldLevelButton.interactable = true;
                        firstShieldLevelGroup.SetActive(false);
                        firstShieldLevelButton.interactable = false;
                        playerShieldLevel++;
                    }
                    else if (level == 1)
                    {
                        PlayerWood -= shieldLevelTwoWoodValue;
                        PlayerIron -= shieldLevelTwoIronValue;
                        PlayerSoil -= shieldLevelTwoSoilValue;
                        secondShieldLevelGroup.SetActive(false);
                        secondShieldLevelButton.interactable = false;
                        playerShieldLevel++;
                    }
                }
            }
        }

        public void ResetTextsAndButtons()
        {
            if (playerWeaponLevel==0)
            {
                firstWeaponLevelButton.interactable = true;
                weaponLevelOneIron.color = resetTextColor;
                weaponLevelOneSoil.color = resetTextColor;
                weaponLevelOneWood.color = resetTextColor;
            }
            else
            {
                secondWeaponLevelButton.interactable = true;
                weaponLevelTwoIron.color = resetTextColor;
                weaponLevelTwoSoil.color = resetTextColor;
                weaponLevelTwoWood.color = resetTextColor;
            }

            if (playerShieldLevel == 0)
            {
                firstShieldLevelButton.interactable = true;
                shieldLevelOneIron.color = resetTextColor;
                shieldLevelOneSoil.color = resetTextColor;
                shieldLevelOneWood.color = resetTextColor;
            }
            else
            {
                secondShieldLevelButton.interactable = true;
                shieldLevelTwoIron.color = resetTextColor;
                shieldLevelTwoSoil.color = resetTextColor;
                shieldLevelTwoWood.color = resetTextColor;
            }
        }
    }
}