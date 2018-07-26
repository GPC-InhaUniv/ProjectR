using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임의 시간을 관리하는 기반 클래스
/// </summary>
public class GameTimeManager : Singleton<GameTimeManager>
{
    protected GameTimeManager() { }

    public static float TimeScale;
    public static float DeltaTime;
    private float startTime;
    private float fixedDeltaTime;

    private void Awake()
    {
        startTime = Time.realtimeSinceStartup;
        fixedDeltaTime = Time.fixedDeltaTime;
        TimeScale = 1f;
    }

    private void Update()
    {
        DeltaTime = Time.realtimeSinceStartup - startTime;
        startTime = Time.realtimeSinceStartup;

        Time.fixedDeltaTime = fixedDeltaTime * TimeScale;
    }
}
