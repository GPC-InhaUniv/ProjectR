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

        protected abstract void TakeItem(TradeData tradeData);
        protected abstract void GiveItem(TradeData tradeData);
    }
}
