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
///   
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

        [SerializeField]
        private StageStateMachine stageStateMachine;
        public StageStateMachine StageStateMachine { get { return stageStateMachine; } }

      

                

        private float loadingProgress;


        private void Awake()
        {
            stageStateMachine = new StageStateMachine();
            DontDestroyOnLoad(gameObject);
        }

        public void JudgeLoadingData(bool canLoadData, StageType stageType)
        {
            //if (!canLoadData)
            //    DataManager.Instance.ResetData();

            StageStateMachine.ContinueGame(canLoadData);
            ChangeStage(stageType);
        }

        public void ChangeStage(StageType stageType)
        {
            stageStateMachine.Enter(stageType);
            StageStateMachine.Exit(stageType);
        }

        public void ChangeCamera(StageType stageType)
        {
            StageStateMachine.Enter(stageType);
        }


        public IEnumerator ChangeStageLoad(StageType stageType)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(stageType.ToString());

            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                loadingProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f) * 100;

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
