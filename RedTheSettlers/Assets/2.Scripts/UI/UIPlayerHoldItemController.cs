using RedTheSettlers.GameSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 플레이어의 자원 정보 노출 및
/// 플레이어 소지 가능 자원 정보 bar 형식으로 노출해주는 UI스크립트.
/// [중요] UI Manager 스크립트에서 각 상황별로 처리할 예정.
/// </summary>

namespace RedTheSettlers.UI
{
    public class UIPlayerHoldItemController : MonoBehaviour
    {
        [Header("Player's Total Item")]
        [SerializeField]
        private Text playerTotalItem;

        [Header("Player's Item")]  //itemtype
        [SerializeField]
        private Text playerCowItem;

        [SerializeField]
        private Text playerWaterItem;

        [SerializeField]
        private Text playerWheatItem;

        [SerializeField]
        private Text playerWoodItem;

        [SerializeField]
        private Text playerIronItem;

        [SerializeField]
        private Text playerSoilItem;

        [Header("Total Bar")]
        [SerializeField]
        private Slider totalItemBar;

        [SerializeField]
        [Header("Test")]
        private int cowCardCount;

        [SerializeField]
        private int waterCardCount;

        [SerializeField]
        private int wheatCardCount;

        [SerializeField]
        private int woodCardCount;

        [SerializeField]
        private int ironCardCount;

        [SerializeField]
        private int soilCardCount;

        [SerializeField]
        private float cardmaxNumber;

        private int computeItemCount;

        private void PutItemCount()

        {
            playerCowItem.text = cowCardCount.ToString();
            playerWaterItem.text = waterCardCount.ToString();
            playerWheatItem.text = wheatCardCount.ToString();
            playerWoodItem.text = woodCardCount.ToString();
            playerIronItem.text = ironCardCount.ToString();
            playerSoilItem.text = soilCardCount.ToString();

            //PlayerCowItem.text = gameData.cowcow.ToString();
            //이런식으로 6종류 자원을 gameData에서 가져와서 텍스트에 넣어줘야 함.
        }

        private void ComputeTotalItem()
        {
            computeItemCount = cowCardCount + waterCardCount + wheatCardCount + woodCardCount + ironCardCount + soilCardCount;
            playerTotalItem.text = computeItemCount.ToString(); //datamanager에서 가져와야 함.

            totalItemBar.value = computeItemCount / cardmaxNumber;
            LogManager.Instance.UserDebug(LogColor.Olive, GetType().Name, "현재 소지한 자원 합 : " + playerTotalItem.text);
        }

        private void Start()
        {
            cardmaxNumber = 50;
            PutItemCount();
            ComputeTotalItem();
        }

        private void Update()
        {
        }
    }
}