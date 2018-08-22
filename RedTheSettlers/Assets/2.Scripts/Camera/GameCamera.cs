using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class GameCamera : MonoBehaviour
    {

        AbstractCamera abstractCamera;
        string cameraName;
        private void Awake()
        {
            cameraName = gameObject.name;
            if (cameraName == "Board Camera")
            {
                abstractCamera = new BoardCamera(gameObject);
            }
            else
            {
                abstractCamera = new BattleCamera(gameObject);
            }
            //abstractCamera = gameObject.GetComponent<Camera>();
        }


        public void TrunOnCamera()
        {
            abstractCamera.TurnOn();
        }
        public void TrunOffCamera()
        {
            abstractCamera.TurnOff();
        }
        public void MovingCamera(Vector3 vector3)
        {
            abstractCamera.MovingCamera(vector3);
        }
        public void ZoomInOutCamera(float value)
        {
            abstractCamera.ZoomInOutCamera(value);
        }
        public void Looking(Transform target)
        {
            abstractCamera.LookAt(target);
        }



    } 
}