using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

/*
RegisterPlayer() // 처음 start할 때 호출
RequestTrade() -> ShowTradePanel() -> GetTradeData() -> ReceiveTrade()_Controller -> ReceiveTrade() -> RequestAgain()
*/

namespace RedTheSettlers.UnitTest
{
    public interface IMediatable
    {
        void RegisterPlayer(Player player);
        void ReceiveTrade(Player requestPlayer, ItemData tradeData);
        void RequestAgain(Player respondPlayer, ItemData tradeData);
    }

    /// <summary>
    /// 작성자 : 박지용
    /// Constructor Mediator
    /// 플레이어 사이의 거래를 제어한다.
    /// </summary>
    public class TradeControllerTest : MonoBehaviour, IMediatable
    {
        List<Player> playerList = new List<Player>();

        void Start()
        {
            Player user = new User(this);
            Player ai1 = new AI(this);
            Player ai2 = new AI(this);
            Player ai3 = new AI(this);

            RegisterPlayer(user);
            RegisterPlayer(ai1);
            RegisterPlayer(ai2);
            RegisterPlayer(ai3);
        }

        public void RegisterPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void ReceiveTrade(Player requestPlayer, ItemData tradeData)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i] == requestPlayer) continue;
                playerList[i].ReceiveTrade(requestPlayer, tradeData);
            }
        }

        public void RequestAgain(Player requestPlayer, ItemData tradeData)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i] == requestPlayer) playerList[i].ReceiveTrade(requestPlayer, tradeData);
            }
        }
    }

    abstract public class Player
    {
        protected IMediatable mediator;
        public ItemData tradeData;
        public GameObject tradePanel;

        /// <summary>
        /// 다른 플레이어들에게 자원 거래를 요청한다.
        /// </summary>
        /// <param name="requestPlayer">거래를 요청한 플레이어</param>
        /// <param name="tradeData">요구하는 자원 거래 정보</param>
        abstract public void RequestTrade(Player requestPlayer, ItemData tradeData);
        abstract public void ReceiveTrade(Player requestPlayer, ItemData tradeData);
        abstract public void RequestAgain(Player requestPlayer, ItemData tradeData);
    }

    public class User : Player
    {
        public User(IMediatable mediator)
        {
            this.mediator = mediator;
        }

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

        override public void RequestTrade(Player requestPlayer, ItemData tradeData)
        {
            ItemData sendData = ShowTradePanel();
            mediator.ReceiveTrade(requestPlayer, tradeData);
        }

        override public void ReceiveTrade(Player requestPlayer, ItemData tradeData)
        {
            tradePanel.SetActive(true);
            // tradeData를 풀어 UI에서 정보 보여주기
            // GetTradeData() -> RequestAgain(requestPlayer, this.Player);
            // 또는 수락 / 거절
            RequestAgain(requestPlayer, tradeData);
        }

        override public void RequestAgain(Player requestPlayer, ItemData tradeData)
        {
            mediator.RequestAgain(requestPlayer, tradeData);
        }
    }

    public class AI : Player
    {
        public AI(IMediatable mediator)
        {
            this.mediator = mediator;
        }

        override public void RequestTrade(Player requestPlayer, ItemData tradeData)
        {
            // 랜덤으로 데이터 받아오기
            ItemData sendData; // =
            mediator.ReceiveTrade(requestPlayer, tradeData);
        }

        override public void ReceiveTrade(Player requestPlayer, ItemData tradeData)
        {
            // GetTradeData() -> RequestAgain(requestPlayer, this.Player);
            // AI를 통해 재협상 / 수락/ 거절 선택
            RequestAgain(requestPlayer, tradeData);
        }

        override public void RequestAgain(Player requestPlayer, ItemData tradeData)
        {
            mediator.RequestAgain(requestPlayer, tradeData);
        }
    }
}