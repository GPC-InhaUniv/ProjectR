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
/// }
/// </summary>

namespace RedTheSettlers.GameSystem
{
    class TitleState : State
    {
        public override State Camera(StageType stageType)
        {
            throw new System.NotImplementedException();
        }

        public override State Execute(StageType stageType)
        {
            SceneManager.LoadSceneAsync((int)StageType.LoadingStageState);
            return new LoadingState();
        }

        public override State Execute()
        {
            return null;
        }
    }

}

