using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;

/// <summary>
/// 작성자 : 김하정
/// 마지막에 점수 계산을 해주는 UI
/// 나중에 델리게이트로 받을예정
/// </summary>
namespace RedTheSettlers.UI
{
    public class UICalculateScoreScript : MonoBehaviour
    {

        const int playerNumbers = 4;

        private int tempScore;
        private int calculateTotalScore;

        const int tempCardWeightScore = 3000;
        const int tempEquipmentWeightScore = 5000;
        const int tempTendAndMonsterWeightScore = 7000;


        [SerializeField, Header("Card Texts")]
        private Text firstPlayerCow;
        [SerializeField]
        private Text firstPlayerIron, firstPlayerSoil, firstPlayerWater, firstPlayerWheat, firstPlayerWood;
        [SerializeField]
        private Text secondPlayerCow, secondPlayerIron, secondPlayerSoil, secondPlayerWater, secondPlayerWheat, secondPlayerWood;
        [SerializeField]
        private Text thirdPlayerCow, thirdPlayerIron, thirdPlayerSoil, thirdPlayerWater, thirdPlayerWheat, thirdPlayerWood;
        [SerializeField]
        private Text fourthPlayerCow, fourthPlayerIron, fourthPlayerSoil, fourthPlayerWater, fourthPlayerWheat, fourthPlayerWood;

        [SerializeField, Header("Weight Score Texts")]
        private Text firstPlayerTotalScore;
        [SerializeField]
        private Text firstPlayerCardsWeight, firstPlayerEquipmentWeight, firstPlayerTendAndMonsterWeight;

        [SerializeField, Space(10)]
        private Text secondPlayerTotalScore;
        [SerializeField]
        private Text secondPlayerCardsWeight, secondPlayerEquipmentWeight, secondPlayerTendAndMonsterWeight;

        [SerializeField, Space(10)]
        private Text thirdPlayerTotalScore;
        [SerializeField]
        private Text thirdPlayerCardsWeight, thirdPlayerEquipmentWeight, thirdPlayerTendAndMonsterWeight;

        [SerializeField, Space(10)]
        private Text fourthPlayerTotalScore;
        [SerializeField]
        private Text fourthPlayerCardsWeight, fourthPlayerEquipmentWeight, fourthPlayerTendAndMonsterWeight;

        [SerializeField, Header("Equipment And Tents, Monster  Texts")]
        private Text firstPlayerWeapon;
        [SerializeField ]
        private Text  firstPlayerShield, firstPlayerTents, firstPlayerKillBoss;

        [SerializeField, Space(10)]
        private Text secondPlayerWeapon;
        [SerializeField]
        private Text secondPlayerShield, secondPlayerTents, secondPlayerKillBoss;

        [SerializeField, Space(10)]
        private Text thirdPlayerWeapon;
        [SerializeField]
        private Text thirdPlayerShield, thirdPlayerTents, thirdPlayerKillBoss;

        [SerializeField, Space(10)]
        private Text fourthPlayerWeapon;
        [SerializeField]
        private Text fourthPlayerShield, fourthPlayerTents, fourthPlayerKillBoss;

        //배열 사용.... 대신 인스펙터에서 사용하는 것이 아니라 인스펙터에서 받아온 텍스트 오브젝트들을 배열로 만들어
        //아래서 값을 넣어줄때 사용할 예정.
        private Text[] playersCowCards, playersIronCards, playersSoilCards, playersWaterCards, playersWheatCards, playersWoodCards;
        private Text[] playersWeapon, playersShield, playersTent, playersKillMonster, playersTotalScore;

        private GameData gameData;

