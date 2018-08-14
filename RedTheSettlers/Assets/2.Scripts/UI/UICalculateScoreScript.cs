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
        const int playerNumbers = GlobalVariables.maxPlayerNumber; 

        private int tempScore;
        int TotalScore;
        int tempTotalNumber;

        const int tempCardWeightScore = 3000;
        const int tempEquipmentWeightScore = 5000;
        const int tempTendAndMonsterWeightScore = 7000;

        [System.Serializable]
        private struct PlayersCardInfo
        {
            public string InspedtorName;
            public Text PlayerCow;
            public Text PlayerIron;
            public Text PlayerSoil;
            public Text PlayerWater;
            public Text PlayerWheat;
            public Text PlayerWood;
        }
        [SerializeField]
        private PlayersCardInfo[] playersCardInfo;

        [System.Serializable]
        private struct PlayersBonusInfo
        {
            public string InspedtorName;
            public Text PlayerWeapon;
            public Text PlayerShield;
            public Text PlayerTent;
            public Text PlayerKillMonster;
            public Text PlayerTotalScore;
        }
        [SerializeField]
        private PlayersBonusInfo[] playersBonusInfos;

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

        [SerializeField, Header("Player Winner Icons")]
        private Image firstPlayerWinnerIcon;
        [SerializeField]
        private Image secondPlayerWinnerIcon, thirdPlayerWinnerIcon, fourthPlayerWinnerIcon;


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

            gameData.PlayerData[0].StatData.ShieldLevel = 1;
            gameData.PlayerData[1].StatData.ShieldLevel = 3;
            gameData.PlayerData[2].StatData.ShieldLevel = 2;
            gameData.PlayerData[3].StatData.ShieldLevel = 3;
            //<<

            // >>Player Tents Count And Kill Monsters Count

            TileData tileData;
            tileData.LocationX = 8;
            tileData.LocationY = 21;
            tileData.TileLevel = 2;
            tileData.TileType = ItemType.Wood;

            TileData tileData2;
            tileData2.LocationX = 8;
            tileData2.LocationY = 21;
            tileData2.TileLevel = 2;
            tileData2.TileType = ItemType.Wood;

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
            TotalScore = 0;
            tempTotalNumber = 0;

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

            StartCoroutine(ChangeScores());
            StartCoroutine(CalculateTotalScore());
        }

       
        

        IEnumerator ChangeScores()
        {
            if (playersCardInfo.Length <= playerNumbers && playersBonusInfos.Length <= playerNumbers)
            {

                while (tempScore < 50)
                {
                    for (int i = 0; i < playersCardInfo.Length; i++)
                    {
                        if (tempScore <= gameData.PlayerData[i].ItemData.CowNumber)
                        {
                            playersCardInfo[i].PlayerCow.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].ItemData.IronNumber)
                        {
                            playersCardInfo[i].PlayerIron.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].ItemData.SoilNumber)
                        {
                            playersCardInfo[i].PlayerSoil.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].ItemData.WaterNumber)
                        {
                            playersCardInfo[i].PlayerWater.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].ItemData.WheatNumber)
                        {
                            playersCardInfo[i].PlayerWheat.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].ItemData.WoodNumber)
                        {
                            playersCardInfo[i].PlayerWood.text = string.Format("{0:D2}", tempScore);
                        }

                        if (tempScore <= gameData.PlayerData[i].StatData.WeaponLevel)
                        {
                            playersBonusInfos[i].PlayerWeapon.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].StatData.ShieldLevel)
                        {
                            playersBonusInfos[i].PlayerShield.text = string.Format("{0:D2}", tempScore);
                        }

                        if (tempScore <= gameData.PlayerData[i].TileList.Count)
                        {
                            playersBonusInfos[i].PlayerTent.text = string.Format("{0:D2}", tempScore);
                        }
                        if (tempScore <= gameData.PlayerData[i].BossKillCount)
                        {
                            playersBonusInfos[i].PlayerKillMonster.text = string.Format("{0:D2}", tempScore);
                        }

                    }
                    tempScore++;
                    yield return null;
                }

             
            }
            else
            {
                LogManager.Instance.UserDebug(LogColor.Red, GetType().Name, "작업자님 인스펙터 창을 다시 확인해주세요. 플레이어의 숫자가 4명을 넘어갔습니다.");
            }
           
           
        }

        int[] testTotalScore = new int[playerNumbers] {0,0,0,0};

        IEnumerator CalculateTotalScore()
        {
            while (tempTotalNumber < 9999999) //그 배열에서 가장 큰 수 찾기.
            {
                for (int i = 0; i < playerNumbers; i++)
                {
                    testTotalScore[i] = (gameData.PlayerData[i].ItemData.SumOfItem * tempCardWeightScore)
                       + ((gameData.PlayerData[i].StatData.WeaponLevel + gameData.PlayerData[i].StatData.ShieldLevel) * tempEquipmentWeightScore) +
                       ((gameData.PlayerData[i].TileList.Count + gameData.PlayerData[i].BossKillCount) * tempTendAndMonsterWeightScore);

                    if (tempTotalNumber <= testTotalScore[i])
                    {
                        playersBonusInfos[i].PlayerTotalScore.text = string.Format("{0:D2}", tempTotalNumber);
                    }

                }
                tempTotalNumber += 1000;
                yield return null;
            }
            
        }
 

         

        //>>왕관 이미지 보이게하기... 이건 어떻게 해야할까 도무지 떠오르지를 않네
        public void ShowWinnerIcon()
        {
            if (double.Parse(playersBonusInfos[0].PlayerTotalScore.text) < double.Parse(playersBonusInfos[1].PlayerTotalScore.text))
            {
                secondPlayerWinnerIcon.gameObject.SetActive(true);
            }
            else
            {
                firstPlayerWinnerIcon.gameObject.SetActive(true);
            }
            
           
        }

    }
}
