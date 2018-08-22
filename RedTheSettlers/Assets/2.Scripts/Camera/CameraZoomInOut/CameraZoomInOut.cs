using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public abstract class CameraZoomInOut
    {
        public Camera camera;
        //public float zoomSpeed = 5.0f;
        //public float cameraFOV;
        
        public abstract void ZoomInOut(float value);
    } 
}