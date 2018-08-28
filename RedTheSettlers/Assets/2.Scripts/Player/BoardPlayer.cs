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
        public List<Skill> SkillList;

        public void InitializePlayerData(int weaponLevel, int shieldLevel, List<Skill> skillList)
        {
            this.weaponLevel = weaponLevel;
            this.shieldLevel = shieldLevel;
            this.SkillList = skillList;
        }

        public void SetSkillSlot(Skill skill)
        {
            SkillList.Add(skill);
            SkillList.Sort((Skill x, Skill y) => x.skillType.CompareTo(y.skillType));
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
