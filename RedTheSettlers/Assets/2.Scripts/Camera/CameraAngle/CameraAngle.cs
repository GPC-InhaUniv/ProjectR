using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public abstract class CameraAngle : MonoBehaviour
    {
        public GameObject cameraObject;
        public abstract void Looking(Transform target);
    } 
}
