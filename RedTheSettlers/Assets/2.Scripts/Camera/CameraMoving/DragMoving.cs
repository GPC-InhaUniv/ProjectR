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

        private void Awake()
        {
            dragSpeed = 1;
            cameraObject = gameObject;
        }

        public override void Moving()
        {
            Debug.Log("보드카메라 무빙카메라()");
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
            cameraObject.transform.Translate(move, Space.World);
        }
    } 
}