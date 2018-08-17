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
    class LoadingState : State
    {
        public override State ChangeStage(StageType stageType)
        {
            SceneManager.LoadScene((int)StageType.MainStageState);
            return new MainState();
        }

       
        
    }

}