        //임시 데이터임 나중에 삭제될 예정.
        private void Awake()
        {
            //Initial Weight Score Text


            gameData = new GameData(4);

            //>>Resource<<
            gameData.PlayerData[0].ItemData.CowNumber = 1;
            gameData.PlayerData[1].ItemData.CowNumber = 2;
            gameData.PlayerData[2].ItemData.CowNumber = 3;
            gameData.PlayerData[3].ItemData.CowNumber = 4;

            gameData.PlayerData[0].ItemData.WaterNumber = 5;
            gameData.PlayerData[1].ItemData.WaterNumber = 15;
            gameData.PlayerData[2].ItemData.WaterNumber = 20;
            gameData.PlayerData[3].ItemData.WaterNumber = 25;

            gameData.PlayerData[0].ItemData.WheatNumber = 5;
            gameData.PlayerData[1].ItemData.WheatNumber = 6;
            gameData.PlayerData[2].ItemData.WheatNumber = 7;
            gameData.PlayerData[3].ItemData.WheatNumber = 8;

            gameData.PlayerData[0].ItemData.WoodNumber = 2;
            gameData.PlayerData[1].ItemData.WoodNumber = 4;
            gameData.PlayerData[2].ItemData.WoodNumber = 6;
            gameData.PlayerData[3].ItemData.WoodNumber = 8;

            gameData.PlayerData[0].ItemData.IronNumber = 4;
            gameData.PlayerData[1].ItemData.IronNumber = 8;
            gameData.PlayerData[2].ItemData.IronNumber = 12;
            gameData.PlayerData[3].ItemData.IronNumber = 16;

            gameData.PlayerData[0].ItemData.SoilNumber = 3;
            gameData.PlayerData[1].ItemData.SoilNumber = 6;
            gameData.PlayerData[2].ItemData.SoilNumber = 9;
            gameData.PlayerData[3].ItemData.SoilNumber = 12;
            //<<

            //>>Equipement
            gameData.PlayerData[0].StatData.WeaponLevel = 2;
            gameData.PlayerData[1].StatData.WeaponLevel = 1;
            gameData.PlayerData[2].StatData.WeaponLevel = 3;
            gameData.PlayerData[3].StatData.WeaponLevel = 2;

            gameData.PlayerData[0].StatData.ArmorLevel = 1;
            gameData.PlayerData[1].StatData.ArmorLevel = 3;
            gameData.PlayerData[2].StatData.ArmorLevel = 2;
            gameData.PlayerData[3].StatData.ArmorLevel = 3;
            //<<


            // >>Player Tents Count And Kill Monsters Count

            TileData tileData;
            tileData.LocationX = 8;
            tileData.LocationY = 21;
            tileData.TileLevel = 2;
            tileData.TileType = TileType.Wood;

            TileData tileData2;
            tileData2.LocationX = 8;
            tileData2.LocationY = 21;
            tileData2.TileLevel = 2;
            tileData2.TileType = TileType.Wood;

            gameData.PlayerData[0].TileList.Add(tileData);
            gameData.PlayerData[0].TileList.Add(tileData2);
            gameData.PlayerData[1].TileList.Add(tileData);
            gameData.PlayerData[2].TileList.Add(tileData);
            gameData.PlayerData[3].TileList.Add(tileData);

            gameData.PlayerData[0].BossKillCount = 3;
            gameData.PlayerData[1].BossKillCount = 5;
            gameData.PlayerData[2].BossKillCount = 7;
            gameData.PlayerData[3].BossKillCount = 9;
            //<<


        }

        void Start()
        {
            tempScore = 0;
            calculateTotalScore = 0;

            //가중치 넣어줌
            firstPlayerCardsWeight.text = tempCardWeightScore.ToString();
            secondPlayerCardsWeight.text = tempCardWeightScore.ToString();
            thirdPlayerCardsWeight.text = tempCardWeightScore.ToString();
            fourthPlayerCardsWeight.text = tempCardWeightScore.ToString();

            firstPlayerEquipmentWeight.text = tempEquipmentWeightScore.ToString();
            secondPlayerEquipmentWeight.text = tempEquipmentWeightScore.ToString();
            thirdPlayerEquipmentWeight.text = tempEquipmentWeightScore.ToString();
            fourthPlayerEquipmentWeight.text = tempEquipmentWeightScore.ToString();

            firstPlayerTendAndMonsterWeight.text = tempTendAndMonsterWeightScore.ToString();
            secondPlayerTendAndMonsterWeight.text = tempTendAndMonsterWeightScore.ToString();
            thirdPlayerTendAndMonsterWeight.text = tempTendAndMonsterWeightScore.ToString();
            fourthPlayerTendAndMonsterWeight.text = tempTendAndMonsterWeightScore.ToString();

            //>>Card Items 6개(플레이어 기준)
            playersCowCards = new Text[4]
           { firstPlayerCow, secondPlayerCow, thirdPlayerCow, fourthPlayerCow };

            playersIronCards = new Text[4]
            { firstPlayerIron, secondPlayerIron, thirdPlayerIron, fourthPlayerIron };

            playersSoilCards = new Text[4]
            { firstPlayerSoil, secondPlayerSoil, thirdPlayerSoil, fourthPlayerSoil };

            playersWaterCards = new Text[4]
            { firstPlayerWater, secondPlayerWater, thirdPlayerWater, fourthPlayerWater };

            playersWheatCards = new Text[4]
            { firstPlayerWheat, secondPlayerWheat, thirdPlayerWheat, fourthPlayerWheat };

            playersWoodCards = new Text[4]
            { firstPlayerWood, secondPlayerWood, thirdPlayerWood, fourthPlayerWood };
            //<<

            //>>무기, 방어구, 텐트, 죽인 몬스터 수, 총 점수(플레이어 기준)
            playersWeapon = new Text[4]
            { firstPlayerWeapon, secondPlayerWeapon, thirdPlayerWeapon, fourthPlayerWeapon};

            playersShield = new Text[4]
            { firstPlayerShield, secondPlayerShield, thirdPlayerShield, fourthPlayerShield};

            playersTent = new Text[4]
            { firstPlayerTents, secondPlayerTents, thirdPlayerTents, fourthPlayerTents};

            playersKillMonster = new Text[4]
            { firstPlayerKillBoss, secondPlayerKillBoss, thirdPlayerKillBoss, fourthPlayerKillBoss};

            playersTotalScore = new Text[4]
            { firstPlayerTotalScore, secondPlayerTotalScore, thirdPlayerTotalScore, fourthPlayerTotalScore};
               //<<
        }

