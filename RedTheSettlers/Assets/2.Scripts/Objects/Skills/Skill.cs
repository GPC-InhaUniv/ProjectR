using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Skills
{
    [Flags]
    public enum SkillType
    {
        Melee,
        Range,
        Buff,
    }

    public class Skill : MonoBehaviour
    {

        private float duration = 0;

        private IEnumerator Start()
        {
            while (duration > 3.0f)
            {
                yield return null;
            }

        }
    }
}
