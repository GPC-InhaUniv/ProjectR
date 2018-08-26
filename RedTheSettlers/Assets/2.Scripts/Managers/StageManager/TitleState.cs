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
        public override State Enter()
        {
            throw new System.NotImplementedException();
            //확인 버튼을 누르면

        }

        public override State Exit()
        {
            throw new System.NotImplementedException();
            // 로그인이 성공이라면 로딩장면 상태로 넘어간다.
        }
    }

}

