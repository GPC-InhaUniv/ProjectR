using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Players;

namespace RedTheSettlers.Skills
{
    public class SpeedUpBuffSkill : Skill
    {
        public override IEnumerator ActivateSkill(BattlePlayer User)
        {
            User.ChangeSpeed(0.5f);

            yield return new WaitForSeconds(2f);

            User.ChangeSpeed(-0.5f);

            yield return null;
        }
    }
}
