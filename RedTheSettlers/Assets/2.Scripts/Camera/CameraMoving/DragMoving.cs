using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class DragMoving : CameraMoving
    {
        [SerializeField]
        private float dragSpeed;
        private Vector3 dragOrigin;

        public DragMoving(GameObject cameraObject)
        {
            this.cameraObject = cameraObject;
            dragSpeed = 1;
        }

        public override void Moving(Vector3 vector3)
        {
            cameraObject.transform.Translate(vector3, Space.World);
        }
    } 
}