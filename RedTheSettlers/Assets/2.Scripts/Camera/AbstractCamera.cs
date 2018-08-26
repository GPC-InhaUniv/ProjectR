using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public abstract class AbstractCamera
    {
        //추상적 개념에 대한 인터페이스를 제공하고 객체 구현자(ICamera)에 대한 참조자를 관리한다
        //카메라에 뭐가 있어야할까 생각해보자
        //카메라는 TurnOnOff가 있고 zoomInOut이 있고 이동하기도 하고 목표를 바라보기도 하고... 등
        
        protected Camera camera;
        protected CameraMoving cameraMoving;
        protected CameraZoomInOut cameraZoomInOut;
        protected CameraAngle cameraAngle;

        //private AbstractCamera(Camera camera)
        //{
        //    this.camera = camera;
        //}

        public void TurnOn()
        {
            camera.enabled = true;
        }
        public void TurnOff()
        {
            camera.enabled = false;
        }


        public void MovingCamera(Vector3 vector3)
        {
            cameraMoving.Moving(vector3);
        }
        public void ZoomInOutCamera(float value)
        {
            cameraZoomInOut.ZoomInOut(value);
        }
        public void LookAt(Transform target)
        {
            cameraAngle.Looking(target);
        }
    } 
}