using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LookAtManual : CameraAngle
{
    private void Awake()
    {
        cameraObject = gameObject;
    }
    public override void Looking(Transform target)
    {
        Debug.Log("룩엣메뉴얼");
        return;
    }
}
