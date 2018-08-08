using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;


/// <summary>
/// 작성자 : 김하정
/// 장비 레벨UP UI
/// </summary>

namespace RedTheSettlers.UI
{
    struct ItemList
    {
        public int wood;
        public int iron;
        public int soil;
    }

    public class UIEquipmentScript : MonoBehaviour
    {
        const int EquipmentLevel = 2;
        const int ItemType = 3;

        int itemID;
        [Space(20)]
        [SerializeField]
        private Image[] weaponLevelBlurImages, shieldLevelBlurImages;

        [Space(20)]
        [SerializeField]
        private Button[] weaponLevelButton, shieldLevelButton;

        [Space(20)]
        [SerializeField]
        private int[] tempItemCounts;

        [Space(20)]
        [SerializeField]
        private GameObject[] weaponLevelTextGroups, shieldLevelTextGroups;

        [Space(20)]
        [SerializeField]
        private Text[] weaponLevelTexts, shieldLevelTexts;

        private Button[] weaponButton, shieldButton;
        private Image[] weaponBlurImage, shieldBlurImage;
        private int[,] weaponNecessaryItem, shieldNecessaryItem;
        private int[] playerItem;
        private GameObject[] weaponItemTextGroup, shieldItemTextGroup;

        private Text[,] weaponTextArray, shieldTextArray;

        private int playerWeaponLevel, playerShieldLevel;
        private Color textColor = new Color(255, 0, 0, 255);   //빠..빠..빨간색!

        private enum ItemTypeList
        {
            Wood,
            Iron,
            Soil,
        }
        private enum ItemButton
        {
            FirstWeaponAndShield,
            SecondWeaponAndShield,
        }

        private enum BlurImage
        {
            FirstEquipment,
            SecondEquipment,
        }

        private enum EquipmentLevelText
        {
            FirstLevel,
            SecondLevel,
            ThirdLevel,
            ForthLevel,
            FifthLevel,
            SixthLevel,
        }


