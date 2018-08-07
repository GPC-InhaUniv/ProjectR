using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 김하정
/// 장비 레벨UP UI
/// weaponNecessaryResourcesArray <요런건 어떻게 고치지..
/// </summary>

namespace RedTheSettlers
{

    public class UIEquipmentScript : MonoBehaviour
    {
        int itemID;
        [SerializeField]
        private Image[] weaponLevelBlurImages;

        [Space (20)]
        [SerializeField]
        private Image[] shieldLevelBlurImages;

        [Space(20)]
        [SerializeField]
        private Button[] weaponLevelButtons;

        [Space(20)]
        [SerializeField]
        private Button[] shieldLevelButtons;

        [Space(20)]
        [SerializeField]
        private int[] tempResourceCounts;

        [HideInInspector]
        [Space(20)]
        [SerializeField]
        private GameObject[] weaponLevelTextGroups;

        [HideInInspector]
        [Space(20)]
        [SerializeField]
        private GameObject[] shieldLevelTextGroups;

        [HideInInspector]
        [Space(20)]
        [SerializeField]
        private Text[] weaponLevelTexts;

        [HideInInspector]
        [Space(20)]
        [SerializeField]
        private Text[] shieldLevelTexts;

        private Button[] buttonArray;
        private Image[] blurImageArray;
        private int[,] weaponNecessaryResourcesArray;
        private int[,] shieldNecessaryResourcesArray;
        private int[] playerResourceArray;
        private GameObject[] resourceTextGroupArray;
        private Text[,] weaponTextArray;
        private Text[,] shieldTextArray;

        private int playerWeaponLevel;
        private int playerShieldLevel;
        private Color textColor = new Color(255, 0, 0, 255);

        private enum ResourceNumbers
        {
            Wood,
            Iron,
            Soil,
        }
        private enum ResourceButtonNumbers
        {
            FirstWeaponAndShieldButton,
            SecondWeaponAndShieldButton,
            ThirdWeaponAndShieldButton,
            ForthWeaponAndShieldButton
        }

        private enum BlurImageNumbers
        {
            FirstWeaponAndShieldBlurImage,
            SecondWeaponAndShieldBlurImage,
            
        }

        private enum EquipmentLevelTextNumbers
        {
            FirstLevelText,
            SecondLevelText,
            ThirdLevelText,
            ForthLevelText,
            FifthLevelText,
            SixthLevelText,
        }


        void Start()
        {
            itemID = 0; //0번은 Weapon, 1번은 Shield
            playerWeaponLevel = 1;
            playerShieldLevel = 1;

            buttonArray = new Button[4]
            {
                    weaponLevelButtons[(int)ResourceButtonNumbers.FirstWeaponAndShieldButton],
                    weaponLevelButtons[(int)ResourceButtonNumbers.SecondWeaponAndShieldButton],
                    shieldLevelButtons[(int)ResourceButtonNumbers.FirstWeaponAndShieldButton],
                    shieldLevelButtons[(int)ResourceButtonNumbers.SecondWeaponAndShieldButton],
            };

            blurImageArray = new Image[4]
            {
                    weaponLevelBlurImages[(int)BlurImageNumbers.FirstWeaponAndShieldBlurImage],
                    weaponLevelBlurImages[(int)BlurImageNumbers.SecondWeaponAndShieldBlurImage],
                    shieldLevelBlurImages[(int)BlurImageNumbers.FirstWeaponAndShieldBlurImage],
                    shieldLevelBlurImages[(int)BlurImageNumbers.SecondWeaponAndShieldBlurImage],
            };

            weaponNecessaryResourcesArray = new int[2, 3]
             {
                    { 3,5,5 },
                    { 10,15,15 }
             };

            shieldNecessaryResourcesArray = new int[2, 3]
            {
                    { 5,3,3 },
                    { 10,5,5 }
            };

            playerResourceArray = new int[3]
            {
                    tempResourceCounts[(int)ResourceNumbers.Wood],
                    tempResourceCounts[(int)ResourceNumbers.Iron],
                    tempResourceCounts[(int)ResourceNumbers.Soil],
            };

            weaponTextArray = new Text[2, 3]
            {
                    { weaponLevelTexts[(int)EquipmentLevelTextNumbers.FirstLevelText],
                    weaponLevelTexts[(int)EquipmentLevelTextNumbers.SecondLevelText],
                    weaponLevelTexts[(int)EquipmentLevelTextNumbers.ThirdLevelText] },

                    { weaponLevelTexts[(int)EquipmentLevelTextNumbers.ForthLevelText],
                    weaponLevelTexts[(int)EquipmentLevelTextNumbers.FifthLevelText],
                    weaponLevelTexts[(int)EquipmentLevelTextNumbers.SixthLevelText] },

             };

            shieldTextArray = new Text[2, 3]
            {

                    { shieldLevelTexts[(int)EquipmentLevelTextNumbers.FirstLevelText],
                    shieldLevelTexts[(int)EquipmentLevelTextNumbers.SecondLevelText],
                    shieldLevelTexts[(int)EquipmentLevelTextNumbers.ThirdLevelText] },

                    { shieldLevelTexts[(int)EquipmentLevelTextNumbers.ForthLevelText],
                    shieldLevelTexts[(int)EquipmentLevelTextNumbers.FifthLevelText],
                    shieldLevelTexts[(int)EquipmentLevelTextNumbers.SixthLevelText]},
             };

            resourceTextGroupArray = new GameObject[4]
            {
                    weaponLevelTextGroups[(int)EquipmentLevelTextNumbers.FirstLevelText],
                    weaponLevelTextGroups[(int)EquipmentLevelTextNumbers.SecondLevelText],
                    shieldLevelTextGroups[(int)EquipmentLevelTextNumbers.FirstLevelText],
                    shieldLevelTextGroups[(int)EquipmentLevelTextNumbers.SecondLevelText],
            };

            for (int i = 0; i < 2; i++)
            {
                weaponTextArray[i, (int)EquipmentLevelTextNumbers.FirstLevelText].text = weaponNecessaryResourcesArray[i,(int)ResourceNumbers.Wood].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
                weaponTextArray[i, (int)EquipmentLevelTextNumbers.SecondLevelText].text = weaponNecessaryResourcesArray[i, (int)ResourceNumbers.Iron].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
                weaponTextArray[i, (int)EquipmentLevelTextNumbers.ThirdLevelText].text = weaponNecessaryResourcesArray[i, (int)ResourceNumbers.Soil].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.


                //리소스 텍스트 어레이 쉴드랑 웨폰따라 나누기
                shieldTextArray[i, (int)EquipmentLevelTextNumbers.FirstLevelText].text = shieldNecessaryResourcesArray[i, (int)ResourceNumbers.Wood].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
                shieldTextArray[i, (int)EquipmentLevelTextNumbers.SecondLevelText].text = shieldNecessaryResourcesArray[i, (int)ResourceNumbers.Iron].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
                shieldTextArray[i, (int)EquipmentLevelTextNumbers.ThirdLevelText].text = shieldNecessaryResourcesArray[i, (int)ResourceNumbers.Soil].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.
            }
            //레벨에 따른 버튼 on/ off를 위해 false로 지정
            buttonArray[(int)ResourceButtonNumbers.SecondWeaponAndShieldButton].enabled = false;
            buttonArray[(int)ResourceButtonNumbers.ForthWeaponAndShieldButton].enabled = false;
        }

