using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    class BattleCamera : AbstractCamera
    {
        public BattleCamera(GameObject cameraObject)
        {
            //GetCamera();
            camera = cameraObject.GetComponent<Camera>();
            //cameraMoving = cameraObject.AddComponent<FollowMoving>();
            //cameraZoomInOut = cameraObject.AddComponent<DragZoom>();
            //cameraAngle = cameraObject.AddComponent<LookAtTarget>();
            cameraMoving = new FollowMoving(cameraObject);
            cameraZoomInOut = new DragZoom();
            cameraAngle = new LookAtTarget();

        }
    } 
}
