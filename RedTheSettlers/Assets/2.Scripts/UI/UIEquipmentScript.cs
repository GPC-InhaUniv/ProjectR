using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 김하정
/// 쉴드 첫번째 왜 뒤늦게 글자가 빨갛게 변하는지
/// 한번 interactable false된 버튼을 언제 되돌려야할지.
/// </summary>

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
    private Text[,] resourceTextArray;

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

        shieldNecessaryResourcesArray = new int[4, 3]
         {
             { 0,0,0},
             { 0,0,0},
            { 5,3,3 },
            { 10,5,5 }
          };



        playerResourceArray = new int[3]
        {
            tempResourceCounts[0],
            tempResourceCounts[1],
            tempResourceCounts[2],
        };

        resourceTextArray = new Text[4, 3]
        {
            { weaponLevelTexts[0], weaponLevelTexts[1], weaponLevelTexts[2] },
            { weaponLevelTexts[3], weaponLevelTexts[4], weaponLevelTexts[5] },
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
            resourceTextArray[i, 0].text = weaponNecessaryResourcesArray[i, 0].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
            resourceTextArray[i, 1].text = weaponNecessaryResourcesArray[i, 1].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
            resourceTextArray[i, 2].text = weaponNecessaryResourcesArray[i, 2].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.

            //리소스 텍스트 어레이 쉴드랑 웨폰따라 나누기
            resourceTextArray[i, 0].text = shieldNecessaryResourcesArray[i, 0].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
            resourceTextArray[i, 1].text = shieldNecessaryResourcesArray[i, 1].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
            resourceTextArray[i, 2].text = shieldNecessaryResourcesArray[i, 2].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.
        }
        //레벨에 따른 버튼 on/ off를 위해 false로 지정
        // buttonArray[1].enabled = false;
        //buttonArray[3].enabled = false;
    }

    public void OnClickedEquipmentButton(int value)
    {
           
        switch (value)
        {
            case 0:
                
                UpgradeWeapon(value);
                 
                break;
            case 1:
                UpgradeWeapon(value);
                 
                break;
            case 2:
                UpgradeShield(value);
                
                break;
            case 3:
                UpgradeShield(value);
                 
                break;
            default:
                break;
        }
    }

    void UpgradeWeapon(int level)
    {
        if (playerResourceArray[0] >= weaponNecessaryResourcesArray[level, 0] &&
            playerResourceArray[1] >= weaponNecessaryResourcesArray[level, 1] &&
            playerResourceArray[2] >= weaponNecessaryResourcesArray[level, 2])
        {
            playerWeaponLevel += 1;
            playerResourceArray[0] -= weaponNecessaryResourcesArray[level, 0];
            playerResourceArray[1] -= weaponNecessaryResourcesArray[level, 1];
            playerResourceArray[2] -= weaponNecessaryResourcesArray[level, 2];
            buttonArray[level].interactable = false;
            blurImageArray[level].gameObject.SetActive(false);
            resourceTextGroupArray[level].gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                if (playerResourceArray[0] < weaponNecessaryResourcesArray[i, 0])
                {
                    resourceTextArray[i, 0].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                   
                }
                if (playerResourceArray[1] < weaponNecessaryResourcesArray[i, 1])
                {
                    resourceTextArray[i, 1].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                    
                }
                if (playerResourceArray[2] < weaponNecessaryResourcesArray[i, 2])
                {
                    resourceTextArray[i, 2].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                     
                }
            }
            

        }
    }

    void UpgradeShield(int level)
    {
        if (playerResourceArray[0] >= shieldNecessaryResourcesArray[level, 0] &&
            playerResourceArray[1] >= shieldNecessaryResourcesArray[level , 1] &&
            playerResourceArray[2] >= shieldNecessaryResourcesArray[level, 2])
        {
            playerShieldLevel += 1;
            playerResourceArray[0] -= shieldNecessaryResourcesArray[level , 0];
            playerResourceArray[1] -= shieldNecessaryResourcesArray[level , 1];
            playerResourceArray[2] -= shieldNecessaryResourcesArray[level , 2];
            buttonArray[level].interactable = false;
            blurImageArray[level].gameObject.SetActive(false);
            resourceTextGroupArray[level].gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                if (playerResourceArray[0] < shieldNecessaryResourcesArray[i, 0])
                {
                    resourceTextArray[i+2, 0].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기

                }
                if (playerResourceArray[1] < shieldNecessaryResourcesArray[i, 1])
                {
                    resourceTextArray[i+2, 1].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기

                }
                if (playerResourceArray[2] < shieldNecessaryResourcesArray[i, 2])
                {
                    resourceTextArray[i+2, 2].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기

                }
            }
        }
    }
}



            