        void Start()
        {
            itemID = 0; //0번은 Weapon, 1번은 Shield

            playerWeaponLevel = 1;
            playerShieldLevel = 1;

            ItemList weaponLevelTwo;
            weaponLevelTwo.wood = 3;
            weaponLevelTwo.iron = 5;
            weaponLevelTwo.soil = 5;

            ItemList weaponLevelThree;
            weaponLevelThree.wood = 10;
            weaponLevelThree.iron = 15;
            weaponLevelThree.soil = 15;

            ItemList shieldLevelTwo;
            shieldLevelTwo.wood = 5;
            shieldLevelTwo.iron = 3;
            shieldLevelTwo.soil = 3;

            ItemList shieldLevelThree;
            shieldLevelThree.wood = 10;
            shieldLevelThree.iron = 5;
            shieldLevelThree.soil = 5;


            weaponButton = new Button[EquipmentLevel]
            {
                weaponLevelButton[(int)ItemButton.FirstWeaponAndShield],
                weaponLevelButton[(int)ItemButton.SecondWeaponAndShield],
            };

            shieldButton = new Button[EquipmentLevel]
          {
                shieldLevelButton[(int)ItemButton.FirstWeaponAndShield],
                shieldLevelButton[(int)ItemButton.SecondWeaponAndShield],
          };

            weaponBlurImage = new Image[EquipmentLevel]
            {
                weaponLevelBlurImages[(int)BlurImage.FirstEquipment],
                weaponLevelBlurImages[(int)BlurImage.SecondEquipment ],
             
            };
            shieldBlurImage = new Image[EquipmentLevel]
            { 
                shieldLevelBlurImages[(int)BlurImage.FirstEquipment],
                shieldLevelBlurImages[(int)BlurImage.SecondEquipment ],
            };

            weaponNecessaryItem = new int[EquipmentLevel, ItemType]
             {
                { weaponLevelTwo.wood,weaponLevelTwo.iron,weaponLevelTwo.soil },
                { weaponLevelThree.wood,weaponLevelThree.iron,weaponLevelThree.soil }
             };

            shieldNecessaryItem = new int[EquipmentLevel, ItemType]
            {
                { shieldLevelTwo.wood,shieldLevelTwo.iron,shieldLevelTwo.soil},
                { shieldLevelThree.wood,shieldLevelThree.iron,shieldLevelThree.soil }
            };

            playerItem = new int[ItemType]
            {
                tempItemCounts[(int)ItemTypeList.Wood],
                tempItemCounts[(int)ItemTypeList.Iron],
                tempItemCounts[(int)ItemTypeList.Soil],
            };

            weaponTextArray = new Text[EquipmentLevel, ItemType]
            {
                { weaponLevelTexts[(int)EquipmentLevelText.FirstLevel],
                weaponLevelTexts[(int)EquipmentLevelText.SecondLevel],
                weaponLevelTexts[(int)EquipmentLevelText.ThirdLevel] },

                { weaponLevelTexts[(int)EquipmentLevelText.ForthLevel],
                weaponLevelTexts[(int)EquipmentLevelText.FifthLevel],
                weaponLevelTexts[(int)EquipmentLevelText.SixthLevel] },

             };

            shieldTextArray = new Text[EquipmentLevel, ItemType]
            {

                { shieldLevelTexts[(int)EquipmentLevelText.FirstLevel],
                shieldLevelTexts[(int)EquipmentLevelText.SecondLevel],
                shieldLevelTexts[(int)EquipmentLevelText.ThirdLevel] },

                { shieldLevelTexts[(int)EquipmentLevelText.ForthLevel],
                shieldLevelTexts[(int)EquipmentLevelText.FifthLevel],
                shieldLevelTexts[(int)EquipmentLevelText.SixthLevel]},
            };

            weaponItemTextGroup = new GameObject[EquipmentLevel]
            {
                weaponLevelTextGroups[(int)EquipmentLevelText.FirstLevel],
                weaponLevelTextGroups[(int)EquipmentLevelText.SecondLevel],

            };
            shieldItemTextGroup = new GameObject[EquipmentLevel]
            {
                shieldLevelTextGroups[(int)EquipmentLevelText.FirstLevel],
                shieldLevelTextGroups[(int)EquipmentLevelText.SecondLevel],
            };

            for (int i = 0; i < EquipmentLevel; i++)
            {
                weaponTextArray[i, (int)EquipmentLevelText.FirstLevel].text = weaponNecessaryItem[i, (int)ItemTypeList.Wood].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
                weaponTextArray[i, (int)EquipmentLevelText.SecondLevel].text = weaponNecessaryItem[i, (int)ItemTypeList.Iron].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
                weaponTextArray[i, (int)EquipmentLevelText.ThirdLevel].text = weaponNecessaryItem[i, (int)ItemTypeList.Soil].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.


                //리소스 텍스트 어레이 쉴드랑 웨폰따라 나누기
                shieldTextArray[i, (int)EquipmentLevelText.FirstLevel].text = shieldNecessaryItem[i, (int)ItemTypeList.Wood].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
                shieldTextArray[i, (int)EquipmentLevelText.SecondLevel].text = shieldNecessaryItem[i, (int)ItemTypeList.Iron].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
                shieldTextArray[i, (int)EquipmentLevelText.ThirdLevel].text = shieldNecessaryItem[i, (int)ItemTypeList.Soil].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.
            }
            //레벨에 따른 버튼 on/ off를 위해 false로 지정
            weaponButton[(int)ItemButton.SecondWeaponAndShield].enabled = false;
            shieldButton[(int)ItemButton.SecondWeaponAndShield].enabled = false;
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
                weaponButton[(int)ItemButton.SecondWeaponAndShield].enabled = true;
            }
            if (playerShieldLevel == 2)
            {
                shieldButton[(int)ItemButton.SecondWeaponAndShield].enabled = true;
            }
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어가 소지한 나무=" + playerItem[0] + "플레이어가 소지한 철=" +
                playerItem[1] + "플레이어가 소지한 흙=" + playerItem[2]);
            LogManager.Instance.UserDebug(LogColor.Green, GetType().Name, "플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);

        }

