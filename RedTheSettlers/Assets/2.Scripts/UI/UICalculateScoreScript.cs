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
                        if (int.Parse(playersCowCardText[i].text) < gameData.PlayerData[i].ResourceData.CowNum)
                        {
                            playersCowCardText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        else if (int.Parse(playersWaterCardText[i].text) < gameData.PlayerData[i].ResourceData.WaterNum)
                        {
                            playersWaterCardText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        else if (int.Parse(playersWheatCardtText[i].text) < gameData.PlayerData[i].ResourceData.WheatNum)
                        {
                            playersWheatCardtText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        else if (int.Parse(playersWoodCardText[i].text) < gameData.PlayerData[i].ResourceData.WoodNum)
                        {
                            playersWoodCardText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        else if (int.Parse(playerIronCardText[i].text) < gameData.PlayerData[i].ResourceData.IronNum)
                        {
                            playerIronCardText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        else if (int.Parse(playerSoilCardText[i].text) < gameData.PlayerData[i].ResourceData.SoilNum)
                        {
                            playerSoilCardText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        tempScore++;
                        yield return new WaitForSeconds(0.05f);
                    }
                }
                for (int i = 0; i < playerWeaponScoreText.Length; i++)
                {
                    tempScore = 1;
                    while (tempScore <= 3)
                    {
                        if (int.Parse(playerWeaponScoreText[i].text) < gameData.PlayerData[i].StatData.WeaponLevel)
                        {
                            playerWeaponScoreText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        if (int.Parse(playerShieldScoreText[i].text) < gameData.PlayerData[i].StatData.ArmorLevel)
                        {
                            playerShieldScoreText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        tempScore++;
                        yield return new WaitForSeconds(0.03f);
                    }
                }
                for (int i = 0; i < playerTentScoreText.Length; i++)
                {
                    tempScore = 0;
                    while (tempScore <= 50)
                    {
                        if (int.Parse(playerTentScoreText[i].text) < gameData.PlayerData[i].TileList.Count)
                        {
                            playerTentScoreText[i].text = string.Format("{0:D2}", tempScore);
                        }

                        if (int.Parse(playerMonsterScoreText[i].text) < gameData.PlayerData[i].InGameData.BossKillCount)
                        {
                            playerMonsterScoreText[i].text = string.Format("{0:D2}", tempScore);
                        }
                        tempScore++;
                        yield return new WaitForSeconds(0.03f);
                    }
                }

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
