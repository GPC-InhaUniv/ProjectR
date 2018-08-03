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

 class LodingState : State
{
  

    public override State Execute(StageType stageType)
    {
        switch (stageType)
        {
            case StageType.MainStage:
                SceneManager.LoadSceneAsync((int)stageType);
                return new MainState();
            default:
                return null;
        }
    }

}
