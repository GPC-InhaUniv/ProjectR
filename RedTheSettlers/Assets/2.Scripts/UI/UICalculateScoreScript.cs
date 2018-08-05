using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICalculateScoreScript : MonoBehaviour
{

    private int tempScore = 0;

    [Header("Player Cards Text")]
    [SerializeField]
    private Text[] firstPlayerCardsText;
    [SerializeField]
    private Text[] secondPlayerCardsText;
    [SerializeField]
    private Text[] thirdPlayerCardsText;
    [SerializeField]
    private Text[] forthPlayerCardsText;
    [Header("Player Weight Score")]
    [SerializeField]
    private Text[] cardsWeighttScoreText;
    [Header("Player Equipments Text")]
    [SerializeField]
    private Text[] firstPlayerEquipmentsText = new Text[2];
    [SerializeField]
    private Text[] secondPlayerEquipmentsText = new Text[2];
    [SerializeField]
    private Text[] thirdPlayerEquipmentsText = new Text[2];
    [SerializeField]
    private Text[] forthPlayerEquipmentsText = new Text[2];



    //Initial Weight Score Text
    private int tempCardWeightScore = 3000;
    private int tempEquipmentWeightScore = 5000;
    private int tempTendAndMonsterWeightScore = 7000;

     
    [Header("Card Score Num Max")]
    [SerializeField]
    private int[] firstPlayerCardsNumMax = new int[6];
    [SerializeField]
    private int[] secondPlayerCardsNumMax = new int[6];
    [SerializeField]
    private int[] thirdPlayerCardsNumMax = new int[6];
    [SerializeField]
    private int[] forthPlayerCardsNumMax = new int[6];

    [Header("Equipment Score Num Max")]
    [SerializeField]
    private int[] firstPlayerEquipmentNumMax = new int[2];
    [SerializeField]
    private int[] secondPlayerEquipmentNumMax = new int[2];
    [SerializeField]
    private int[] thirdPlayerEquipmentNumMax = new int[2];
    [SerializeField]
    private int[] forthPlayerEquipmentNumMax = new int[2];

    [Header("Tent And Monster Score Num Max")]
    [SerializeField]
    private int[] firstPlayerTMNumMax = new int[2];
    [SerializeField]
    private int[] secondPlayerTMNumMax = new int[2];
    [SerializeField]
    private int[] thirdPlayerTMNumMax = new int[2];
    [SerializeField]
    private int[] forthPlayerTMNumMax = new int[2];


    // Use this for initialization
    void Start()
    {
         
        //가중치 점수 넣어주기
        for (int i = 0; i < cardsWeighttScoreText.Length; i++)
        {
            if (i % 3 == 0)
            {
                cardsWeighttScoreText[i].text = tempCardWeightScore.ToString();
            }
            else if (i % 3 == 1)
            {
                cardsWeighttScoreText[i].text = tempEquipmentWeightScore.ToString();

            }
            else
            {
                cardsWeighttScoreText[i].text = tempTendAndMonsterWeightScore.ToString();
            }
        }


        //플레이어 카드 개수 받아오기
        //ChangePlaerScore();

    }


    //자원 최대값 받아서 저장
    //void ChangePlaerScore()
    //{
    //    for (int i = 0; i < firstPlayerCardsText.Length; i++)
    //    {
    //        firstPlayerCardsNumMax[i] = 0;
    //        secondPlayerCardsNumMax[i] = 0;
    //        thirdPlayerCardsNumMax[i] = 0;
    //        forthPlayerCardsNumMax[i] = 0;
    //    }
    //}

    private void ChangeCardScores()
    {
        tempScore++;
        for (int i = 0; i < firstPlayerCardsText.Length; i++)
        {
            if (int.Parse(firstPlayerCardsText[i].text) < firstPlayerCardsNumMax[i])
            {
                firstPlayerCardsText[i].text = string.Format("{0:D2}", tempScore);
            }
            if (int.Parse(secondPlayerCardsText[i].text) < secondPlayerCardsNumMax[i])
            {
                secondPlayerCardsText[i].text = string.Format("{0:D2}", tempScore);
            }
            if (int.Parse(thirdPlayerCardsText[i].text) < thirdPlayerCardsNumMax[i])
            {
                thirdPlayerCardsText[i].text = string.Format("{0:D2}", tempScore);
            }
            if (int.Parse(forthPlayerCardsText[i].text) < forthPlayerCardsNumMax[i])
            {
                forthPlayerCardsText[i].text = string.Format("{0:D2}", tempScore);
            }
             
        }
    }

    private void ChangeEquipmentScores()
    {
        tempScore++;
        for (int i = 0; i < firstPlayerEquipmentsText.Length; i++)
        {
            if (int.Parse(firstPlayerEquipmentsText[i].text) < firstPlayerEquipmentNumMax[i])
            {
                firstPlayerEquipmentsText[i].text = string.Format("{0:D2}", tempScore);
            }
            if (int.Parse(secondPlayerEquipmentsText[i].text) < secondPlayerEquipmentNumMax[i])
            {
                secondPlayerEquipmentsText[i].text = string.Format("{0:D2}", tempScore);
            }
            if (int.Parse(thirdPlayerEquipmentsText[i].text) < thirdPlayerEquipmentNumMax[i])
            {
                thirdPlayerEquipmentsText[i].text = string.Format("{0:D2}", tempScore);
            }
            if (int.Parse(forthPlayerEquipmentsText[i].text) < forthPlayerEquipmentNumMax[i])
            {
                forthPlayerEquipmentsText[i].text = string.Format("{0:D2}", tempScore);
            }
        }
    }

    private void ChangeTentAndMonsterScores()
    {

    }

    void Update()
    {
        ChangeCardScores();
        ChangeEquipmentScores();
    }
}
