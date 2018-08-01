using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnController : MonoBehaviour
{
    /// <summary>
    /// 작성자 : 강다희
    /// 플레이어의 현재 Turn을 노출해주는 UI스크립트
    /// </summary>

    [Header("Player's Current Turn")]
    [SerializeField]
    private Text currentTurn;

    private int currentTurnNum;

    private void ResourceInfo()
    {
        //PlayerCowResource.text = gameData.cowcow.ToString();
        //이런식으로 6종류 자원을 gameData에서 가져와서 텍스트에 넣어줘야 함.
    }

    private void ChangeCurrentTurn()
    {
        currentTurnNum = Int32.Parse(currentTurn.text);
    }

    private void Start()
    {
        ChangeCurrentTurn();
    }

    private void Update()
    {
    }
}