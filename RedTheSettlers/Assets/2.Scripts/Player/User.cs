using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;
using RedTheSettlers.GameSystem;
using RedTheSettlers.UnitTest;

namespace RedTheSettlers.Users
{
    public abstract class User : MonoBehaviour
    {
        protected Tile tileSteppingOn;
        protected List<Tile> PossessingTile;
        protected Dictionary<ItemType, int> inventory;
        protected IMediatable mediatable;

        protected abstract void RegisterPlayer(User player);
        protected abstract void ReceiveTrade(User requestPlayer, TradeData tradeData);
        protected abstract void RequestAgain(User respondPlayer, TradeData tradeData);
    }
}
