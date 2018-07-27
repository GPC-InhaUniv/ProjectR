using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCamera : MonoBehaviour {
    Camera camera;
    public bool IsZoom;
    float zoomIn;
    float zoomOut;
    float smooth;

    public bool IsTarget;
    Transform Target;
    float vDistance;
    float hDistance;

    private void Start()
    {
        camera = GetComponent<Camera>();
        zoomIn = 20;
        zoomOut = camera.fieldOfView;
        smooth = 5;
    }

    private void Update()
    {
        ZoomInOut(IsZoom);
        
        //임시_타겟이 있으면 타겟으로 이동하는 부분
        if(Target != null)
        {
            MoveToTarget(Target);
        }
        //임시_카메라 움직이는 부분

    }

    void MoveToTarget(Transform target)
    {

    }
    void ZoomInOut(bool isZoom)
    {
        if (isZoom)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,zoomIn,Time.deltaTime*smooth);
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomOut, Time.deltaTime * smooth);
        }
    }
	
}
