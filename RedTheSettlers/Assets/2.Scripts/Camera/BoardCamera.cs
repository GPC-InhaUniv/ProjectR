using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCamera : MonoBehaviour, ICamera{
    Camera camera;
    //bool IsZoom;
    float zoomIn;
    float zoomOut;
    float smooth;

    //public bool IsTarget;
    //Transform Target;
    //float vDistance;
    //float hDistance;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    private void Start()
    {
        camera = GetComponent<Camera>();
        zoomIn = 20;
        zoomOut = camera.fieldOfView;
        smooth = 5;
    }

    private void Update()
    {
        //ZoomInOut(IsZoom);
        
        //임시_카메라 움직이는 부분
        MovingCamera();
    }

    public void ZoomInOut(bool isZoom)
    {
        if (isZoom)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomIn, Time.deltaTime * smooth);
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomOut, Time.deltaTime * smooth);
        }
    }

    public void MovingCamera()
    {
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

    public void TurnOnCamera()
    {
        Debug.Log("TurnOnCamera");
        camera.enabled = true;
    }

    public void TurnOffCamera()
    {
        Debug.Log("TurnOffCamera");
        camera.enabled = false;
    }
    
    
}
