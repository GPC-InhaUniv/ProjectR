using UnityEngine;
using System.Collections;
using RedTheSettlers.GameSystem;
using UnityEngine.UI;

namespace RedTheSettlers.UI
{
    public class UITradeCardScript : MonoBehaviour
    {
        GameData gameData;
        private void Awake()
        {
            gameData = new GameData(4);

            //>>Resource<<
            gameData.PlayerData[0].ItemData.CowNumber = 1;
            gameData.PlayerData[1].ItemData.CowNumber = 2;
            gameData.PlayerData[2].ItemData.CowNumber = 3;
            gameData.PlayerData[3].ItemData.CowNumber = 4;

            gameData.PlayerData[0].ItemData.WaterNumber = 5;
            gameData.PlayerData[1].ItemData.WaterNumber = 15;
            gameData.PlayerData[2].ItemData.WaterNumber = 20;
            gameData.PlayerData[3].ItemData.WaterNumber = 25;

            gameData.PlayerData[0].ItemData.WheatNumber = 5;
            gameData.PlayerData[1].ItemData.WheatNumber = 6;
            gameData.PlayerData[2].ItemData.WheatNumber = 7;
            gameData.PlayerData[3].ItemData.WheatNumber = 8;

            gameData.PlayerData[0].ItemData.WoodNumber = 2;
            gameData.PlayerData[1].ItemData.WoodNumber = 4;
            gameData.PlayerData[2].ItemData.WoodNumber = 6;
            gameData.PlayerData[3].ItemData.WoodNumber = 8;

            gameData.PlayerData[0].ItemData.IronNumber = 4;
            gameData.PlayerData[1].ItemData.IronNumber = 8;
            gameData.PlayerData[2].ItemData.IronNumber = 12;
            gameData.PlayerData[3].ItemData.IronNumber = 16;

            gameData.PlayerData[0].ItemData.SoilNumber = 3;
            gameData.PlayerData[1].ItemData.SoilNumber = 6;
            gameData.PlayerData[2].ItemData.SoilNumber = 9;
            gameData.PlayerData[3].ItemData.SoilNumber = 12;
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

        int cowValue, ironValue, soilValue, waterValue, wheatValue, woodValue;

        [SerializeField]
        private GameObject takeItemPopup, giveItemPopup;

        [System.Serializable]
        struct MyStruct
        {
            public string InspectorName;
            public GameObject ItemsCard;
            public Text TempitemsCount;
        }
        [SerializeField]
        private MyStruct[] cardInfo;

        private float[] tempGiveValue = new float[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,SOil,Water,Wheat,Wood

        private float[] tempTakeValue = new float[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,SOil,Water,Wheat,Wood

        [SerializeField]
        private Slider takeItemSlider, giveItemSlider;

        [SerializeField]
        private Text takeSliderValue, giveSliderValue;

        [SerializeField]
        private GameObject playerHandGroup;

        enum AnotherPlayerState
        {
            Trade,
            Yes,
            No
        }

        [SerializeField]
        private Text secondPlayer, thirdPlayer, fourthPlayer;

        private void Start()
        {
            cowValue = gameData.PlayerData[0].ItemData.CowNumber;
            ironValue = gameData.PlayerData[0].ItemData.IronNumber;
            soilValue = gameData.PlayerData[0].ItemData.SoilNumber;
            waterValue = gameData.PlayerData[0].ItemData.WaterNumber;
            wheatValue = gameData.PlayerData[0].ItemData.WheatNumber;
            woodValue = gameData.PlayerData[0].ItemData.WoodNumber;
        }
        private int cardNumber;

        public void CheckCards(string cardName)
        {
            for (int i = 0; i < cardInfo.Length; i++)
            {
                if (cardName == ((ItemType)i).ToString())
                {
                    if (cardInfo[i].ItemsCard.gameObject.transform.parent.name == "TradeCardGiveGroup")
                    {
                        giveItemPopup.gameObject.SetActive(true);
                        cardNumber = i;
                    }
                    else if (cardInfo[i].ItemsCard.gameObject.transform.parent.name == "TradeCardTakeGroup")//구조체는 직접적으로 접근을해야하기떄문에, 즉 i를 사용할 수 없으므로 사용하지 않음
                    {
                        takeItemPopup.gameObject.SetActive(true);
                        cardNumber = i;
                    }
                }
            }
        }

        public void OnClickedPopupButton()
        {
            tempGiveValue[cardNumber] = giveItemSlider.value;
            tempTakeValue[cardNumber] = takeItemSlider.value;

            Debug.Log("-----------------기브");
            for (int i = 0; i < 6; i++)
            {
                Debug.Log(tempGiveValue[i]);
            }

            Debug.Log("-----------------테이크");
            for (int i = 0; i < 6; i++)
            {
                Debug.Log(tempTakeValue[i]);
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
                cardInfo[i].ItemsCard.gameObject.transform.SetParent(playerHandGroup.transform);
            }
            takeItemSlider.value = 0;
            giveItemSlider.value = 0;

        }

        public void OnClickedRequestButton()
        {
            secondPlayer.text = AnotherPlayerState.Trade.ToString();
            thirdPlayer.text = AnotherPlayerState.No.ToString();
            fourthPlayer.text = AnotherPlayerState.Yes.ToString();
        }
    }
}