using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 김하정
/// </summary>

public class UIEquipmentScript : MonoBehaviour
{
    
    private int playerWeaponLevel =1;
    private int playerShieldLevel=1;

    [SerializeField]
    private Image weaponLevel2BlurImage;
    [SerializeField]
    private Image weaponLevel3BlurImage;

    [SerializeField]
    private Image shieldLevel2BlurImage;
    [SerializeField]
    private Image shieldLevel3BlurImage;

    [SerializeField]
    private Button weaponLevel1Button;
    [SerializeField]
    private Button weaponLevel2Button;
    [SerializeField]
    private Button weaponLevel3Button;
    [SerializeField]
    private Button shieldLevel1Button;
    [SerializeField]
    private Button shieldLevel2Button;
    [SerializeField]
    private Button shieldLevel3Button;


    [SerializeField]
    private int tempWoodResourceCount;
    [SerializeField]
    private int tempIronResourceCount;
    [SerializeField]
    private int tempSoilResouceCount;

    [SerializeField]
    private GameObject weaponLevel2TextGroup;
    [SerializeField]
    private Text weaponLevel2WoodText;
    [SerializeField]
    private Text weaponLevel2IronText;
    [SerializeField]
    private Text weaponLevel2SoilText;

    [SerializeField]
    private GameObject weaponLevel3TextGroup;
    [SerializeField]
    private Text weaponLevel3WoodText;
    [SerializeField]
    private Text weaponLevel3IronText;
    [SerializeField]
    private Text weaponLevel3SoilText;

    [SerializeField]
    private GameObject shieldLevel2TextGroup;
    [SerializeField]
    private Text shieldLevel2WoodText;
    [SerializeField]
    private Text shieldLevel2IronText;
    [SerializeField]
    private Text shieldLevel2SoilText;

    [SerializeField]
    private GameObject shieldLevel3TextGroup;
    [SerializeField]
    private Text shieldLevel3WoodText;
    [SerializeField]
    private Text shieldLevel3IronText;
    [SerializeField]
    private Text shieldLevel3SoilText;

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
            weaponLevel2Button,
            weaponLevel3Button,
            shieldLevel2Button,
            shieldLevel3Button,
        };

        blurImageArray = new Image[4]
        {
             weaponLevel2BlurImage,
             weaponLevel3BlurImage,
             shieldLevel2BlurImage,
             shieldLevel3BlurImage,
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
            tempWoodResourceCount,
            tempIronResourceCount,
            tempSoilResouceCount,
        };

        resourceTextArray = new Text[4, 3]
        {
            { weaponLevel2WoodText, weaponLevel2IronText, weaponLevel2SoilText },
            { weaponLevel3WoodText, weaponLevel3IronText, weaponLevel3SoilText },
            { shieldLevel2WoodText, shieldLevel2IronText, shieldLevel2SoilText },
            { shieldLevel3WoodText, shieldLevel3IronText, shieldLevel3SoilText},
         };

        resourceTextGroupArray = new GameObject[4]
        {
            weaponLevel2TextGroup,
            weaponLevel3TextGroup,
            shieldLevel2TextGroup,
            shieldLevel3TextGroup
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

        playerResourceArray[0] -= necessaryResourcesArray[value, 0];
        playerResourceArray[1] -= necessaryResourcesArray[value, 1];
        playerResourceArray[2] -= necessaryResourcesArray[value, 2];

        for (int i = 0; i < 4 ; i++)    
        {
            if (playerResourceArray[0] < necessaryResourcesArray[i, 0])
            {
                resourceTextArray[i, 0].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                buttonArray[value].enabled = false;//빨간색으로 글씨 뜬 버튼 선택안되게 하기
                                                             //왜 얘네는 안먹는걸까....

            }
            if (playerResourceArray[1] < necessaryResourcesArray[i, 1])
            {
                resourceTextArray[i, 1].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                buttonArray[value].enabled = false;
               
            }
            if (playerResourceArray[ 2] < necessaryResourcesArray[i, 2])
            {
                resourceTextArray[i, 2].color = new Color(255, 0, 0, 255); //빨간색으로 바꾸기
                buttonArray[value].enabled = false;
            }
            if (playerResourceArray[0] >= necessaryResourcesArray[i, 0] &&
            playerResourceArray[1] >= necessaryResourcesArray[i, 1] &&
            playerResourceArray[2] >= necessaryResourcesArray[i, 2])
            {
                resourceTextGroupArray[value].gameObject.SetActive(false); //그룹도 배열로 만들어서 끄자.
                blurImageArray[value].gameObject.SetActive(false);
                buttonArray[value].enabled = false;
            }
            
           //빨간색으로 글씨 뜬 버튼 선택안되게 하기


        }

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


        Debug.Log("클릭됐음");
        Debug.Log("플레이어가 소지한 나무=" + playerResourceArray[0] + "플레이어가 소지한 철=" +
            playerResourceArray[1] + "플레이어가 소지한 흙=" + playerResourceArray[2]);
        Debug.Log("플레이어의 무기 레벨은" + playerWeaponLevel + "플레이어의 방어 레벨은"+playerShieldLevel);
    }

}