        private void ChangeCardScores()
        {
            for (int i = 0; i < playerNumbers; i++)
            {
                if (int.Parse(playersCowCards[i].text) <  gameData.PlayerData[i].ItemData.CowNumber)
                {
                    playersCowCards[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersIronCards[i].text) < gameData.PlayerData[i].ItemData.IronNumber)
                {
                    playersIronCards[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersSoilCards[i].text) <  gameData.PlayerData[i].ItemData.SoilNumber)
                {
                    playersSoilCards[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersWaterCards[i].text) <  gameData.PlayerData[i].ItemData.WaterNumber)
                {
                    playersWaterCards[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersWheatCards[i].text) <  gameData.PlayerData[i].ItemData.WheatNumber)
                {
                    playersWheatCards[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersWoodCards[i].text) < gameData.PlayerData[i].ItemData.WoodNumber)
                {
                    playersWoodCards[i].text = string.Format("{0:D2}", tempScore);
                }
            }
             
        }

        private void ChangeEquipmentScore()
        {
             
            for (int i = 0; i < playerNumbers; i++)
            {
                if (int.Parse(playersWeapon[i].text) < gameData.PlayerData[i].StatData.WeaponLevel)
                {
                    playersWeapon[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersShield[i].text) < gameData.PlayerData[i].StatData.ArmorLevel)
                {
                    playersShield[i].text = string.Format("{0:D2}", tempScore);
                }

            }
             
        }

        private void ChangeTentAndMonsterScore()
        {

            for (int i = 0; i < playerNumbers; i++)
            {
                if (int.Parse(playersTent[i].text) < gameData.PlayerData[i].TileList.Count)
                {
                    playersTent[i].text = string.Format("{0:D2}", tempScore);
                }
                if (int.Parse(playersKillMonster[i].text) < gameData.PlayerData[i].BossKillCount)
                {
                    playersKillMonster[i].text = string.Format("{0:D2}", tempScore);
                }

            }
            tempScore++;
        }

        private void CalculateTotalScore()
        {
            int tempTotalNumber = 0; 
            for (int i = 0; i < playerNumbers; i++)
            {
                tempTotalNumber = (gameData.PlayerData[i].ItemData.CowNumber + gameData.PlayerData[i].ItemData.IronNumber
                    + gameData.PlayerData[i].ItemData.SoilNumber  + gameData.PlayerData[i].ItemData.WaterNumber
                    + gameData.PlayerData[i].ItemData.WheatNumber + gameData.PlayerData[i].ItemData.WoodNumber)
                    * tempCardWeightScore;
                playersTotalScore[i].text = tempTotalNumber.ToString();
            }
        }

        int tempflag = 1;
        private float TimeLeft = 0.05f;
        private float nextTime = 0.0f;
 
        private void Update()
        {
            if (tempflag==1 && Time.time>nextTime)
            {
                nextTime = Time.time + TimeLeft;
                ChangeCardScores();
                ChangeEquipmentScore();
                ChangeTentAndMonsterScore();
            }
            
        }



    }
}
  