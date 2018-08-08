using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    abstract public class Player
    {
        private IMediatable mediator;
        public ItemData tradeData;
        public GameObject tradePanel;

        public Player(IMediatable mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// 거래 패널을 보여준다. 사용자가 거래 조건을 설정하면 패널을 종료하고 해당 자원 정보를 구조체로 만들어서 전달한다.
        /// </summary>
        public ItemData ShowTradePanel()
        {
            tradePanel.SetActive(true);
            // TradePanel에서 거래 내용 조작
            // 조작이 끝나고 거래를 요청하면 

            // 아래 코드는 정상적으로 동작하지 않을것으로 예상됨. 나중에 다른 메소드로 분리할것
            ItemData sendData = GetTradeData();
            tradePanel.SetActive(false);
            return sendData;
        }

        /// <summary>
        /// UI에서 해줘야하는 작업. 임시로 만듬
        /// 교환할 자원 정보를 구조체로 만들어서 전달
        /// </summary>
        public ItemData GetTradeData()
        {
            ItemData sendData = new ItemData
            {
                CowNumber = 1,
                WaterNumber = -2
            };
            return sendData;
        }

        /// <summary>
        /// 다른 플레이어들에게 자원 거래를 요청한다.
        /// </summary>
        /// <param name="requestPlayer">거래를 요청한 플레이어</param>
        /// <param name="tradeData">요구하는 자원 거래 정보</param>
        public void RequestTrade(Player requestPlayer, ItemData tradeData)
        {
            ItemData sendData = ShowTradePanel();
            mediator.RequestTrade(requestPlayer, tradeData);
        }


        public void SendTrade(Player requestPlayer, ItemData tradeData)
        {
            tradePanel.SetActive(true);
            // tradeData를 풀어 UI에서 정보 보여주기
            // GetTradeData() -> RequestAgain(requestPlayer, this.Player);
            // 또는 수락 / 거절
            mediator.RequestAgain(requestPlayer, tradeData);
        }

        public void RequestAgain(Player requestPlayer, ItemData tradeData)
        {
            mediator.RequestAgain(requestPlayer, tradeData);
        }

        //public class User : Player
        //{

        //}

        //public class AI : Player
        //{

        //}

        public interface IMediatable
        {
            void RegisterPlayer(Player player);
            void RequestTrade(Player requestPlayer, ItemData tradeData);
            void RequestAgain(Player respondPlayer, ItemData tradeData);
            //void ShowTradePanel(Player requestPlayer);
        }

        // Constructor Mediator
        public class TradeControllerTest : MonoBehaviour, IMediatable
        {
            List<Player> playerList = new List<Player>();

            void Start()
            {

                //Player user = new User();
                //Player ai1 = new AI();
                //Player ai2 = new AI();
                //Player ai3 = new AI();

                //RegisterPlayer(user);
                //RegisterPlayer(ai1);
                //RegisterPlayer(ai2);
                //RegisterPlayer(ai3);
            }

            public void RegisterPlayer(Player player)
            {
                playerList.Add(player);
            }

            public void RequestTrade(Player requestPlayer, ItemData tradeData)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i] == requestPlayer) continue;
                    playerList[i].SendTrade(requestPlayer, tradeData);
                }
            }

            public void RequestAgain(Player requestPlayer, ItemData tradeData)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i] == requestPlayer) playerList[i].SendTrade(requestPlayer, tradeData);
                }
            }
        }
    }
}
/*
RegisterPlayer() // 처음 start할 때 호출

RequestTrade() -> ShowTradePanel() -> GetTradeData() -> RequestTrade()_Controller -> SendTrade() -> RequestAgain()
*/
