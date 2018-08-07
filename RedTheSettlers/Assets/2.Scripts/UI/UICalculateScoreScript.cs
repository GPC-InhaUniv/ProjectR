using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 작성자 : 김하정
/// 마지막에 점수 계산을 해주는 UI
/// 나중에 델리게이트로 받을예정
/// </summary>
namespace RedTheSettlers
{
    namespace UI
    {
        public class UICalculateScoreScript : MonoBehaviour
        {

            private int tempScore;
            private int calculateTotalScore;

            [HideInInspector]
            [Header("Player Cards Text")]
            [SerializeField]
            private Text[] playersCowCardText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playersWaterCardText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playersWheatCardtText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playersWoodCardText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playerIronCardText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playerSoilCardText = new Text[4];

            [HideInInspector]
            [Header("Player Weight Score")]
            [SerializeField]
            private Text[] cardsWeighttScoreText = new Text[12];


            [HideInInspector]
            [Header("Player Equipments Text")]
            [SerializeField]
            private Text[] playerWeaponScoreText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playerShieldScoreText = new Text[4];

            [HideInInspector]
            [Header("Player Tent And Monster Text")]
            [SerializeField]
            private Text[] playerTentScoreText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playerMonsterScoreText = new Text[4];

            [HideInInspector]
            [SerializeField]
            private Text[] playerTotalScoreText = new Text[4];


            //Initial Weight Score Text
            private int tempCardWeightScore = 3000;
            private int tempEquipmentWeightScore = 5000;
            private int tempTendAndMonsterWeightScore = 7000;

            private GameData gameData;

            private void Awake()
            {
                gameData = new GameData(4);

                //>>Resource<<
                gameData.PlayerData[0].ResourceData.CowNum = 1;
                gameData.PlayerData[1].ResourceData.CowNum = 2;
                gameData.PlayerData[2].ResourceData.CowNum = 3;
                gameData.PlayerData[3].ResourceData.CowNum = 4;

                gameData.PlayerData[0].ResourceData.WaterNum = 5;
                gameData.PlayerData[1].ResourceData.WaterNum = 15;
                gameData.PlayerData[2].ResourceData.WaterNum = 20;
                gameData.PlayerData[3].ResourceData.WaterNum = 25;

                gameData.PlayerData[0].ResourceData.WheatNum = 5;
                gameData.PlayerData[1].ResourceData.WheatNum = 6;
                gameData.PlayerData[2].ResourceData.WheatNum = 7;
                gameData.PlayerData[3].ResourceData.WheatNum = 8;

                gameData.PlayerData[0].ResourceData.WoodNum = 2;
                gameData.PlayerData[1].ResourceData.WoodNum = 4;
                gameData.PlayerData[2].ResourceData.WoodNum = 6;
                gameData.PlayerData[3].ResourceData.WoodNum = 8;

                gameData.PlayerData[0].ResourceData.IronNum = 4;
                gameData.PlayerData[1].ResourceData.IronNum = 8;
                gameData.PlayerData[2].ResourceData.IronNum = 12;
                gameData.PlayerData[3].ResourceData.IronNum = 16;

                gameData.PlayerData[0].ResourceData.SoilNum = 3;
                gameData.PlayerData[1].ResourceData.SoilNum = 6;
                gameData.PlayerData[2].ResourceData.SoilNum = 9;
                gameData.PlayerData[3].ResourceData.SoilNum = 12;
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

                //StartCoroutine(ChangePlayerScore());

            }


           private void  ChangePlayerScore()
            {
                int test;
                
                for (int i = 0; i < playersCowCardText.Length; i++)
                {
                   

                    tempScore = 0;
                    while (tempScore <= 50)
                    {
                        
                        if (int.Parse(playersCowCardText[i].text) < gameData.PlayerData[i].ResourceData.CowNum)
                        {
                            playersCowCardText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        else if (int.Parse(playersCowCardText[i].text) == gameData.PlayerData[i].ResourceData.CowNum)
                        {
                            Debug.Log("cow" + i);
                           
                            
                        }

                        if (int.Parse(playersWaterCardText[i].text) < gameData.PlayerData[i].ResourceData.WaterNum)
                        {
                            playersWaterCardText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        else if (int.Parse(playersWaterCardText[i].text) == gameData.PlayerData[i].ResourceData.WaterNum)
                        {
                          
                            
                        }

                        if (int.Parse(playersWheatCardtText[i].text) < gameData.PlayerData[i].ResourceData.WheatNum)
                        {
                            playersWheatCardtText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        else if (int.Parse(playersWheatCardtText[i].text) == gameData.PlayerData[i].ResourceData.WheatNum)
                        {
                           
                           
                        }

                        if (int.Parse(playersWoodCardText[i].text) < gameData.PlayerData[i].ResourceData.WoodNum)
                        {
                            playersWoodCardText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        else if (int.Parse(playersWoodCardText[i].text) == gameData.PlayerData[i].ResourceData.WoodNum)
                        {
                            
                            
                        }

                        if (int.Parse(playerIronCardText[i].text) < gameData.PlayerData[i].ResourceData.IronNum)
                        {
                            playerIronCardText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        else if (int.Parse(playerIronCardText[i].text) == gameData.PlayerData[i].ResourceData.IronNum)
                        {
                            
                            
                        }

                        if (int.Parse(playerSoilCardText[i].text) < gameData.PlayerData[i].ResourceData.SoilNum)
                        {
                            playerSoilCardText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        else if (int.Parse(playerSoilCardText[i].text) == gameData.PlayerData[i].ResourceData.SoilNum)
                        {
                            
                             
                        }
                        tempScore++;
                        
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
}
