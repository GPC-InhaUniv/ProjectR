using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class CameraMoving : MonoBehaviour
{
    public GameObject cameraObject;
    public abstract void Moving();
}