using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class LookAtTarget : CameraAngle
    {
        public Transform targetTransform;
        
        public LookAtTarget(GameObject gameObject)
        {
            cameraObject = gameObject;
        }
        public override void Looking(Transform target)
        {
            Debug.Log("루킹" + target);
            if (targetTransform == null)
            {
                targetTransform = target;
                Debug.Log("타겟이 없음");
                return;
            }
            if(targetTransform != null)
            {
                cameraObject.transform.LookAt(targetTransform);
            }
        }
    } 
}