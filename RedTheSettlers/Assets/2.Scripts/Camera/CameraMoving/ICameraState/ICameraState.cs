using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public interface ICameraState
    {
        void CameraBehavior(Vector3 vector3);
    } 
}