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
        private void Awake()
        {
            cameraObject = gameObject;
        }
        public override void Looking(Transform target)
        {
            Debug.Log("루킹" + target);
            if (targetTransform == null)
            {
                targetTransform = target;
                return;
            }

            cameraObject.transform.LookAt(targetTransform);
        }
    } 
}