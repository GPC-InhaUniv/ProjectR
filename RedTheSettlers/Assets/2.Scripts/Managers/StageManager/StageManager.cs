using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 담당자 : 이재환
/// 수정시 간략 설명과 수정 날짜 
/// {
///   Ex : 함수명 변경 18/07/15
///   Context 부분 
///   
/// }
/// </summary>

public enum StageType
{
    TitleStage,
    LodingStage,
    MainStage,
    TutorialStage,
    BattleStage
}

public class StageManager : Singleton<StageManager>
{
    private State currentState;

    private void Awake()
    {
        currentState = new TitleState();
        DontDestroyOnLoad(gameObject);
    }
   
    public void ChangeState(StageType stageType)
    {
        currentState = currentState.Execute(stageType);
    }
}
