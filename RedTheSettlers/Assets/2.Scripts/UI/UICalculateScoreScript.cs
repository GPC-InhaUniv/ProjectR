using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using System.Linq;
using System;

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

        const int WinnerImageSize = 15;

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

        [System.Serializable]
        private struct PlayerWinnerImages
        {
            public string InspedtorName;
            public Image WinnerIconImage;
        }
        [SerializeField]
        private PlayerWinnerImages[] playerWinnerImages;

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

        int[] playerTotalScore = new int[playerNumbers] { 0, 0, 0, 0 };

        private GameData gameData;

        enum MyEnum
        {
            cowNumber,
            IronNumber,
            SoilNunber,
            WaterNumber,
            WheatNumber,
            WoodNumber,
            WeaponLevel,
            ShieldLevel,
            TileList,
            BossKillCount,
        }

        UITempData uITempData;
        //임시 데이터임 나중에 삭제될 예정. //메소드에서 가져오는 법 물어보기
        private void Awake()
        {
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

            CalculateTotalScore();
            //코루틴
            for (int i = 0; i < playerNumbers; i++)
            {
                ChangeScores(i);
            }
        }

        private void CalculateTotalScore()
        {
            for (int i = 0; i < playerNumbers; i++)
            {
                playerTotalScore[i] = (gameData.PlayerData[i].ItemData.SumOfItem * tempCardWeightScore)
                + ((gameData.PlayerData[i].StatData.WeaponLevel + gameData.PlayerData[i].StatData.ShieldLevel) * tempEquipmentWeightScore) +
                ((gameData.PlayerData[i].TileList.Count + gameData.PlayerData[i].BossKillCount) * tempTendAndMonsterWeightScore);
            }
        }

        IEnumerator ShowWinnerIcon()
        {
            yield return new WaitForSeconds(2f);
            int maxValue = playerTotalScore.Max();
            int maxIndex = playerTotalScore.ToList().IndexOf(maxValue);
            playerWinnerImages[maxIndex].WinnerIconImage.gameObject.SetActive(true);
            for (int i = WinnerImageSize; i >= 1; i--)
            {
                playerWinnerImages[maxIndex].WinnerIconImage.gameObject.transform.localScale = new Vector3(i, i, i);
                yield return new WaitForSeconds(0.03f);
            }
           

        }

        private void ChangeScores(int playerNumber)
        {
            StartCoroutine(CalculateCardScore(playerNumber));
            StartCoroutine(CalculateEquipmentScore(playerNumber));
            StartCoroutine(CalculatePropertyScore(playerNumber));
            StartCoroutine(CalculateTotalScore(playerNumber));
            StartCoroutine(ShowWinnerIcon());
        }

        IEnumerator CalculateCardScore(int playerNumber)
        {
            for (int i = 0; i < gameData.PlayerData[playerNumber].ItemData.GetMaxItemNumber(); i++)
            {
                if (i <= PlayerData(MyEnum.cowNumber, playerNumber)) 
                {
                    playersCardInfo[playerNumber].PlayerCow.text = i.ToString("D2");
                }
                if (i <= PlayerData(MyEnum.IronNumber, playerNumber))
                {
                    playersCardInfo[playerNumber].PlayerIron.text = i.ToString("D2");
                }
                if (i <= PlayerData(MyEnum.SoilNunber, playerNumber))
                {
                    playersCardInfo[playerNumber].PlayerSoil.text = i.ToString("D2");
                }
                if (i <= PlayerData(MyEnum.WaterNumber, playerNumber))
                {
                    playersCardInfo[playerNumber].PlayerWater.text = i.ToString("D2");
                }
                if (i <= PlayerData(MyEnum.WheatNumber, playerNumber))
                {
                    playersCardInfo[playerNumber].PlayerWheat.text = i.ToString("D2");
                }
                if (i <= PlayerData(MyEnum.WoodNumber, playerNumber))
                {
                    playersCardInfo[playerNumber].PlayerWood.text = i.ToString("D2");
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        IEnumerator CalculateEquipmentScore(int playerNumber)
        {
            for (int i = 0; i <= GlobalVariables.maxEquipmentUpgradeLevel; i++)
            {
                if (i <= PlayerData(MyEnum.WeaponLevel, playerNumber))
                {
                    playersBonusInfos[playerNumber].PlayerWeapon.text = i.ToString("D2");
                }

                if (i <= PlayerData(MyEnum.ShieldLevel, playerNumber))
                {
                    playersBonusInfos[playerNumber].PlayerShield.text = i.ToString("D2");
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        IEnumerator CalculatePropertyScore(int playerNumber)
        {
            for (int i = 0; i <= PlayerData(MyEnum.TileList, playerNumber); i++)
            {
                if (i <= PlayerData(MyEnum.TileList, playerNumber))
                {
                    playersBonusInfos[playerNumber].PlayerTent.text = i.ToString("D2");
                }
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 0; i <= PlayerData(MyEnum.BossKillCount, playerNumber) ; i++)
            {
                if (i <= PlayerData(MyEnum.BossKillCount, playerNumber))
                {
                    playersBonusInfos[playerNumber].PlayerKillMonster.text = i.ToString("D2");
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        IEnumerator CalculateTotalScore(int playerNumber)
        {
            for (int i = 0; i <= playerTotalScore[playerNumber]; i += 10000)
            {
                if (i <= playerTotalScore[playerNumber])
                {
                    playersBonusInfos[playerNumber].PlayerTotalScore.text = i.ToString("D2");
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        private int PlayerData(MyEnum tileType, int playerNumber)
        {
            int data = 0;
            switch (tileType)
            {
                case MyEnum.cowNumber:
                      data = gameData.PlayerData[playerNumber].ItemData.CowNumber;
                    break;
                case MyEnum.IronNumber:
                      data = gameData.PlayerData[playerNumber].ItemData.IronNumber;
                    break;
                case MyEnum.SoilNunber:
                     data = gameData.PlayerData[playerNumber].ItemData.SoilNumber;
                    break;
                case MyEnum.WaterNumber:
                     data = gameData.PlayerData[playerNumber].ItemData.WaterNumber;
                    break;
                case MyEnum.WheatNumber:
                     data = gameData.PlayerData[playerNumber].ItemData.WheatNumber;
                    break;
                case MyEnum.WoodNumber:
                    data = gameData.PlayerData[playerNumber].ItemData.WoodNumber;
                    break;
                case MyEnum.WeaponLevel:
                    data = gameData.PlayerData[playerNumber].StatData.WeaponLevel;
                    break;
                case MyEnum.ShieldLevel:
                    data = gameData.PlayerData[playerNumber].StatData.ShieldLevel;
                    break;
                case MyEnum.TileList:
                    data = gameData.PlayerData[playerNumber].TileList.Count;
                    break;
                case MyEnum.BossKillCount:
                    data = gameData.PlayerData[playerNumber].BossKillCount;
                    break;
            }
            return data;
        }
    }
}
