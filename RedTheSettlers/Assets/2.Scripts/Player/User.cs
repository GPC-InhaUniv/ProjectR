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
        public Tile tileSteppingOn;
        public List<Tile> PossessingTile;
        public ItemData[] inventory;
        protected IMediatable mediatable;

        protected abstract void ChangeItemCount(ItemData[] itemList);
    }
}
