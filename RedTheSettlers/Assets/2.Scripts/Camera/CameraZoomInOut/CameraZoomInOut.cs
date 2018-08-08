using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class CameraZoomInOut : MonoBehaviour
{
    public Camera camera;
    public float zoomSpeed = 5.0f;
    public float cameraFOV;
    public abstract void ZoomInOut();
}