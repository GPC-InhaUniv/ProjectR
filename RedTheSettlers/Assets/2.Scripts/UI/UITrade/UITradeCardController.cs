using RedTheSettlers.GameSystem;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace RedTheSettlers.UI
{
    /// <summary>
    /// 작성자 : 김하정
    ///코드가 길때는 스크립트를 나누는게 좋을까? ***************************************
    /// TradeUI에서 Player의 조작에 따른 Value 값의 변화를 처리하는 스크립트
    /// </summary>
    public class UITradeCardController : MonoBehaviour
    {
        [SerializeField]
        private GameObject ItemPopup, overItemPopup;

        [SerializeField]
        private GameObject giveGroup, handGroup, takeGroup;

        [SerializeField]
        private Slider ItemSlider;

        [SerializeField]
        private Text SliderValue;

        [SerializeField]
        private Text GiveDescriptionText, TakeDescriptionText;

        private int TradeCardNumber;
        int giveAndTake = 0;

        const string GIVEPANEL = "GivePanel";
        const string TAKEPANEL = "TakePanel";

        [Serializable]
        struct CardInfo
        {
            public string InspectorName;
            public GameObject ItemsCard;
            public Text TempitemsCount;
        }
        [SerializeField]
        private CardInfo[] cardInfo;

        enum OtherPlayerState
        {
            Trade,
            No,
            Yes,
        }

        private int[] tradeItemValue = new int[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,Soil,Water,Wheat,Wood

        //임시데이터 나중에 삭제할 예정
        GameData gameData;
        public void TestLoadData(GameData data)
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
            TestLoadData(gameData);
        }

        public void CheckCards(int cardNumber)
        {
            PlayerData data = gameData.PlayerData[0];

            if (cardInfo[cardNumber].ItemsCard.transform.parent.name == GIVEPANEL)
            {
                giveAndTake = 1;
            }
            if (cardInfo[cardNumber].ItemsCard.transform.parent.name == TAKEPANEL)
            {
                giveAndTake = -1;
            }

            if(giveAndTake == 1)
            {
                GiveDescriptionText.gameObject.SetActive(true);
                TakeDescriptionText.gameObject.SetActive(false);
            }
            else
            {
                GiveDescriptionText.gameObject.SetActive(false);
                TakeDescriptionText.gameObject.SetActive(true);
            }

            if ((cardInfo[cardNumber].ItemsCard.transform.parent.name == giveGroup.name) || (cardInfo[cardNumber].ItemsCard.transform.parent.name == takeGroup.name))
            {
                ItemPopup.gameObject.SetActive(true);
                ItemSlider.maxValue = data.ItemList[cardNumber].Count;
                ItemSlider.value = 0;
            }

        }

        public void OnClickedPopupButton()
        {
            tradeItemValue[TradeCardNumber] = (int)ItemSlider.value * giveAndTake;
            cardInfo[TradeCardNumber].TempitemsCount.text = tradeItemValue[TradeCardNumber].ToString();
            CheckTakeCardLimit();
        }

        public void CheckTakeCardLimit()
        {
            float tempTotalvalue = 0;

            for (int i = 0; i < cardInfo.Length; i++)
            {
                tempTotalvalue += tradeItemValue[i];
            }

            if (tempTotalvalue > 50)
            {
                overItemPopup.SetActive(true);
                cardInfo[TradeCardNumber].ItemsCard.transform.SetParent(handGroup.transform);
                cardInfo[TradeCardNumber].TempitemsCount.text = "";
                tradeItemValue[TradeCardNumber] = 0;
            }
        }

        public void ChangeSliderValue()
        {
            SliderValue.text = ItemSlider.value.ToString();
        }

        public void ResetCardBoard()
        {
            for (int i = 0; i < cardInfo.Length; i++)
            {
                cardInfo[i].ItemsCard.transform.SetParent(handGroup.transform);
                cardInfo[i].TempitemsCount.text = "";
                tradeItemValue[i] = 0;
            }
            ItemSlider.value = 0;
        }

        public void OnClickedRequestButton()
        {
            
        }

        //트레이드 컨트롤러에 줄 구조체
        public ItemData[] GetTradeData()
        {
            ItemData[] sendData = new ItemData[GlobalVariables.MaxItemNumber];

            for (int i = 0; i < tradeItemValue.Length; i++)
            {
                sendData[i].ItemType = (ItemType)i;
                sendData[i].Count = tradeItemValue[i];
            }
            
            return sendData;
        }

        public void OnClickTest()
        {
            for (int i = 0; i < tradeItemValue.Length; i++)
            {
                Debug.Log(tradeItemValue[i]);
            }
        }
    }
}