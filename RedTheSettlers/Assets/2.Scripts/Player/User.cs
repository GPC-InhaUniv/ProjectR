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

        public abstract void ChangeItemCount(ItemData[] itemList);
    }
}
