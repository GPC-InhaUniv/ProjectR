using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BattleCamera : AbstractCamera
{
    [SerializeField]
    Transform Target;
    //추상적 개념에 정의된 인터페이스를 확장한다
    private void Start()
    {
        GetCamera();
        Debug.Log("배틀카메라 들어옴");
    }
    public override void MovingCamera()
    {

    }

    public override void ZoomIn()
    {
        Debug.Log("배틀카메라 줌인");
    }

    public override void ZoomOut()
    {
        Debug.Log("배틀카메라 줌아웃");
    }
}