        public void OnClickedEquipmentButton(int buttonValue)
        {

            switch (buttonValue)
            {
                case 0:

                    UpgradeWeapon(buttonValue);

                    break;
                case 1:
                    UpgradeWeapon(buttonValue);

                    break;
                case 2:
                    UpgradeShield(buttonValue);

                    break;
                case 3:
                    UpgradeShield(buttonValue);

                    break;
                default:
                    break;
            }

            if (playerWeaponLevel == 2)
            {
                buttonArray[(int)ResourceButtonNumbers.SecondWeaponAndShieldButton].enabled = true;


            }
            else if (playerShieldLevel == 2)
            {
                buttonArray[(int)ResourceButtonNumbers.ForthWeaponAndShieldButton].enabled = true;
            }

            Debug.Log("플레이어가 소지한 나무=" + playerResourceArray[0] + "플레이어가 소지한 철=" +
               playerResourceArray[1] + "플레이어가 소지한 흙=" + playerResourceArray[2]);
            Debug.Log("플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);
        }

        void UpgradeWeapon(int value)
        {

            if (playerResourceArray[(int)ResourceNumbers.Wood] >= weaponNecessaryResourcesArray[value, 0] &&
                playerResourceArray[(int)ResourceNumbers.Iron] >= weaponNecessaryResourcesArray[value, 1] &&
                playerResourceArray[(int)ResourceNumbers.Soil] >= weaponNecessaryResourcesArray[value, 2])
            {
                playerWeaponLevel += 1;
                playerResourceArray[(int)ResourceNumbers.Wood] -= weaponNecessaryResourcesArray[value, 0];
                playerResourceArray[(int)ResourceNumbers.Iron] -= weaponNecessaryResourcesArray[value, 1];
                playerResourceArray[(int)ResourceNumbers.Soil] -= weaponNecessaryResourcesArray[value, 2];
                buttonArray[value].interactable = false;
                blurImageArray[value].gameObject.SetActive(false);
                resourceTextGroupArray[value].gameObject.SetActive(false);
            }
            else
            {
                itemID = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        SetShieldColor(i, j,itemID);
                    }
                }
            }

        }

        void UpgradeShield(int value)
        {
            if (playerResourceArray[(int)ResourceNumbers.Wood] >= shieldNecessaryResourcesArray[value - 2, 0] &&
                playerResourceArray[(int)ResourceNumbers.Iron] >= shieldNecessaryResourcesArray[value - 2, 1] &&
                playerResourceArray[(int)ResourceNumbers.Soil] >= shieldNecessaryResourcesArray[value - 2, 2])
            {
                playerShieldLevel += 1;
                playerResourceArray[(int)ResourceNumbers.Wood] -= shieldNecessaryResourcesArray[value - 2, 0];
                playerResourceArray[(int)ResourceNumbers.Iron] -= shieldNecessaryResourcesArray[value - 2, 1];
                playerResourceArray[(int)ResourceNumbers.Soil] -= shieldNecessaryResourcesArray[value - 2, 2];
                buttonArray[value].interactable = false;
                blurImageArray[value].gameObject.SetActive(false);
                resourceTextGroupArray[value].gameObject.SetActive(false);
            }
            else
            {
                itemID = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        
                        SetShieldColor(i,j,itemID);
                    }
                }
            }
        }


        void SetShieldColor(int PlayerResource, int NecessaryResourceLevel, int ItemID)
        {
            if (ItemID == 0)
            {
                if(playerResourceArray[PlayerResource] < shieldNecessaryResourcesArray[NecessaryResourceLevel, PlayerResource])
                {
                    weaponTextArray[NecessaryResourceLevel, PlayerResource].color = textColor;

                }
            }
            else
            {
                if (playerResourceArray[PlayerResource] < shieldNecessaryResourcesArray[NecessaryResourceLevel, PlayerResource])
                {
                    shieldTextArray[NecessaryResourceLevel, PlayerResource].color = textColor;

                }
            }

        }
        
    }

}






