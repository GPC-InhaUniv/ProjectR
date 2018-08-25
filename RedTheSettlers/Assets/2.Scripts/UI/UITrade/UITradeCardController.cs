using UnityEngine;
using System.Collections;
using RedTheSettlers.GameSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace RedTheSettlers.UI
{
    public enum OtherPlayerState
    {
        Trade,
        No,
        Yes,
    }

    /// <summary>
    /// 작성자 : 김하정
    /// 수정자 : 박지용
    /// TradeUI에서 Player의 조작에 따른 Value 값의 변화를 처리하는 스크립트
    /// </summary>
    public class UITradeCardController : MonoBehaviour
    {
        [SerializeField]
        private GameObject takeItemPopup, giveItemPopup, overItemPopup;

        [SerializeField]
        private GameObject playerGiveGroup, playerHandGroup, playerTakeGroup;

        [SerializeField]
        private Slider takeItemSlider, giveItemSlider;

        [SerializeField]
        private Text takeSliderValue, giveSliderValue, secondPlayer, thirdPlayer, fourthPlayer;

        private int giveCardNumber, takeCardNumber;
        
        [System.Serializable]
        struct CardInfo
        {
            public string InspectorName;
            public GameObject ItemsCard;
            public Text TempitemsCount;
        }
        [SerializeField]
        private CardInfo[] cardInfo;

        [SerializeField]
        OtherPlayerState otherPlayerstate;

        private int[] tempGiveValue = new int[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,Soil,Water,Wheat,Wood

        private int[] tempTakeValue = new int[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,Soil,Water,Wheat,Wood
        
        GameData gameData;

        private void Start()
        {
            UITradeTEMPDATA tempData = new UITradeTEMPDATA();
            gameData = tempData.gameData;
        }

        public void CheckCards(int cardNumber) //int로 들어오게하기
        {
            for (int i = 0; i < cardInfo.Length; i++)
            {
                if (cardNumber == i)  //0=소/ 1=철/ 2=흙/ 3=물/ 4=밀/ 5=나무
                {

                    if (cardInfo[i].ItemsCard.activeSelf == true &&
                        string.Equals(cardInfo[i].ItemsCard.transform.parent.name, playerGiveGroup.name))
                    {
                        giveCardNumber = i;
                        giveItemPopup.gameObject.SetActive(true);
                        giveItemSlider.maxValue = SetItemsNumber(i);
                        giveItemSlider.value = 0;
                    }
                    if (cardInfo[i].ItemsCard.activeSelf == true &&
                        string.Equals(cardInfo[i].ItemsCard.transform.parent.name, playerTakeGroup.name))
                    {
                        takeCardNumber = i;
                        takeItemPopup.gameObject.SetActive(true);
                        takeItemSlider.value = 0;
                    }
                }
            }
            //Debug.Log("기브카드넘버" + giveCardNumber);
            //Debug.Log("테이크카드넘버" + takeCardNumber);
        }

        private float SetItemsNumber(int Number)
        {
            float data = 0;
            switch (Number)
            {
                //case 0:
                //    data = gameData.PlayerData[0].ItemData.CowNumber;
                //    break;
                //case 1:
                //    data = gameData.PlayerData[0].ItemData.IronNumber;
                //    break;
                //case 2:
                //    data = gameData.PlayerData[0].ItemData.SoilNumber;
                //    break;
                //case 3:
                //    data = gameData.PlayerData[0].ItemData.WaterNumber;
                //    break;
                //case 4:
                //    data = gameData.PlayerData[0].ItemData.WheatNumber;
                //    break;
                //case 5:
                //    data = gameData.PlayerData[0].ItemData.WoodNumber;
                //    break;
            }
            return data;
        }

        public void CheckTakeCardLimit()
        {
            float tempTotalvalue = 0;
            for (int i = 0; i < cardInfo.Length; i++)
            {
                tempTotalvalue += tempTakeValue[i];
            }
            Debug.Log("tempTotalvalue" + tempTotalvalue);
            if (tempTotalvalue > 50)
            {
                overItemPopup.SetActive(true);
                cardInfo[takeCardNumber].ItemsCard.transform.SetParent(playerHandGroup.transform);
                cardInfo[takeCardNumber].TempitemsCount.text = "";
                tempTakeValue[takeCardNumber] = 0;
            }
        }

        public void ChangeSliderValue()
        {
            takeSliderValue.text = takeItemSlider.value.ToString();
            giveSliderValue.text = giveItemSlider.value.ToString();
        }

        public void ResetCardBoard()
        {
            for (int i = 0; i < cardInfo.Length; i++)
            {
                cardInfo[i].ItemsCard.transform.SetParent(playerHandGroup.transform);
                cardInfo[i].TempitemsCount.text = "";
                tempGiveValue[i] = 0;
                tempTakeValue[i] = 0;
            }
            takeItemSlider.value = 0;
            giveItemSlider.value = 0;
        }

        public void OnClickedPopupButton()
        {
            if (cardInfo[giveCardNumber].ItemsCard.activeSelf == true &&
                string.Equals(cardInfo[giveCardNumber].ItemsCard.transform.parent.name, playerGiveGroup.name))   //이름 직접비교는 피하자. Equals 사용
            {
                tempGiveValue[giveCardNumber] = (int)giveItemSlider.value;
                cardInfo[giveCardNumber].TempitemsCount.text = tempGiveValue[giveCardNumber].ToString();
            }

            if (cardInfo[takeCardNumber].ItemsCard.activeSelf == true &&
                string.Equals(cardInfo[takeCardNumber].ItemsCard.transform.parent.name, playerTakeGroup.name))
            {
                tempTakeValue[takeCardNumber] = (int)takeItemSlider.value;
                cardInfo[takeCardNumber].TempitemsCount.text = tempTakeValue[takeCardNumber].ToString();
                CheckTakeCardLimit();
            }

            //Debug.Log("-----------------기브");
            //for (int i = 0; i < 6; i++)
            //{
            //    Debug.Log(tempGiveValue[i]);
            //}

            //Debug.Log("-----------------테이크");
            //for (int i = 0; i < 6; i++)
            //{
            //    Debug.Log(tempTakeValue[i]);
            //}
        }

        public void OnClickedRequestButton()
        {
            ActState(OtherPlayerState.Yes);
        }

        private void ActState(OtherPlayerState state)
        {
            switch (state)
            {
                case OtherPlayerState.Yes:
                    // 
                    CalculatePlayerItems(gameData);
                    Debug.Log("Yes케이스 실행됐음");
                    break;
                case OtherPlayerState.No:
                    Debug.Log("No케이스 실행됐음");
                    break;
                case OtherPlayerState.Trade:
                    Debug.Log("Trade케이스 실행됐음");
                    break;
            }
        }

        private void CalculatePlayerItems(GameData data)
        {
            data.PlayerData[0].ItemList[(int)ItemType.Cow].Count -= tempGiveValue[(int)ItemType.Cow];
            data.PlayerData[0].ItemList[(int)ItemType.Iron].Count -= tempGiveValue[(int)ItemType.Iron];
            data.PlayerData[0].ItemList[(int)ItemType.Soil].Count -= tempGiveValue[(int)ItemType.Soil];
            data.PlayerData[0].ItemList[(int)ItemType.Water].Count -= tempGiveValue[(int)ItemType.Water];
            data.PlayerData[0].ItemList[(int)ItemType.Wheat].Count -= tempGiveValue[(int)ItemType.Wheat];
            data.PlayerData[0].ItemList[(int)ItemType.Wood].Count -= tempGiveValue[(int)ItemType.Wood];
        }
    }
}