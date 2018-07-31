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
    BattleStage,
    GameOverStage
}

public class StageManager : Singleton<StageManager>
{
    public StageType currentStage;

    private State currentState;

    private void Awake()
    {
        SceneManager.LoadSceneAsync((int)StageType.TitleStage);
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator ChangeStageCoroutine(StageType stageType)
    {
        if (currentStage == StageType.TitleStage)
        {
            SceneManager.LoadSceneAsync((int)stageType);
            currentStage = stageType;
        }

      else if (currentStage == StageType.MainStage && currentStage == StageType.BattleStage &&
               currentStage == StageType.TutorialStage)
           {
                AsyncOperation loadPlan = SceneManager.LoadSceneAsync((int)stageType);
                currentStage = stageType;
                yield return loadPlan;
           }
        else
        {
            AsyncOperation loadPlan;
            if (stageType == StageType.LodingStage)
            {
                loadPlan = SceneManager.LoadSceneAsync((int)StageType.LodingStage);
            }
            else
            {
                loadPlan = SceneManager.LoadSceneAsync((int)StageType.GameOverStage);
            }
        }
    }
}
