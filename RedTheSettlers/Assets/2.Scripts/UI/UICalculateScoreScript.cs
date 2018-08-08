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

            private int tempScore;
            private int calculateTotalScore;

            [SerializeField, Space(20)]
            private Text[] playersCowCardText, playersWaterCardText, 
            playersWheatCardtText, playersWoodCardText,
            playerIronCardText, playerSoilCardText = new Text[4];

   
            [SerializeField, Space(20)]
            private Text[] cardsWeighttScoreText, playerWeaponScoreText, playerShieldScoreText,
            playerTentScoreText, playerMonsterScoreText, playerTotalScoreText = new Text[4];

             
            //Initial Weight Score Text
            private int tempCardWeightScore = 3000;
            private int tempEquipmentWeightScore = 5000;
            private int tempTendAndMonsterWeightScore = 7000;

        private GameData gameData;

        //임시 데이터임 나중에 삭제될 예정.
        private void Awake()
        {
            gameData = new GameData(4);

            //>>Resource<<
            gameData.PlayerData[0].ResourceData.CowNumber = 1;
            gameData.PlayerData[1].ResourceData.CowNumber = 2;
            gameData.PlayerData[2].ResourceData.CowNumber = 3;
            gameData.PlayerData[3].ResourceData.CowNumber = 4;

            gameData.PlayerData[0].ResourceData.WaterNumber = 5;
            gameData.PlayerData[1].ResourceData.WaterNumber = 15;
            gameData.PlayerData[2].ResourceData.WaterNumber = 20;
            gameData.PlayerData[3].ResourceData.WaterNumber = 25;

            gameData.PlayerData[0].ResourceData.WheatNumber = 5;
            gameData.PlayerData[1].ResourceData.WheatNumber = 6;
            gameData.PlayerData[2].ResourceData.WheatNumber = 7;
            gameData.PlayerData[3].ResourceData.WheatNumber = 8;

            gameData.PlayerData[0].ResourceData.WoodNumber = 2;
            gameData.PlayerData[1].ResourceData.WoodNumber = 4;
            gameData.PlayerData[2].ResourceData.WoodNumber = 6;
            gameData.PlayerData[3].ResourceData.WoodNumber = 8;

            gameData.PlayerData[0].ResourceData.IronNumber = 4;
            gameData.PlayerData[1].ResourceData.IronNumber = 8;
            gameData.PlayerData[2].ResourceData.IronNumber = 12;
            gameData.PlayerData[3].ResourceData.IronNumber = 16;

            gameData.PlayerData[0].ResourceData.SoilNumber = 3;
            gameData.PlayerData[1].ResourceData.SoilNumber = 6;
            gameData.PlayerData[2].ResourceData.SoilNumber = 9;
            gameData.PlayerData[3].ResourceData.SoilNumber = 12;
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

            gameData.PlayerData[0].InGameData.BossKillCount = 3;
            gameData.PlayerData[1].InGameData.BossKillCount = 5;
            gameData.PlayerData[2].InGameData.BossKillCount = 7;
            gameData.PlayerData[3].InGameData.BossKillCount = 9;
            //<<


        }

        void Start()
            {
                tempScore = 0;
                calculateTotalScore = 0;

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

            StartCoroutine(ChangePlayerScore());

        }


       IEnumerator ChangePlayerScore()
        {

          
            for (int i = 0; i < playersCowCardText.Length; i++)
            {
                tempScore = 0;
                while (tempScore <= 50)
                {

                    if (int.Parse(playersCowCardText[i].text) < gameData.PlayerData[i].ResourceData.CowNumber)
                    {
                        playersCowCardText[i].text = string.Format("{0:D2}", tempScore);
                    }
                    else if (int.Parse(playersCowCardText[i].text) == gameData.PlayerData[i].ResourceData.CowNumber)
                    {
                          

                    }

                    if (int.Parse(playersWaterCardText[i].text) < gameData.PlayerData[i].ResourceData.WaterNumber)
                    {
                        playersWaterCardText[i].text = string.Format("{0:D2}", tempScore);
                    }
                    else if (int.Parse(playersWaterCardText[i].text) == gameData.PlayerData[i].ResourceData.WaterNumber)
                    {
                        

                    }

                    if (int.Parse(playersWheatCardtText[i].text) < gameData.PlayerData[i].ResourceData.WheatNumber)
                    {
                        playersWheatCardtText[i].text = string.Format("{0:D2}", tempScore);
                    }
                    else if (int.Parse(playersWheatCardtText[i].text) == gameData.PlayerData[i].ResourceData.WheatNumber)
                    {
                         

                    }

                    if (int.Parse(playersWoodCardText[i].text) < gameData.PlayerData[i].ResourceData.WoodNumber)
                    {
                        playersWoodCardText[i].text = string.Format("{0:D2}", tempScore);
                    }
                    else if (int.Parse(playersWoodCardText[i].text) == gameData.PlayerData[i].ResourceData.WoodNumber)
                    {

                       
                    }

                    if (int.Parse(playerIronCardText[i].text) < gameData.PlayerData[i].ResourceData.IronNumber)
                    {
                        playerIronCardText[i].text = string.Format("{0:D2}", tempScore);
                    }
                    else if (int.Parse(playerIronCardText[i].text) == gameData.PlayerData[i].ResourceData.IronNumber)
                    {
                      

                    }

                    if (int.Parse(playerSoilCardText[i].text) < gameData.PlayerData[i].ResourceData.SoilNumber)
                    {
                        playerSoilCardText[i].text = string.Format("{0:D2}", tempScore);
                    }
                    else if (int.Parse(playerSoilCardText[i].text) == gameData.PlayerData[i].ResourceData.SoilNumber)
                    {

                         
                    }
                    tempScore++;
                    yield return new WaitForSeconds(0.03f);
                }
            }
            //for (int i = 0; i < playerWeaponScoreText.Length; i++)
            //{
            //    tempScore = 1;
            //    while (tempScore <= 3)
            //    {
            //        if (int.Parse(playerWeaponScoreText[i].text) < gameData.PlayerData[i].StatData.WeaponLevel)
            //        {
            //            playerWeaponScoreText[i].text = string.Format("{0:D2}", tempScore);
            //        }

            //        if (int.Parse(playerShieldScoreText[i].text) < gameData.PlayerData[i].StatData.ArmorLevel)
            //        {
            //            playerShieldScoreText[i].text = string.Format("{0:D2}", tempScore);
            //        }
            //        tempScore++;
            //        yield return new WaitForSeconds(0.03f);
            //    }
            //}
            //for (int i = 0; i < playerTentScoreText.Length; i++)
            //{
            //    tempScore = 0;
            //    while (tempScore <= 50)
            //    {
            //        if (int.Parse(playerTentScoreText[i].text) < gameData.PlayerData[i].TileList.Count)
            //        {
            //            playerTentScoreText[i].text = string.Format("{0:D2}", tempScore);
            //        }

            //        if (int.Parse(playerMonsterScoreText[i].text) < gameData.PlayerData[i].InGameData.BossKillCount)
            //        {
            //            playerMonsterScoreText[i].text = string.Format("{0:D2}", tempScore);
            //        }
            //        tempScore++;
            //        yield return new WaitForSeconds(0.03f);
            //    }
            //}

            //for (int i = 0; i < playerTotalScoreText.Length; i++)
            //{
            //    tempScore = 0;
            //    //calculateTotalScore =
            //    while (tempScore <= 50)
            //    {
            //        if (int.Parse(playerTotalScoreText[i].text) < gameData.PlayerData[i].TileList.Count)
            //        {
            //            playerTotalScoreText[i].text = string.Format("{0:D2}", tempScore);
            //        }

            //        tempScore++;
            //        yield return new WaitForSeconds(0.03f);
            //    }
            //}
        }
    }

}
