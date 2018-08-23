using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    class BattleCamera : AbstractCamera
    {
        public BattleCamera(GameObject cameraObject)
        {
            camera = cameraObject.GetComponent<Camera>();
            cameraMoving = new FollowMoving(cameraObject);
            cameraZoomInOut = new DragZoom(cameraObject);
            cameraAngle = new LookAtTarget(cameraObject);
        }
    } 
}
