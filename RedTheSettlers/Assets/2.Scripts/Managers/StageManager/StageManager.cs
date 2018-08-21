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

namespace RedTheSettlers.GameSystem
{

    public enum StageType
    {
        TitleStageState,
        LoadingStageState,
        MainStageState,
        TutorialStageState,
        BattleStageState

    }

    public class StageManager : Singleton<StageManager>
    {

        private StageStateMachine stageStateMachine;
        private float _loadingProgress;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void ChangeStage(StageType stageType)
        {
            switch (stageType)
            {

                case StageType.TitleStageState:
                    SceneManager.LoadSceneAsync((int)StageType.LoadingStageState);
                    break;
                case StageType.LoadingStageState:
                    SceneManager.LoadScene((int)StageType.MainStageState);
                    break;
                case StageType.MainStageState:
                    SceneManager.LoadScene((int)StageType.MainStageState);
                    break;
               
            }

        }

        public IEnumerator ChangeStageLoad(StageType stageType)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(stageType.ToString());
            
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                _loadingProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f) * 100;

                yield return new WaitForSeconds(0.1f);

                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return SceneManager.LoadSceneAsync(stageType.ToString());

            }
            
        }
    }

}
