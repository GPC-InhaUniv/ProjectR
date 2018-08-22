﻿using RedTheSettlers.Tiles;
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
        private SkillData[] SkillData;

        public void MoveToTargetTile(BoardTile targetTile)
        {
            PossessTile(targetTile);
        }

        public void PossessTile(BoardTile targetTile)
        {
            PossessingTile.Add(targetTile);
        }

        protected override void GiveItem(TradeData tradeData)
        {
            throw new System.NotImplementedException();
        }

        protected override void TakeItem(TradeData tradeData)
        {
            throw new System.NotImplementedException();
        }
    }
}
