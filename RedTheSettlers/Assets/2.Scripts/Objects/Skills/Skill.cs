using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum SkillType
{
    
}

public class Skill : MonoBehaviour {

    private float duration = 0;

    private IEnumerator Start()
    {
        while(duration > 3.0f)
        {
            yield return null;
        }

    }
}
