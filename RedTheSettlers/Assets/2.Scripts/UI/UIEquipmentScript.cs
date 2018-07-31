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
    private int[,] necessaryResourcesArray;
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

        necessaryResourcesArray = new int[4, 3]
         {
            { 3,5,5 },
            { 10,15,15 },
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

        for (int i = 0; i < blurImageArray.Length; i++)
        {
            resourceTextArray[i, 0].text = necessaryResourcesArray[i, 0].ToString(); //업그레이드에 필요한 나무 개수를 넣어준다.
            resourceTextArray[i, 1].text = necessaryResourcesArray[i, 1].ToString(); //업그레이드에 필요한 소지한 철 개수를 넣어준다.
            resourceTextArray[i, 2].text = necessaryResourcesArray[i, 2].ToString(); //업그레이드에 필요한 소지한 흙 개수를 넣어준다.
        }
        //레벨에 따른 버튼 on/off를 위해 false로 지정
        buttonArray[1].enabled = false;
        buttonArray[3].enabled = false;
    }

    public void OnClickedEquipmentButton(int value)
    {
       

        for (int i = 0; i < playerResourceArray.Length + 1; i++)
        {
           
            if (playerResourceArray[0] < necessaryResourcesArray[i, 0])
            {
                resourceTextArray[i, 0].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                buttonArray[i].interactable = false;
            }
            if (playerResourceArray[1] < necessaryResourcesArray[i, 1])
            {
                resourceTextArray[i, 1].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                buttonArray[i].interactable = false;
            }
            if (playerResourceArray[2] < necessaryResourcesArray[i, 2])
            {
                resourceTextArray[i, 2].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                buttonArray[i].interactable = false;
            }
            if (playerResourceArray[0] >= necessaryResourcesArray[i, 0] &&
            playerResourceArray[1] >= necessaryResourcesArray[i, 1] &&
            playerResourceArray[2] >= necessaryResourcesArray[i, 2]  )
            {
                resourceTextGroupArray[value].gameObject.SetActive(false); //그룹도 배열로 만들어서 끄자.
                blurImageArray[value].gameObject.SetActive(false);
                buttonArray[value].interactable = false;
            }
        }

        playerResourceArray[0] -= necessaryResourcesArray[value, 0];
        playerResourceArray[1] -= necessaryResourcesArray[value, 1];
        playerResourceArray[2] -= necessaryResourcesArray[value, 2];

        //플레이어 레벨저장과 레벨에따른 버튼 선택 막기
        if (resourceTextGroupArray[0].gameObject.activeSelf == false)
        {
            playerWeaponLevel = 2;
            buttonArray[1].enabled = true;
        }
        if (resourceTextGroupArray[1].gameObject.activeSelf == false)
            playerWeaponLevel = 3;

        if (resourceTextGroupArray[2].gameObject.activeSelf == false)
        {
            playerShieldLevel = 2;
            buttonArray[3].enabled = true;
        }
        if (resourceTextGroupArray[3].gameObject.activeSelf == false)
          playerShieldLevel = 3;

        Debug.Log("플레이어가 소지한 나무=" + playerResourceArray[0] + "플레이어가 소지한 철=" +
            playerResourceArray[1] + "플레이어가 소지한 흙=" + playerResourceArray[2]);
        Debug.Log("플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은" + playerShieldLevel);
    }
}


