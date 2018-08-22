using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;

/*
RegisterPlayer() // 처음 start할 때 호출
RequestTrade() -> ShowTradePanel() -> GetTradeData() -> ReceiveTrade()_Controller -> ReceiveTrade() -> RequestAgain()
*/

namespace RedTheSettlers.UnitTest
{
    public interface IMediatable
    {

    }

    public delegate void TradeCallback();
    
    public class TradeData
    {
        public User RequestSender { get; set; }
        public User RequestReceiver { get; set; }

        public List<ItemData> ItemsToSend;
        public List<ItemData> ItemsToReceive;
    }

    public class TradeControllerTest : MonoBehaviour, IMediatable
    {
        private TradeData Trade;

        private TradeCallback _callback;
        public TradeCallback Callback
        {
            get { return _callback; }
            set { _callback = value; }
        }

        public void MatchTrade(User requestSender, User requestReceiver)
        {
            Trade.RequestSender = requestSender;
            Trade.RequestReceiver = requestReceiver;
        }

        public void ChangeTradeData(ItemData itemData)
        {
            for(int index = 0; index < Trade.ItemsToSend.Count; index++)
            {
                if (itemData.ItemType == Trade.ItemsToSend[index].ItemType)
                {
                    Trade.ItemsToSend[index] = itemData;

                    break;
                }
            }
        }
    }
}