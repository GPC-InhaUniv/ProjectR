using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 플레이어의 현재 event를 노출해주는 UI스크립트
///
/// [중요] Turn, move, event를 Script 분리 할 것임
/// [중요] UI Manager 스크립트에서 각 상황에 맞게 처리 할 예정
/// </summary>

namespace RedTheSettlers
{
    namespace UI
    {
        public class UIWeatherEventController : MonoBehaviour
        {
            [Header("Player's Current Situation")]
            [SerializeField]
            private Text currentTurn;

            [SerializeField]
            private Text currentMove;

            [SerializeField]
            private Text currentEventTitle;

            [SerializeField]
            private Text currentEventContent;

            private int currentTurnNum;

            private int whatEvent;

            private void ChangeWeatherEvent()
            {
                whatEvent = 0; //Test
                               //currentTurn.text = gameData.cowcow.ToString();
                               //이런식으로 현재 이벤트 정보, Move 정보를 gameData에서 가져와서 텍스트에 넣어줘야 함.

                switch (whatEvent) //gameData
                {
                    case 0:
                        {
                            currentEventTitle.text = "현재 날씨는 맑습니다";
                            currentEventContent.text = "";
                        }
                        break;

                    case 1:
                        {
                            currentEventTitle.text = "비가 내립니다";
                            currentEventContent.text = "물 자원을 +1개 획득합니다.";
                        }
                        break;

                    case 2:
                        {
                            currentEventTitle.text = "풍년 입니다";
                            currentEventContent.text = "밀 자원을 +1개 획득합니다.";
                        }
                        break;

                    case 3:
                        {
                            currentEventTitle.text = "사랑이 넘쳐납니다";
                            currentEventContent.text = "소 자원을 +1개 획득합니다";
                        }
                        break;

                    case 4:
                        {
                            currentEventTitle.text = "정령의 축제가 열렸습니다";
                            currentEventContent.text = "나무 자원을 +1개 획득합니다.";
                        }
                        break;

                    case 5:
                        {
                            currentEventTitle.text = "광맥을 발견했습니다";
                            currentEventContent.text = "철 자원을 +1 개 획득합니다.";
                        }
                        break;

                    case 6:
                        {
                            currentEventTitle.text = "좋은 토질을 발견했습니다";
                            currentEventContent.text = "흙 자원을 +1 개 획득합니다.";
                        }
                        break;

                    case 7:
                        {
                            currentEventTitle.text = "더위로 물이 말랐습니다";
                            currentEventContent.text = "물 자원을 -1 개 획득합니다.";
                        }
                        break;

                    case 8:
                        {
                            currentEventTitle.text = "배고픈 메뚜기떼가 나타났습니다";
                            currentEventContent.text = "밀 자원을 -1 개 획득합니다.";
                        }
                        break;

                    case 9:
                        {
                            currentEventTitle.text = "소들이 병들었습니다";
                            currentEventContent.text = "물 자원을 -1 개 획득합니다.";
                        }
                        break;

                    case 10:
                        {
                            currentEventTitle.text = "산불이 났습니다";
                            currentEventContent.text = "나무 자원을 -1 개 획득합니다.";
                        }
                        break;

                    case 11:
                        {
                            currentEventTitle.text = "광산이 무너졌습니다";
                            currentEventContent.text = "철 자원을 -1 개 획득합니다.";
                        }
                        break;

                    case 12:
                        {
                            currentEventTitle.text = "폭우가 내립니다";
                            currentEventContent.text = "흙 자원을 -1 개 획득합니다.";
                        }
                        break;
                }
            }

            private void Start()
            {
                ChangeWeatherEvent();
            }

            private void Update()
            {
            }
        }
    }
}