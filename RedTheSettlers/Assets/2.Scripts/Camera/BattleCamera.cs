using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BattleCamera : AbstractCamera
{
    public BattleCamera(GameObject cameraObject)
    {
        //GetCamera();
        cameraMoving = cameraObject.AddComponent<FollowMoving>();
        cameraZoomInOut = cameraObject.AddComponent<DragZoom>();
        cameraAngle = cameraObject.AddComponent<LookAtTarget>();
    }
}
