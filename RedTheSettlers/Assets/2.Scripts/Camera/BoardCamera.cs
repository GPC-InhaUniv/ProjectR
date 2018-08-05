using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCamera : AbstractCamera{
    //추상적 개념에 정의된 인터페이스를 확장한다
    
    float zoomIn;
    float zoomOut;
    float smooth;

    //public bool IsTarget;
    //Transform Target;
    
    private void Start()
    {
        GetCamera();
        Debug.Log("보드카메라 들어옴");
        zoomIn = 20;
        zoomOut = camera.fieldOfView;
        smooth = 5;
    }
    
    

    float vDistance;
    float hDistance;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public override void MovingCamera()
    {
        Debug.Log("보드카메라 무빙카메라()");
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }

    public override void ZoomIn()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomIn, Time.deltaTime * smooth);
    }

    public override void ZoomOut()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomOut, Time.deltaTime * smooth);
    }
}
