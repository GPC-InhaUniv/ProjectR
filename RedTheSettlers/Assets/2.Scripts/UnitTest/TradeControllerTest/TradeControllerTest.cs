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
    public delegate void TradeCallback();
    
    public class TradeData
    {
        public User RequestSender { get; set; }
        public User RequestReceiver { get; set; }

        public ItemData[] ItemsToTrade;
    }

    public class TradeControllerTest : MonoBehaviour
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

            Trade.ItemsToTrade = new ItemData[6];
        }

        public void ChangeTradeData(ItemData itemData)
        {
            Trade.ItemsToTrade[(int)itemData.ItemType] = itemData;
        }

        public void DoTrade()
        {
            Trade.RequestSender.ChangeItemCount(Trade.ItemsToTrade);

            for(int i = 0; i < GlobalVariables.MaxItemNumber; i++)
            {
                Trade.ItemsToTrade[i].Count *= -1;
            }

            Trade.RequestReceiver.ChangeItemCount(Trade.ItemsToTrade);

            ResetTrade();

            Callback();
        }

        private void ResetTrade()
        {
            Trade.ItemsToTrade = null;
        }
    }
}