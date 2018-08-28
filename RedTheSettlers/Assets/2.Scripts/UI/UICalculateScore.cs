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
    public class UICalculateScore : MonoBehaviour
    {
        private GameData gameData;

        public void TestLoadData(GameData data)
        {
            //>>Resource<<
            gameData.PlayerData[0].ItemList[(int)ItemType.Cow].Count = 1;
            gameData.PlayerData[1].ItemList[(int)ItemType.Cow].Count = 2;
            gameData.PlayerData[2].ItemList[(int)ItemType.Cow].Count = 3;
            gameData.PlayerData[3].ItemList[(int)ItemType.Cow].Count = 4;

            gameData.PlayerData[0].ItemList[(int)ItemType.Water].Count = 5;
            gameData.PlayerData[1].ItemList[(int)ItemType.Water].Count = 15;
            gameData.PlayerData[2].ItemList[(int)ItemType.Water].Count = 20;
            gameData.PlayerData[3].ItemList[(int)ItemType.Water].Count = 25;

            gameData.PlayerData[0].ItemList[(int)ItemType.Wheat].Count = 5;
            gameData.PlayerData[1].ItemList[(int)ItemType.Wheat].Count = 6;
            gameData.PlayerData[2].ItemList[(int)ItemType.Wheat].Count = 7;
            gameData.PlayerData[3].ItemList[(int)ItemType.Wheat].Count = 8;

            gameData.PlayerData[0].ItemList[(int)ItemType.Wood].Count = 2;
            gameData.PlayerData[1].ItemList[(int)ItemType.Wood].Count = 4;
            gameData.PlayerData[2].ItemList[(int)ItemType.Wood].Count = 6;
            gameData.PlayerData[3].ItemList[(int)ItemType.Wood].Count = 8;

            gameData.PlayerData[0].ItemList[(int)ItemType.Iron].Count = 4;
            gameData.PlayerData[1].ItemList[(int)ItemType.Iron].Count = 8;
            gameData.PlayerData[2].ItemList[(int)ItemType.Iron].Count = 12;
            gameData.PlayerData[3].ItemList[(int)ItemType.Iron].Count = 16;

            gameData.PlayerData[0].ItemList[(int)ItemType.Soil].Count = 3;
            gameData.PlayerData[1].ItemList[(int)ItemType.Soil].Count = 6;
            gameData.PlayerData[2].ItemList[(int)ItemType.Soil].Count = 9;
            gameData.PlayerData[3].ItemList[(int)ItemType.Soil].Count = 12;
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
        private void Awake()
        {
            gameData = new GameData(4);
            TestLoadData(gameData);
        }

        [SerializeField]
        private int playerIndex;
        private float scoreDelayTime = 0.05f;
        private int totalScore = 0;
        private int riseValue = 10000;

        [System.Serializable]
        struct Texts
        {
            public Text[] CardTexts;
            public Text AttackText;
            public Text ShieldText;
            public Text TentText;
            public Text monsterKillText;
            public Text TotalText;
        }

        [SerializeField]
        private Texts infoTexts;

        [SerializeField]
        private Text cardWeight, equipmentWeight, bonusWeight;

        private void Start()
        {
            TotalScore();
            ShowWeightValue();
            StartCoroutine(ShowCardScore());
        }

        IEnumerator ShowCardScore()
        {
            PlayerData playerData = gameData.PlayerData[playerIndex];

            for (int i = 0; i < infoTexts.CardTexts.Length; i++)
            {
                for (int j = 0; j <= playerData.ItemList[i].Count; j++)
                {
                    infoTexts.CardTexts[i].text = j.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }
            }

            int scoreCount = 0;
            for (int i = 0; i < GlobalVariables.MaxEquipmentUpgradeLevel; i++)
            {
                if (scoreCount <= playerData.StatData.WeaponLevel)
                {
                    scoreCount++;
                    infoTexts.AttackText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }

                if (scoreCount <= playerData.StatData.ShieldLevel)
                {
                    scoreCount++;
                    infoTexts.ShieldText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }
            }

            scoreCount = 0;
            for (int i = 0; i <= GlobalVariables.MaxTileCount; i++)
            {
                if (scoreCount <= playerData.TileList.Count)
                {
                    scoreCount++;
                    infoTexts.TentText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }

                if (scoreCount <= playerData.BossKillCount)
                {
                    scoreCount++;
                    infoTexts.monsterKillText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }
            }

            for (int i = 0; i <= totalScore; i += riseValue)
            {
                infoTexts.TotalText.text = i.ToString();
                yield return new WaitForSeconds(scoreDelayTime);
            }
            yield break;
        }

        public void TotalScore()
        {
            totalScore = 100000;

            //    GameManager.Instance.GetPlayerItemCountAll((UserType)playerIndex)
            //* (GlobalVariables.CardWeightValue + GlobalVariables.EquipmentWeightValue + GlobalVariables.BonusWeightValue);
        }

        private void ShowWeightValue()
        {
            cardWeight.text = "X" + GlobalVariables.CardWeightValue.ToString();
            equipmentWeight.text = "X" + GlobalVariables.EquipmentWeightValue.ToString();
            bonusWeight.text = "X" + GlobalVariables.BonusWeightValue.ToString();
        }
    }
}