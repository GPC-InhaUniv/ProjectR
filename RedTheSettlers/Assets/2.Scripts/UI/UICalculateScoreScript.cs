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
        int tempscore;
        const int TotalCountNumber = 10000;
        const int WinnerImageSize = 15;

        const int tempCardWeightScore = 3000;
        const int tempEquipmentWeightScore = 5000;
        const int tempTendAndMonsterWeightScore = 7000;

        const float ScoreTimer = 0.03f;
        const float WinnerIconTimer = 1f;

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
            public string InspectorName;
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

        int[] playerTotalScore = new int[GlobalVariables.maxPlayerNumber] { 0, 0, 0, 0 };

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
            tempscore = 0;

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
            StartCoroutine(ChangeScores());


        }

        private void CalculateTotalScore()
        {
            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                playerTotalScore[i] = (gameData.PlayerData[i].ItemData.SumOfItem * tempCardWeightScore)
                + ((gameData.PlayerData[i].StatData.WeaponLevel + gameData.PlayerData[i].StatData.ShieldLevel) * tempEquipmentWeightScore) +
                ((gameData.PlayerData[i].TileList.Count + gameData.PlayerData[i].BossKillCount) * tempTendAndMonsterWeightScore);
                Debug.Log(playerTotalScore[i]);
            }
        }

        private void ShowWinnerIcon()
        {
            int maxValue = playerTotalScore.Max();
            int maxIndex = playerTotalScore.ToList().IndexOf(maxValue);
            playerWinnerImages[maxIndex].WinnerIconImage.gameObject.SetActive(true);
        }

        IEnumerator ChangeScores()
        {
            for (int i = 0; i < GlobalVariables.maxPlayerNumber; i++)
            {
                tempscore = 0;
                for (int j = 0; j <= GetMaxItemNumber(i); j++)
                {
                    ShowCardScore(i);
                    tempscore++;
                    yield return new WaitForSeconds(ScoreTimer);
                }

                tempscore = 0;
                for (int j = 0; j <= GlobalVariables.maxEquipmentUpgradeLevel; j++)
                {
                    ShowEquipmentScore(i);
                    tempscore++;
                    yield return new WaitForSeconds(ScoreTimer);
                }

                tempscore = 0;
                for (int j = 0; j <= PlayerData(MyEnum.TileList, i); j++)
                {
                    ShowTentScore(i);
                    tempscore++;
                    yield return new WaitForSeconds(ScoreTimer);
                }

                tempscore = 0;
                for (int j = 0; j <= PlayerData(MyEnum.BossKillCount, i); j++)
                {
                    ShowMonsterScore(i);
                    tempscore++;
                    yield return new WaitForSeconds(ScoreTimer);
                }

                tempscore = 0;
                for (int j = 0; j <= playerTotalScore[i]; j+= TotalCountNumber)
                {
                    ShowTotalScore(i);
                    tempscore += TotalCountNumber;
                    yield return new WaitForSeconds(ScoreTimer);
                }
            }
            yield return new WaitForSeconds(WinnerIconTimer);
            ShowWinnerIcon();
            yield break;
        }

        private void ShowCardScore(int playerNumber)
        {
            if (tempscore <= PlayerData(MyEnum.cowNumber, playerNumber))
            {
                playersCardInfo[playerNumber].PlayerCow.text = tempscore.ToString("D2");
            }
            if (tempscore <= PlayerData(MyEnum.IronNumber, playerNumber))
            {
                playersCardInfo[playerNumber].PlayerIron.text = tempscore.ToString("D2");
            }
            if (tempscore <= PlayerData(MyEnum.SoilNunber, playerNumber))
            {
                playersCardInfo[playerNumber].PlayerSoil.text = tempscore.ToString("D2");
            }
            if (tempscore <= PlayerData(MyEnum.WaterNumber, playerNumber))
            {
                playersCardInfo[playerNumber].PlayerWater.text = tempscore.ToString("D2");
            }
            if (tempscore <= PlayerData(MyEnum.WheatNumber, playerNumber))
            {
                playersCardInfo[playerNumber].PlayerWheat.text = tempscore.ToString("D2");
            }
            if (tempscore <= PlayerData(MyEnum.WoodNumber, playerNumber))
            {
                playersCardInfo[playerNumber].PlayerWood.text = tempscore.ToString("D2");
            }
        }

        private void ShowEquipmentScore(int playerNumber)
        {
            if (tempscore <= PlayerData(MyEnum.WeaponLevel, playerNumber))
            {
                playersBonusInfos[playerNumber].PlayerWeapon.text = tempscore.ToString("D2");
            }

            if (tempscore <= PlayerData(MyEnum.ShieldLevel, playerNumber))
            {
                playersBonusInfos[playerNumber].PlayerShield.text = tempscore.ToString("D2");
            }
        }

        private void ShowTentScore(int playerNumber)
        {
            if (tempscore <= PlayerData(MyEnum.TileList, playerNumber))
            {
                playersBonusInfos[playerNumber].PlayerTent.text = tempscore.ToString("D2");
            }
        }

        private void ShowMonsterScore(int playerNumber)
        {
            if (tempscore <= PlayerData(MyEnum.BossKillCount, playerNumber))
            {
                playersBonusInfos[playerNumber].PlayerKillMonster.text = tempscore.ToString("D2");
            }
        }

        private void ShowTotalScore(int playerNumber)
        {
            if (tempscore <= playerTotalScore[playerNumber])
            {
                playersBonusInfos[playerNumber].PlayerTotalScore.text = tempscore.ToString("D2");
            }
        }

        private int[] itemList;
        public int GetMaxItemNumber(int playerNumber)
        {
            itemList = new int[6];
            itemList[0] = gameData.PlayerData[playerNumber].ItemData.CowNumber;
            itemList[1] = gameData.PlayerData[playerNumber].ItemData.IronNumber;
            itemList[2] = gameData.PlayerData[playerNumber].ItemData.SoilNumber;
            itemList[3] = gameData.PlayerData[playerNumber].ItemData.WaterNumber;
            itemList[4] = gameData.PlayerData[playerNumber].ItemData.WheatNumber;
            itemList[5] = gameData.PlayerData[playerNumber].ItemData.WoodNumber;
            Array.Sort(itemList);
            return itemList[5];

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
