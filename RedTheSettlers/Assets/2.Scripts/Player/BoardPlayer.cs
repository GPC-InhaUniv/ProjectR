using RedTheSettlers.Tiles;
using RedTheSettlers.GameSystem;
using RedTheSettlers.UnitTest;
using RedTheSettlers.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Players
{
    public class BoardPlayer
    {
        private Tile tileSteppingOn;
        private List<Tile> PossessingTile;
        private int WeaponLevel;
        private int ShieldLevel;
        private Dictionary<ItemType, int> inventory;
        private Dictionary<Skill, QuickSlot> skillSet;
        private IMediatable mediatable;

        public void MoveToTargetTile(BoardTile targetTile)
        {

        }

        public void PossessTile(BoardTile targetTile)
        {
            PossessingTile.Add(targetTile);
        }

        public void ShowInformation()
        {

        }


    }
}
