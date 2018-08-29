using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    class LoadingState : State
    { 
                
        //private StageType stageType;

        //public LoadingState(StageType stageType)
        //{
        //    this.stageType = stageType;
        //}

        public override void ContinueGame(bool canLoadData)
        {
            
        }

        public override void Enter(StageType stageType)
        {
            StageManager.Instance.StartCoroutine(StageManager.Instance.ChangeStageLoad(stageType));
        }

        public override void Exit(StageType stageType)
        {
            //StageManager.Instance.ChangeStage(StageType.MainStageState);
        }
        
    }
        
}
