using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 플레이어의 현재 Turn, move, event를 노출해주는 UI스크립트
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

    private void ChangePlayerState()
    {
        //currentTurn.text = gameData.cowcow.ToString();
        //이런식으로 6종류 자원을 gameData에서 가져와서 텍스트에 넣어줘야 함.
    }

    private void Start()
    {
        ChangePlayerState();
    }

    private void Update()
    {
    }
}