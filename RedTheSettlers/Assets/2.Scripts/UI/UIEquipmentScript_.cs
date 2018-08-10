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
        [Flags]
        enum UpgradeItems
        {
            Wood = 1,
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

        UpgradeItems upgradeItems;

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

        Color textColor = new Color(255, 0, 0, 255); // 빨간색
        private void Start()
        {
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
                Wood = weaponLevelOneWoodValue,
                Iron = weaponLevelOneIronValue,
                Soil = weaponLevelOneSoilValue,

            };

            WeaponLevelTwo = new UpgradeRequestItems
            {
                Wood = weaponLevelTwoWoodValue,//플레이어 자원
                Iron = weaponLevelTwoIronValue,
                Soil = weaponLevelTwoSoilValue,
            };

            ShieldLevelOne = new UpgradeRequestItems
            {
                Wood = shieldLevelOneWoodValue,
                Iron = shieldLevelOneIronValue,
                Soil = shieldLevelOneSoilValue,
            };
            ShieldLevelTwo = new UpgradeRequestItems
            {
                Wood = shieldLevelTwoWoodValue,
                Iron = shieldLevelTwoIronValue,
                Soil = shieldLevelTwoSoilValue,
            };
        }

        public void OnclickedButton(int buttonValue)
        {
            if (buttonValue == 0) //0일때는 무기 1일때는 방어구
            {
                
                if(playerWeaponLevel == 0)
                {
                    upgradeItems = WeaponLevelOne.CheckForItems(weaponLevelOneWoodValue, weaponLevelOneIronValue, weaponLevelOneSoilValue);
                }
                else
                {
                    upgradeItems = WeaponLevelTwo.CheckForItems(weaponLevelTwoWoodValue, weaponLevelTwoIronValue, weaponLevelTwoSoilValue);
                }
                EquipmentUpgrade(playerWeaponLevel, buttonValue);
                playerWeaponLevel++;
            }
            else //0일때는 무기 1일때는 방어구
            {
                int temp;
                if (playerShieldLevel == 0)
                {
                    upgradeItems = ShieldLevelOne.CheckForItems(shieldLevelOneWoodValue, shieldLevelOneIronValue, shieldLevelOneSoilValue);
                }
                else
                {
                    upgradeItems = ShieldLevelTwo.CheckForItems(shieldLevelTwoWoodValue, shieldLevelTwoIronValue, shieldLevelTwoSoilValue);
                }
                EquipmentUpgrade(playerShieldLevel, buttonValue);
                playerShieldLevel++;
            }
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어가 소지한 나무=" + WeaponLevelOne.Wood + "플레이어가 소지한 철=" +
               WeaponLevelOne.Iron + "플레이어가 소지한 흙=" + WeaponLevelOne.Soil);
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);
        }

        void EquipmentUpgrade(int level, int buttonValue)
        {
            if (upgradeItems == (UpgradeItems.Wood & upgradeItems))
            {
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        weaponLevelOneWood.color = textColor; //빠..빠..빨간색!
                    }
                    else
                    {
                        weaponLevelTwoWood.color = textColor;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldLevelOneWood.color = textColor; //빠..빠..빨간색!
                    }
                    else
                    {
                        shieldLevelTwoWood.color = textColor;
                    }
                }
                //나무 부족
            }
            if (upgradeItems == (UpgradeItems.Iron & upgradeItems))
            {
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        weaponLevelOneIron.color = textColor; //빠..빠..빨간색!
                    }
                    else
                    {
                        weaponLevelTwoIron.color = textColor;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        shieldLevelOneIron.color = textColor; //빠..빠..빨간색!
                    }
                    else
                    {
                        shieldLevelTwoIron.color = textColor;
                    }
                }
                //철 부족
            }
            if (upgradeItems == (UpgradeItems.Soil & upgradeItems))
            {
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        weaponLevelOneSoil.color = textColor; //빠..빠..빨간색!
                    }
                    else
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
                    else
                    {
                        shieldLevelTwoSoil.color = textColor;
                    }
                }
                //철 부족
            }
            if (upgradeItems == (UpgradeItems.Iron | UpgradeItems.Soil | UpgradeItems.Wood))
            {
                //첫번째 업그레이드
                if (buttonValue == 0)
                {
                    if (level == 0)
                    {
                        WeaponLevelOne.Wood -= weaponLevelOneWoodValue;
                        WeaponLevelOne.Iron -= weaponLevelOneIronValue;
                        WeaponLevelOne.Soil-= weaponLevelOneSoilValue;
                    }
                    else
                    {
                        WeaponLevelTwo.Wood -= weaponLevelTwoWoodValue;
                        WeaponLevelTwo.Iron -= weaponLevelTwoIronValue;
                        WeaponLevelTwo.Soil -= weaponLevelTwoSoilValue;
                    }
                }
                if (buttonValue == 1)
                {
                    if (level == 0)
                    {
                        ShieldLevelOne.Wood -= shieldLevelOneWoodValue;
                        ShieldLevelOne.Iron -= shieldLevelOneIronValue;
                        ShieldLevelOne.Soil -= shieldLevelOneSoilValue;
                    }
                    else
                    {
                        ShieldLevelTwo.Wood -= shieldLevelTwoWoodValue;
                        ShieldLevelTwo.Iron -= shieldLevelTwoIronValue;
                        ShieldLevelTwo.Soil -= shieldLevelTwoSoilValue;
                    }
                }
            }
        }
    }
}