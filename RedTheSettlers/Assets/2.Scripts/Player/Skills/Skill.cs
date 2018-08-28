using RedTheSettlers.Players;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Skills
{
    [Flags]
    public enum SkillType
    {
        Melee = 0,
        Range = 1,
        Buff = 2
    }

    public abstract class Skill
    {
        public SkillType skillType;
        public abstract IEnumerator ActivateSkill(BattlePlayer battlePlayer);
    }
}
