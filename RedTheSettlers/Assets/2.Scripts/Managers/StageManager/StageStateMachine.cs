using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public class StageStateMachine
    {
        private State currentstate;
        public State CurrentState
        {
            get { return currentstate; }
        }

        public void Enter()
        {
            currentstate.Enter();
        }

        public void Exit()
        {
            currentstate.Exit();
        }
                
    }
}

