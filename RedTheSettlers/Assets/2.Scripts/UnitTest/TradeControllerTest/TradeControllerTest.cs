﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;
using RedTheSettlers.UI;


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

        //public void MatchTrade(User requestSender, User requestReceiver)
        //{
        //    Trade.RequestSender = requestSender;
        //    Trade.RequestReceiver = requestReceiver;

        //    Trade.ItemsToTrade = new ItemData[6];
        //}

        //public void ChangeTradeData(ItemData itemData)
        //{
        //    Debug.Log(itemData.ItemType);
        //    Trade.ItemsToTrade[(int)itemData.ItemType] = itemData;
        //}

        private OtherPlayerState RandomAI()
        {
            int ai = Random.Range(1, 3); // no, yes
            return (OtherPlayerState)ai;
        }

        public void DoTrade(TradeData trade)
        {
            OtherPlayerState ai = RandomAI();
            if (ai == OtherPlayerState.Yes)
            {
                trade.RequestSender.ChangeItemCount(trade.ItemsToTrade);

                for (int i = 0; i < GlobalVariables.MaxItemNumber; i++)
                {
                    trade.ItemsToTrade[i].Count *= -1;
                }

                trade.RequestReceiver.ChangeItemCount(Trade.ItemsToTrade);
            }
            else { } // ai == OtherPlayerState.No

            GameManager.Instance.SendTradeResult(ai);
            Callback();
        }

        //private void ResetTrade()
        //{
        //    Trade.RequestSender = null;
        //    Trade.RequestReceiver = null;
        //    Trade.ItemsToTrade = null;
        //}
    }
}