using UnityEngine;
using RedTheSettlers.Users;

namespace RedTheSettlers.GameSystem
{
    public delegate void TradeCallback();

    public class TradeData
    {
        public User RequestSender { get; set; }
        public User RequestReceiver { get; set; }

        public ItemData[] ItemsToTrade;
    }

    public class TradeController : MonoBehaviour
    {
        private TradeCallback _callback;
        public TradeCallback Callback
        {
            get { return _callback; }
            set { _callback = value; }
        }

        private OtherPlayerState RandomAI()
        {
            int ai = Random.Range(1, 3); // 1 : no, 2 : yes
            return (OtherPlayerState)ai;
        }

        public void DoTrade(TradeData trade)
        {
            OtherPlayerState ai = RandomAI();

            if (ai == OtherPlayerState.Trade) { }
            else if (ai == OtherPlayerState.Yes)
            {
                trade.RequestSender.ChangeItemCount(trade.ItemsToTrade);

                for (int i = 0; i < GlobalVariables.MaxItemNumber; i++)
                {
                    trade.ItemsToTrade[i].Count *= -1;
                }

                trade.RequestReceiver.ChangeItemCount(trade.ItemsToTrade);
            }
            else { } // ai == OtherPlayerState.No

            GameManager.Instance.SendTradeResult(ai);
            Callback();
        }
    }
}