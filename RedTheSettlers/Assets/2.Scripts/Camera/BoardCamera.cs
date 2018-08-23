using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    class BoardCamera : AbstractCamera
    {
        public BoardCamera(GameObject cameraObject)
        {
            camera = cameraObject.GetComponent<Camera>();
            cameraMoving = new DragMoving(cameraObject);
            cameraZoomInOut = new DragZoom(cameraObject);
            cameraAngle = new LookAtManual(cameraObject);
        }
    } 
}