        void UpgradeWeapon(int value)
        {
            if (playerItem[(int)ItemTypeList.Wood] >= weaponNecessaryItem[value, (int)ItemTypeList.Wood] &&
                playerItem[(int)ItemTypeList.Iron] >= weaponNecessaryItem[value, (int)ItemTypeList.Iron] &&
                playerItem[(int)ItemTypeList.Soil] >= weaponNecessaryItem[value, (int)ItemTypeList.Soil])
            {
                playerWeaponLevel += 1;
                playerItem[(int)ItemTypeList.Wood] -= weaponNecessaryItem[value, (int)ItemTypeList.Wood];
                playerItem[(int)ItemTypeList.Iron] -= weaponNecessaryItem[value, (int)ItemTypeList.Iron];
                playerItem[(int)ItemTypeList.Soil] -= weaponNecessaryItem[value, (int)ItemTypeList.Soil];
                weaponButton[value].interactable = false;
                weaponBlurImage[value].gameObject.SetActive(false);
                weaponLevelTextGroups[value].gameObject.SetActive(false);
            }
            else
            {
                itemID = 0;
                for (int i = 0; i < ItemType; i++)
                {
                    for (int j = 0; j < EquipmentLevel; j++)
                    {
                        SetShieldColor(i, j, itemID);
                    }
                }
            }

        }

        void UpgradeShield(int value)
        {
            //-weaponButton.Length를 해준 이유 : 버튼에서 들어오는 value값을 0부터 1까지로 만들어주기 위해.
            if (playerItem[(int)ItemTypeList.Wood] >= shieldNecessaryItem[value - weaponButton.Length, (int)ItemTypeList.Wood] &&
                playerItem[(int)ItemTypeList.Iron] >= shieldNecessaryItem[value - weaponButton.Length, (int)ItemTypeList.Iron] &&
                playerItem[(int)ItemTypeList.Soil] >= shieldNecessaryItem[value - weaponButton.Length, (int)ItemTypeList.Soil])
            {
                playerShieldLevel += 1;
                playerItem[(int)ItemTypeList.Wood] -= shieldNecessaryItem[value - weaponButton.Length, (int)ItemTypeList.Wood];
                playerItem[(int)ItemTypeList.Iron] -= shieldNecessaryItem[value - weaponButton.Length, (int)ItemTypeList.Iron];
                playerItem[(int)ItemTypeList.Soil] -= shieldNecessaryItem[value - weaponButton.Length, (int)ItemTypeList.Soil];
                shieldButton[value- weaponButton.Length].interactable = false;
                shieldBlurImage[value- weaponButton.Length].gameObject.SetActive(false);
                shieldLevelTextGroups[value- weaponButton.Length].gameObject.SetActive(false);
            }
            else
            {
                itemID = 1;
                for (int i = 0; i < ItemType; i++)
                {
                    for (int j = 0; j < EquipmentLevel; j++)
                    {
                        SetShieldColor(i, j, itemID);
                    }
                }
            }
        }

        void SetShieldColor(int PlayerItem, int NecessaryItemLevel, int ItemID)
        {
            if (ItemID == 0)
            {
                if (playerItem[PlayerItem] < shieldNecessaryItem[NecessaryItemLevel, PlayerItem])
                {
                    weaponTextArray[NecessaryItemLevel, PlayerItem].color = textColor;
                }
            }
            else
            {
                if (playerItem[PlayerItem] < shieldNecessaryItem[NecessaryItemLevel, PlayerItem])
                {
                    shieldTextArray[NecessaryItemLevel, PlayerItem].color = textColor;
                }
            }
        }
    }
}






