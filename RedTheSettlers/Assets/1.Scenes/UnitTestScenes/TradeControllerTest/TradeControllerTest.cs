using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers
{
    namespace UnitTest
    {
        abstract public class Player
        {
            private IMediatable mediator;
            public PlayerData playerData;
            
            public Player(IMediatable mediator)
            {
                this.mediator = mediator;
            }

            public void ShowTradePanel()
            {
                
            }

            public void RequestTrade(Player requestPlayer, PlayerData tradeItem)
            {
                mediator.RequestTrade(requestPlayer);
            }

            public void Accept(Player respondPlayer)
            {

            }

            public void Deny(Player respondPlayer)
            {

            }

            public void RequestAgain(Player respondPlayer)
            {

            }
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
            void RequestTrade(Player requestPlayer);
            void Accept(Player  respondPlayer);
            void Deny(Player respondPlayer);
            void RequestAgain(Player respondPlayer);
            void ShowTradePanel(Player requestPlayer);
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

            public void ShowTradePanel(Player requestPlayer)
            {

            }

            public void RegisterPlayer(Player player)
            {
                playerList.Add(player);   
            }

            public void RequestTrade(Player requestPlayer)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i] != requestPlayer)
                        ;//playerList[i].
                }
            }

            public void Accept(Player respondPlayer)
            {
                throw new System.NotImplementedException();
            }

            public void Deny(Player respondPlayer)
            {
                throw new System.NotImplementedException();
            }

            public void RequestAgain(Player respondPlayer)
            {
                throw new System.NotImplementedException();
            }
        }

    }
}