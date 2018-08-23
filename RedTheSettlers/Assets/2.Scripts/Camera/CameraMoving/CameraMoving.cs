using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public abstract class CameraMoving
    {
        public GameObject cameraObject;
        public abstract void Moving(Vector3 vector3);
    }


    public class DragMoving : CameraMoving
    {
        //[SerializeField]
        //private float dragSpeed;
        //private Vector3 dragOrigin;

        public DragMoving(GameObject cameraObject)
        {
            Debug.Log("드레그무빙 생성자");
            this.cameraObject = cameraObject;
            //dragSpeed = 1;
        }

        public override void Moving(Vector3 vector3)
        {
            cameraObject.transform.Translate(new Vector3(vector3.x, 0, vector3.y), Space.World);
        }
    }



    public class FollowMoving : CameraMoving
    {
        //애니메이션 필요함
        Transform targetTransform;
        Vector3 cameraOffset;

        [SerializeField]
        [Range(0.01f, 1.0f)]
        float smooth = 0.1f;

        ICameraState cameraState;

        public FollowMoving(GameObject cameraObject)
        {
            this.cameraObject = cameraObject;
            FindTarget();
            cameraOffset = cameraObject.transform.position - targetTransform.position;


            cameraState = new CameraNomalState();
        }

        public override void Moving(Vector3 vector3)
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
            cameraState.CameraBehavior(vector3);
        }


        private void FindTarget()
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }
}