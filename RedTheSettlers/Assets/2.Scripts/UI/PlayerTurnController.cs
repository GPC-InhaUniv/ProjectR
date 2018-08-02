using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 플레이어의 현재 Turn, move, event를 노출해주는 UI스크립트
///
/// [중요] Turn, move, event를 Script 분리 할 것임
/// [중요] UI Controller 스크립트에서 각 상황에 맞게 처리 할 예정
/// [중요] 하단 if문을 switch로 변경 예정
/// </summary>

public class PlayerTurnController : MonoBehaviour
{
    [Header("Player's Current Situation")]
    [SerializeField]
    private Text currentTurn;

    [SerializeField]
    private Text currentMove;

    [SerializeField]
    private Text currentEventName;

    [SerializeField]
    private Text currentEventExplain;

    private int currentTurnNum;

    private int whatEvent;

    private void ChangeWheatherEvent()
    {
        whatEvent = 0; //Test
                       //currentTurn.text = gameData.cowcow.ToString();
                       //이런식으로 현재 이벤트 정보, Move 정보를 가져옴.

        switch (whatEvent) //gameData
        {
            case 0:
                {
                    currentEventName.text = "현재 날씨는 맑습니다";
                    currentEventExplain.text = "";
                }
                break;

            case 1:
                {
                    currentEventName.text = "비가 내립니다";
                    currentEventExplain.text = "물 자원을 +1개 획득합니다.";
                }
                break;

            case 2:
                {
                    currentEventName.text = "풍년 입니다";
                    currentEventExplain.text = "밀 자원을 +1개 획득합니다.";
                }
                break;

            case 3:
                {
                    currentEventName.text = "사랑이 넘쳐납니다";
                    currentEventExplain.text = "소 자원을 +1개 획득합니다";
                }
                break;

            case 4:
                {
                    currentEventName.text = "정령의 축제가 열렸습니다";
                    currentEventExplain.text = "나무 자원을 +1개 획득합니다.";
                }
                break;

            case 5:
                {
                    currentEventName.text = "광맥을 발견했습니다";
                    currentEventExplain.text = "철 자원을 +1 개 획득합니다.";
                }
                break;

            case 6:
                {
                    currentEventName.text = "좋은 토질을 발견했습니다";
                    currentEventExplain.text = "흙 자원을 +1 개 획득합니다.";
                }
                break;

            case 7:
                {
                    currentEventName.text = "더위로 물이 말랐습니다";
                    currentEventExplain.text = "물 자원을 -1 개 획득합니다.";
                }
                break;

            case 8:
                {
                    currentEventName.text = "배고픈 메뚜기떼가 나타났습니다";
                    currentEventExplain.text = "밀 자원을 -1 개 획득합니다.";
                }
                break;

            case 9:
                {
                    currentEventName.text = "소들이 병들었습니다";
                    currentEventExplain.text = "물 자원을 -1 개 획득합니다.";
                }
                break;

            case 10:
                {
                    currentEventName.text = "산불이 났습니다";
                    currentEventExplain.text = "나무 자원을 -1 개 획득합니다.";
                }
                break;

            case 11:
                {
                    currentEventName.text = "광산이 무너졌습니다";
                    currentEventExplain.text = "철 자원을 -1 개 획득합니다.";
                }
                break;

            case 12:
                {
                    currentEventName.text = "폭우가 내립니다";
                    currentEventExplain.text = "흙 자원을 -1 개 획득합니다.";
                }
                break;
        }
    }

    private void Start()
    {
        ChangeWheatherEvent();
    }

    private void Update()
    {
    }
}