using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace RedTheSettlers.GameSystem
{
    public class CameraNomalState : ICameraState
    {
        Transform targetTransform;
        Vector3 cameraOffset;
        [SerializeField]
        [Range(0.01f, 1.0f)]
        float smooth = 0.1f;

        GameObject cameraObject;

        public CameraNomalState(GameObject cameraObject)
        {
            Debug.Log("CameraNomalState"+ cameraObject);
            this.cameraObject = cameraObject;
            FindTarget();
            cameraOffset = cameraObject.transform.position - targetTransform.position;
        }

        public void CameraBehavior(Vector3 vector3)
        {
            if (targetTransform == null)
            {
                Debug.Log("타겟이 없어서 타겟을 찾는다");
                FindTarget();
            }
            else
            {
                Vector3 newPos = targetTransform.position + cameraOffset;
                cameraObject.transform.position = Vector3.Slerp(cameraObject.transform.position, newPos, smooth);
            }
            
        }
        
        private void FindTarget()
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}