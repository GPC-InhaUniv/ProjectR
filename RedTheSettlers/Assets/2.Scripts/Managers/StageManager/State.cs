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

abstract class State
{

    public StageManager StageManager { get; set; }

    public abstract void mddd();
    public abstract void Exit();

    
}
