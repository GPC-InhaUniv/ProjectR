using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 김하정
/// 장비 레벨UP UI
/// </summary>

namespace RedTheSettlers
{
    namespace UI
    {
        public class UIEquipmentScript : MonoBehaviour
        {
            private int playerWeaponLevel = 1;
            private int playerShieldLevel = 1;

            [HideInInspector]
            [Header("Weapon Level Blur Images")]
            [SerializeField]
            private Image[] weaponLevelBlurImages;

            [HideInInspector]
            [Header("Shield Level Blur Images")]
            [SerializeField]
            private Image[] shieldLevelBlurImages;

            [HideInInspector]
            [Header("Weapon Level Buttons")]
            [SerializeField]
            private Button[] weaponLevelButtons;

            [HideInInspector]
            [Header("Shield Level Buttons")]
            [SerializeField]
            private Button[] shieldLevelButtons;

            [Header("Temp Resource Counts")]
            [SerializeField]
            private int[] tempResourceCounts;

            [HideInInspector]
            [Header("Weapon Level Text Groups")]
            [SerializeField]
            private GameObject[] weaponLevelTextGroups;

            [HideInInspector]
            [Header("Shield Level Text Groups")]
            [SerializeField]
            private GameObject[] shieldLevelTextGroups;

            [HideInInspector]
            [Header("Weapon Level Texts")]
            [SerializeField]
            private Text[] weaponLevelTexts;

            [HideInInspector]
            [Header("Shield Level Texts")]
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


            void Start()
            {
                buttonArray = new Button[4]
                {
                    weaponLevelButtons[1],
                    weaponLevelButtons[2],
                    shieldLevelButtons[1],
                    shieldLevelButtons[2],
                };

                blurImageArray = new Image[4]
                {
                    weaponLevelBlurImages[0],
                    weaponLevelBlurImages[1],
                    shieldLevelBlurImages[0],
                    shieldLevelBlurImages[1],
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
                    tempResourceCounts[0],
                    tempResourceCounts[1],
                    tempResourceCounts[2],
                };

                weaponTextArray = new Text[2, 3]
                {
                    { weaponLevelTexts[0], weaponLevelTexts[1], weaponLevelTexts[2] },
                    { weaponLevelTexts[3], weaponLevelTexts[4], weaponLevelTexts[5] },

                 };

                shieldTextArray = new Text[2, 3]
                {

                    { shieldLevelTexts[0], shieldLevelTexts[1], shieldLevelTexts[2] },
                    { shieldLevelTexts[3], shieldLevelTexts[4], shieldLevelTexts[5]},
                 };

                resourceTextGroupArray = new GameObject[4]
                {
                    weaponLevelTextGroups[0],
                    weaponLevelTextGroups[1],
                    shieldLevelTextGroups[0],
                    shieldLevelTextGroups[1],
                };

                for (int i = 0; i < 2; i++)
                {
                    weaponTextArray[i, 0].text = weaponNecessaryResourcesArray[i, 0].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
                    weaponTextArray[i, 1].text = weaponNecessaryResourcesArray[i, 1].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
                    weaponTextArray[i, 2].text = weaponNecessaryResourcesArray[i, 2].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.


                    //리소스 텍스트 어레이 쉴드랑 웨폰따라 나누기
                    shieldTextArray[i, 0].text = shieldNecessaryResourcesArray[i, 0].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
                    shieldTextArray[i, 1].text = shieldNecessaryResourcesArray[i, 1].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
                    shieldTextArray[i, 2].text = shieldNecessaryResourcesArray[i, 2].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.
                }
                //레벨에 따른 버튼 on/ off를 위해 false로 지정
                buttonArray[1].enabled = false;
                buttonArray[3].enabled = false;
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
                    buttonArray[1].enabled = true;


                }
                else if (playerShieldLevel == 2)
                {
                    buttonArray[3].enabled = true;
                }

                Debug.Log("플레이어가 소지한 나무=" + playerResourceArray[0] + "플레이어가 소지한 철=" +
                   playerResourceArray[1] + "플레이어가 소지한 흙=" + playerResourceArray[2]);
                Debug.Log("플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);
            }

            void UpgradeWeapon(int value)
            {

                if (playerResourceArray[0] >= weaponNecessaryResourcesArray[value, 0] &&
                    playerResourceArray[1] >= weaponNecessaryResourcesArray[value, 1] &&
                    playerResourceArray[2] >= weaponNecessaryResourcesArray[value, 2])
                {
                    playerWeaponLevel += 1;
                    playerResourceArray[0] -= weaponNecessaryResourcesArray[value, 0];
                    playerResourceArray[1] -= weaponNecessaryResourcesArray[value, 1];
                    playerResourceArray[2] -= weaponNecessaryResourcesArray[value, 2];
                    buttonArray[value].interactable = false;
                    blurImageArray[value].gameObject.SetActive(false);
                    resourceTextGroupArray[value].gameObject.SetActive(false);
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (playerResourceArray[0] < weaponNecessaryResourcesArray[i, 0])
                        {
                            weaponTextArray[i, 0].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기


                        }
                        if (playerResourceArray[1] < weaponNecessaryResourcesArray[i, 1])
                        {
                            weaponTextArray[i, 1].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기


                        }
                        if (playerResourceArray[2] < weaponNecessaryResourcesArray[i, 2])
                        {
                            weaponTextArray[i, 2].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기


                        }
                    }

                }

            }

            void UpgradeShield(int value)
            {
                if (playerResourceArray[0] >= shieldNecessaryResourcesArray[value - 2, 0] &&
                    playerResourceArray[1] >= shieldNecessaryResourcesArray[value - 2, 1] &&
                    playerResourceArray[2] >= shieldNecessaryResourcesArray[value - 2, 2])
                {
                    playerShieldLevel += 1;
                    playerResourceArray[0] -= shieldNecessaryResourcesArray[value - 2, 0];
                    playerResourceArray[1] -= shieldNecessaryResourcesArray[value - 2, 1];
                    playerResourceArray[2] -= shieldNecessaryResourcesArray[value - 2, 2];
                    buttonArray[value].interactable = false;
                    blurImageArray[value].gameObject.SetActive(false);
                    resourceTextGroupArray[value].gameObject.SetActive(false);
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (playerResourceArray[0] < shieldNecessaryResourcesArray[i, 0])
                        {
                            shieldTextArray[i, 0].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기

                        }
                        if (playerResourceArray[1] < shieldNecessaryResourcesArray[i, 1])
                        {
                            shieldTextArray[i, 1].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기

                        }
                        if (playerResourceArray[2] < shieldNecessaryResourcesArray[i, 2])
                        {
                            shieldTextArray[i, 2].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기

                        }
                    }
                }
            }
        }
    }
}






