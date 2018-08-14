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
}