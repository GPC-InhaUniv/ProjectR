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

        private State currentState;

        private void Start()
        {
<<<<<<< HEAD

            currentState = new TitleState();
=======
>>>>>>> 676814679227a1f9f2a56ca77747758cbbb6fc46
            DontDestroyOnLoad(gameObject);
            StartCoroutine("ChangeStageLoad");
        }


        public void ChangeState(StageType stageType)
        {
            switch (stageType)
            {
                case StageType.LoadingStageState:
                    currentState = new TitleState();

                    break;
                case StageType.MainStageState:
                    currentState = new LoadingState();

                    break;
                case StageType.BattleStageState:
                    currentState = new MainState();

                    break;
                case StageType.TutorialStageState:
                    currentState = new MainState();

                    break;
            }
            currentState.ChangeStage(stageType);
        }
        
        public void SwichCamera(StageType stageType)
        {
            currentState = currentState.Camera(stageType);
        }

<<<<<<< HEAD
        public void Load()
        {

        }
=======
        public IEnumerator ChangeStageLoad(StageType stageType)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
>>>>>>> 676814679227a1f9f2a56ca77747758cbbb6fc46

            asyncOperation.allowSceneActivation = false;

            yield return asyncOperation;

            asyncOperation.allowSceneActivation = true;
        }
    }

}
