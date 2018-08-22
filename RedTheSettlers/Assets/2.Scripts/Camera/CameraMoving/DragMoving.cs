using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
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
            Debug.Log(cameraObject+"드레그무빙 무빙!"+vector3);

            //cameraObject.transform.Translate(vector3, Space.World);
            //camera.transform.Translate(new Vector3(direction.x, 0, direction.y), Space.World);

            cameraObject.transform.Translate(new Vector3(vector3.x,0, vector3.y), Space.World);
        }
    } 
}