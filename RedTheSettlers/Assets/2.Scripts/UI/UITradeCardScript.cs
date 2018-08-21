using UnityEngine;
using System.Collections;
using RedTheSettlers.GameSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace RedTheSettlers.UI
{
    public class UITradeCardScript : MonoBehaviour
    {
        public GameData gameData;

        void TESTLoadData(GameData data)
        {
            //>>Resource<<
            data.PlayerData[0].ItemData.CowNumber = 1;
            data.PlayerData[1].ItemData.CowNumber = 2;
            data.PlayerData[2].ItemData.CowNumber = 3;
            data.PlayerData[3].ItemData.CowNumber = 4;

            data.PlayerData[0].ItemData.WaterNumber = 5;
            data.PlayerData[1].ItemData.WaterNumber = 15;
            data.PlayerData[2].ItemData.WaterNumber = 20;
            data.PlayerData[3].ItemData.WaterNumber = 25;

            data.PlayerData[0].ItemData.WheatNumber = 5;
            data.PlayerData[1].ItemData.WheatNumber = 6;
            data.PlayerData[2].ItemData.WheatNumber = 7;
            data.PlayerData[3].ItemData.WheatNumber = 8;

            data.PlayerData[0].ItemData.WoodNumber = 2;
            data.PlayerData[1].ItemData.WoodNumber = 4;
            data.PlayerData[2].ItemData.WoodNumber = 6;
            data.PlayerData[3].ItemData.WoodNumber = 8;

            data.PlayerData[0].ItemData.IronNumber = 4;
            data.PlayerData[1].ItemData.IronNumber = 8;
            data.PlayerData[2].ItemData.IronNumber = 12;
            data.PlayerData[3].ItemData.IronNumber = 16;

            data.PlayerData[0].ItemData.SoilNumber = 3;
            data.PlayerData[1].ItemData.SoilNumber = 6;
            data.PlayerData[2].ItemData.SoilNumber = 9;
            data.PlayerData[3].ItemData.SoilNumber = 12;
            //<<

            //>>Equipement
            gameData.PlayerData[0].StatData.WeaponLevel = 2;
            gameData.PlayerData[1].StatData.WeaponLevel = 1;
            gameData.PlayerData[2].StatData.WeaponLevel = 3;
            gameData.PlayerData[3].StatData.WeaponLevel = 2;

            gameData.PlayerData[0].StatData.ShieldLevel = 1;
            gameData.PlayerData[1].StatData.ShieldLevel = 3;
            gameData.PlayerData[2].StatData.ShieldLevel = 2;
            gameData.PlayerData[3].StatData.ShieldLevel = 3;
            //<<

            // >>Player Tents Count And Kill Monsters Count

            TileData tileData;
            tileData.LocationX = 8;
            tileData.LocationY = 21;
            tileData.TileLevel = 2;
            tileData.TileType = ItemType.Wood;

            TileData tileData2;
            tileData2.LocationX = 8;
            tileData2.LocationY = 21;
            tileData2.TileLevel = 2;
            tileData2.TileType = ItemType.Wood;

            gameData.PlayerData[0].TileList.Add(tileData);
            gameData.PlayerData[0].TileList.Add(tileData2);
            gameData.PlayerData[1].TileList.Add(tileData);
            gameData.PlayerData[2].TileList.Add(tileData);
            gameData.PlayerData[3].TileList.Add(tileData);

            gameData.PlayerData[0].BossKillCount = 3;
            gameData.PlayerData[1].BossKillCount = 5;
            gameData.PlayerData[2].BossKillCount = 7;
            gameData.PlayerData[3].BossKillCount = 9;
            //<<
        }
        private void Awake()
        {
            gameData = new GameData(4);
            TESTLoadData(gameData);
        }

        private int giveCardNumber, takeCardNumber;

        [SerializeField]
        private GameObject takeItemPopup, giveItemPopup, overItemPopup;

        [System.Serializable]
        struct CardInfo
        {
            public string InspectorName;
            public GameObject ItemsCard;
            public Text TempitemsCount;
        }
        [SerializeField]
        private CardInfo[] cardInfo;

        private float[] tempGiveValue = new float[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,Soil,Water,Wheat,Wood

        private float[] tempTakeValue = new float[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,Soil,Water,Wheat,Wood

       

        [SerializeField]
        private Slider takeItemSlider, giveItemSlider;

        [SerializeField]
        private Text takeSliderValue, giveSliderValue;

        [SerializeField]
        private GameObject playerGiveGroup, playerHandGroup, playerTakeGroup;

        public enum AnotherPlayerState
        {
            Trade,
            No,
            Yes,
        }
        [SerializeField]
        AnotherPlayerState anotherPlayerstate;

        private void Start()
        {
            
        }

        struct TradeItemValue//임시 값.
        {
            public int TradeCow;
            public int TradeIron;
            public int TradeSoil;
            public int TradeWater;
            public int TradeWheat;
            public int TradeWood;
        }
        TradeItemValue tradeItemValue;

        [SerializeField]
        private Text secondPlayer, thirdPlayer, fourthPlayer;

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
                case 0:
                    data = gameData.PlayerData[0].ItemData.CowNumber;
                    break;
                case 1:
                    data = gameData.PlayerData[0].ItemData.IronNumber;
                    break;
                case 2:
                    data = gameData.PlayerData[0].ItemData.SoilNumber;
                    break;
                case 3:
                    data = gameData.PlayerData[0].ItemData.WaterNumber;
                    break;
                case 4:
                    data = gameData.PlayerData[0].ItemData.WheatNumber;
                    break;
                case 5:
                    data = gameData.PlayerData[0].ItemData.WoodNumber;
                    break;
            }
            return data;
        }

        public void OnClickedPopupButton()
        {
            if (cardInfo[giveCardNumber].ItemsCard.activeSelf == true &&
                string.Equals(cardInfo[giveCardNumber].ItemsCard.transform.parent.name, playerGiveGroup.name))   //이름 직접비교는 피하자. Equals 사용
            {
                tempGiveValue[giveCardNumber] = giveItemSlider.value;
                cardInfo[giveCardNumber].TempitemsCount.text = tempGiveValue[giveCardNumber].ToString();
            }
            if (cardInfo[takeCardNumber].ItemsCard.activeSelf == true &&
                string.Equals(cardInfo[takeCardNumber].ItemsCard.transform.parent.name, playerTakeGroup.name))
            {
                tempTakeValue[takeCardNumber] = takeItemSlider.value;
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

        public void OnClickedRequestButton(AnotherPlayerState state)
        {
            switch (state)
            {
                case AnotherPlayerState.Yes:

                default:
                    break;
            }
        }

        private void CalculatePlayerItems(GameData data, int ItemNumber)
        {
          
            data.PlayerData[0].ItemData.CowNumber -= (int)tempTakeValue[ItemNumber];
            data.PlayerData[0].ItemData.IronNumber -= (int)tempTakeValue[ItemNumber];
            data.PlayerData[0].ItemData.SoilNumber -= (int)tempTakeValue[ItemNumber];
            data.PlayerData[0].ItemData.WaterNumber -= (int)tempTakeValue[ItemNumber];
            data.PlayerData[0].ItemData.WheatNumber -= (int)tempTakeValue[ItemNumber];
            data.PlayerData[0].ItemData.WoodNumber -= (int)tempTakeValue[ItemNumber];


        }

       
    }
}