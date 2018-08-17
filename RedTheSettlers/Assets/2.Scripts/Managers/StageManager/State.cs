using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    abstract class State
    {
<<<<<<< HEAD
        public abstract State Execute(StageType stageType);
        public abstract State Execute();
        public abstract State Camera(StageType stageType);
=======
        public abstract State ChangeStage(StageType stageType);
        
>>>>>>> 676814679227a1f9f2a56ca77747758cbbb6fc46
    }
}
