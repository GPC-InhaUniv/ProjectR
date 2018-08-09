using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    class BoardCamera : AbstractCamera
    {
        //추상적 개념에 정의된 인터페이스를 확장한다

        public BoardCamera(GameObject cameraObject)
        {
            //GetCamera();
            cameraMoving = cameraObject.AddComponent<DragMoving>();
            cameraZoomInOut = cameraObject.AddComponent<ManualZoom>();
            cameraAngle = cameraObject.AddComponent<LookAtManual>();
        }
    } 
}