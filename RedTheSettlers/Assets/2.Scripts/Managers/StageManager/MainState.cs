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
    class MainState : State
    {
        


        public override State ChangeStage(StageType stageType)
        {
            switch (stageType)
            {
                case StageType.TutorialStageState:

                    return new TutorialState();

                case StageType.BattleStageState:

                    return new BattleState();

                default:
                    return null;
            }
        }



    }
}

