using UnityEngine;
using System.Collections;
using RedTheSettlers.GameSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace RedTheSettlers.UI
{
    public class UITradeCardController : MonoBehaviour
    {
        private GameData gameData;

        void TESTLoadData(GameData data)
        {
            //>>Resource<<
            gameData.PlayerData[0].ItemList[(int)ItemType.Cow].Count = 1;
            gameData.PlayerData[1].ItemList[(int)ItemType.Cow].Count = 2;
            gameData.PlayerData[2].ItemList[(int)ItemType.Cow].Count = 3;
            gameData.PlayerData[3].ItemList[(int)ItemType.Cow].Count = 4;

            gameData.PlayerData[0].ItemList[(int)ItemType.Water].Count = 5;
            gameData.PlayerData[1].ItemList[(int)ItemType.Water].Count = 15;
            gameData.PlayerData[2].ItemList[(int)ItemType.Water].Count = 20;
            gameData.PlayerData[3].ItemList[(int)ItemType.Water].Count = 25;

            gameData.PlayerData[0].ItemList[(int)ItemType.Wheat].Count = 5;
            gameData.PlayerData[1].ItemList[(int)ItemType.Wheat].Count = 6;
            gameData.PlayerData[2].ItemList[(int)ItemType.Wheat].Count = 7;
            gameData.PlayerData[3].ItemList[(int)ItemType.Wheat].Count = 8;

            gameData.PlayerData[0].ItemList[(int)ItemType.Wood].Count = 2;
            gameData.PlayerData[1].ItemList[(int)ItemType.Wood].Count = 4;
            gameData.PlayerData[2].ItemList[(int)ItemType.Wood].Count = 6;
            gameData.PlayerData[3].ItemList[(int)ItemType.Wood].Count = 8;

            gameData.PlayerData[0].ItemList[(int)ItemType.Iron].Count = 4;
            gameData.PlayerData[1].ItemList[(int)ItemType.Iron].Count = 8;
            gameData.PlayerData[2].ItemList[(int)ItemType.Iron].Count = 12;
            gameData.PlayerData[3].ItemList[(int)ItemType.Iron].Count = 16;

            gameData.PlayerData[0].ItemList[(int)ItemType.Soil].Count = 3;
            gameData.PlayerData[1].ItemList[(int)ItemType.Soil].Count = 6;
            gameData.PlayerData[2].ItemList[(int)ItemType.Soil].Count = 9;
            gameData.PlayerData[3].ItemList[(int)ItemType.Soil].Count = 12;
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

        private int[] tempGiveValue = new int[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,Soil,Water,Wheat,Wood

        private int[] tempTakeValue = new int[6]
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


        public void OnClickedRequestButton()
        {
            ActState(AnotherPlayerState.Yes);
        }


        private void ActState(AnotherPlayerState state)
        {
            switch (state)
            {
                case AnotherPlayerState.Yes:
                    CalculatePlayerItems(gameData);
                    Debug.Log("Yes케이스 실행됐음");
                    break;
                case AnotherPlayerState.No:
                    Debug.Log("No케이스 실행됐음");
                    break;
                case AnotherPlayerState.Trade:
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

            //data.PlayerData[0].ItemData.CowNumber += tempTakeValue[(int)ItemType.Cow];
            //data.PlayerData[0].ItemData.IronNumber += tempTakeValue[(int)ItemType.Iron];
            //data.PlayerData[0].ItemData.SoilNumber += tempTakeValue[(int)ItemType.Soil];
            //data.PlayerData[0].ItemData.WaterNumber += tempTakeValue[(int)ItemType.Water];
            //data.PlayerData[0].ItemData.WheatNumber += tempTakeValue[(int)ItemType.Wheat];
            //data.PlayerData[0].ItemData.WoodNumber += tempTakeValue[(int)ItemType.Wood];

            //Debug.Log(data.PlayerData[0].ItemData.CowNumber +
            //data.PlayerData[0].ItemData.IronNumber +
            //data.PlayerData[0].ItemData.SoilNumber +
            //data.PlayerData[0].ItemData.WaterNumber +
            //data.PlayerData[0].ItemData.WheatNumber +
            //data.PlayerData[0].ItemData.WoodNumber);
        }

    }
}