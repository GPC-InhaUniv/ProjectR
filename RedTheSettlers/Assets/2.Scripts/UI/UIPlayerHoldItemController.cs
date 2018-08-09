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

        private int cowCardNum;
        private int waterCardNum;
        private int wheatCardNum;
        private int woodCardNum;
        private int ironCardNum;
        private int soilCardNum;
        private float cardmaxNum;

        private int computeItemNum;

        private void ChangeItem()
        {
            cowCardNum = 10; //test

            playerCowItem.text = cowCardNum.ToString(); //test

            //PlayerCowItem.text = gameData.cowcow.ToString();
            //이런식으로 6종류 자원을 gameData에서 가져와서 텍스트에 넣어줘야 함.
        }

        private void ComputeTotalItem()
        {
            cowCardNum = Int32.Parse(playerCowItem.text);
            waterCardNum = Int32.Parse(playerWaterItem.text);
            wheatCardNum = Int32.Parse(playerWheatItem.text);
            woodCardNum = Int32.Parse(playerWoodItem.text);
            ironCardNum = Int32.Parse(playerIronItem.text);
            soilCardNum = Int32.Parse(playerSoilItem.text);

            computeItemNum = cowCardNum + waterCardNum + wheatCardNum + woodCardNum + ironCardNum + soilCardNum;
            playerTotalItem.text = computeItemNum.ToString();

            totalItemBar.value = computeItemNum / cardmaxNum;
            LogManager.Instance.UserDebug(LogColor.Olive, GetType().Name, "현재 소지한 자원 합 : " + playerTotalItem.text);
        }

        private void Start()
        {
            cardmaxNum = 50;
            ChangeItem();
            ComputeTotalItem();
        }

        private void Update()
        {
        }
    }
}