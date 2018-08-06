using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 작성자 : 김하정
/// </summary>
public class UICalculateScoreScript : MonoBehaviour
{

    private int tempScore;

    [Header("Player Cards Text")]
    [SerializeField]
    private Text[] playersCowCardText = new Text[4];
    [SerializeField]
    private Text[] playersWaterCardText = new Text[4];
    [SerializeField]
    private Text[] playersWheatCardtText = new Text[4];
    [SerializeField]
    private Text[] playersWoodCardText = new Text[4];
    [SerializeField]
    private Text[] playerIronCardText = new Text[4];
    [SerializeField]
    private Text[] playerSoilCardText = new Text[4];

    [Header("Player Weight Score")]
    [SerializeField]
    private Text[] cardsWeighttScoreText = new Text[12];

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

    private GameData gameData;

    private void Awake()
    {
        gameData = new GameData(4);
        gameData.PlayerData[0].ResourceData.CowNum = 1;
        gameData.PlayerData[1].ResourceData.CowNum = 2;
        gameData.PlayerData[2].ResourceData.CowNum = 3;
        gameData.PlayerData[3].ResourceData.CowNum = 4;

        gameData.PlayerData[0].ResourceData.WaterNum = 10;
        gameData.PlayerData[1].ResourceData.WaterNum = 20;
        gameData.PlayerData[2].ResourceData.WaterNum = 30;
        gameData.PlayerData[3].ResourceData.WaterNum = 40;

        gameData.PlayerData[0].ResourceData.WheatNum = 5;
        gameData.PlayerData[1].ResourceData.WheatNum = 6;
        gameData.PlayerData[2].ResourceData.WheatNum = 7;
        gameData.PlayerData[3].ResourceData.WheatNum = 8;

        gameData.PlayerData[0].ResourceData.WoodNum = 50;
        gameData.PlayerData[1].ResourceData.WoodNum = 60;
        gameData.PlayerData[2].ResourceData.WoodNum = 70;
        gameData.PlayerData[3].ResourceData.WoodNum = 80;

        gameData.PlayerData[0].ResourceData.IronNum = 12;
        gameData.PlayerData[1].ResourceData.IronNum = 21;
        gameData.PlayerData[2].ResourceData.IronNum = 31;
        gameData.PlayerData[3].ResourceData.IronNum = 41;

        gameData.PlayerData[0].ResourceData.SoilNum = 15;
        gameData.PlayerData[1].ResourceData.SoilNum = 25;
        gameData.PlayerData[2].ResourceData.SoilNum = 53;
        gameData.PlayerData[3].ResourceData.SoilNum = 45;
    }


    void Start()
    {
        tempScore = 0;

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

        StartCoroutine(ChangeTest());
    }

    void Update()
    {
        //ChangeCardScore();
    }



    IEnumerator ChangeTest()
    {
        for (int i = 0; i < playersCowCardText.Length; i++)
        {
            tempScore = 0;
            while (tempScore < 100)
            {
                tempScore++;
                if (int.Parse(playersCowCardText[i].text) < gameData.PlayerData[i].ResourceData.CowNum)
                {
                    playersCowCardText[i].text = string.Format("{0:D2}", tempScore);
                }

                if (int.Parse(playersWaterCardText[i].text) < gameData.PlayerData[i].ResourceData.WaterNum)
                {
                    playersWaterCardText[i].text = string.Format("{0:D2}", tempScore);
                }

                if (int.Parse(playersWheatCardtText[i].text) < gameData.PlayerData[i].ResourceData.WheatNum)
                {
                    playersWheatCardtText[i].text = string.Format("{0:D2}", tempScore);
                }

                if (int.Parse(playersWoodCardText[i].text) < gameData.PlayerData[i].ResourceData.WoodNum)
                {
                    playersWoodCardText[i].text = string.Format("{0:D2}", tempScore);
                }

                if (int.Parse(playerIronCardText[i].text) < gameData.PlayerData[i].ResourceData.IronNum)
                {
                    playerIronCardText[i].text = string.Format("{0:D2}", tempScore);
                }

                if (int.Parse(playerSoilCardText[i].text) < gameData.PlayerData[i].ResourceData.SoilNum)
                {
                    playerSoilCardText[i].text = string.Format("{0:D2}", tempScore);
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return null;
    }



    //private void ChangeCardScore()
    //{
    //    for (int i = 0; i < playersCowCardText.Length; i++)
    //    {
    //        tempScore++;
    //        if (int.Parse(playersCowCardText[i].text) < gameData.PlayerData[i].ResourceData.CowNum)
    //        {
    //            playersCowCardText[i].text = string.Format("{0:D2}", tempScore);
    //        }

    //        if (int.Parse(playersWaterCardText[i].text) < gameData.PlayerData[i].ResourceData.WaterNum)
    //        {
    //            playersWaterCardText[i].text = string.Format("{0:D2}", tempScore);
    //        }

    //        if (int.Parse(playersWheatCardtText[i].text) < gameData.PlayerData[i].ResourceData.WheatNum)
    //        {
    //            playersWheatCardtText[i].text = string.Format("{0:D2}", tempScore);
    //        }

    //        if (int.Parse(playersWoodCardText[i].text) < gameData.PlayerData[i].ResourceData.WoodNum)
    //        {
    //            playersWoodCardText[i].text = string.Format("{0:D2}", tempScore);
    //        }

    //        if (int.Parse(playerIronCardText[i].text) < gameData.PlayerData[i].ResourceData.IronNum)
    //        {
    //            playerIronCardText[i].text = string.Format("{0:D2}", tempScore);
    //        }

    //        if (int.Parse(playerSoilCardText[i].text) < gameData.PlayerData[i].ResourceData.SoilNum)
    //        {
    //            playerSoilCardText[i].text = string.Format("{0:D2}", tempScore);
    //        }


    //    }
    //}

  
}
