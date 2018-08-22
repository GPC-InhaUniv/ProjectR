using RedTheSettlers.Tiles;
using RedTheSettlers.GameSystem;
using RedTheSettlers.UnitTest;
using RedTheSettlers.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Users
{
    public class BoardPlayer : User
    {
        private int WeaponLevel;
        private int ShieldLevel;
        private Dictionary<Skill, QuickSlot> skillSet;

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

        protected override void ReceiveTrade(User requestPlayer, TradeData tradeData)
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterPlayer(User player)
        {
            throw new System.NotImplementedException();
        }

        protected override void RequestAgain(User respondPlayer, TradeData tradeData)
        {
            throw new System.NotImplementedException();
        }
    }
}
