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
        private int weaponLevel;
        private int shieldLevel;
        public List<Skill> SkillList = new List<Skill>(3);

        public void InitializePlayerData(int weaponLevel, int shieldLevel, List<Skill> skillList)
        {
            this.weaponLevel = weaponLevel;
            this.shieldLevel = shieldLevel;
            SkillList = skillList;
        }

        public void SetSkillSlot(int skillnum, int slotNum)
        {
            switch(skillnum)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        public void MoveToTargetTile(BoardTile targetTile)
        {
            PossessTile(targetTile);
        }

        public void PossessTile(BoardTile targetTile)
        {
            PossessingTile.Add(targetTile);
        }

        public override void ChangeItemCount(ItemData[] itemList)
        {
            for (int i = 0; i < GlobalVariables.MaxItemNumber; i++)
            {
                inventory[i].Count += itemList[i].Count;
            }
        }
    }
}
