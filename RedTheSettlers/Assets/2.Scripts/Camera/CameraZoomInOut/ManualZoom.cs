using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ManualZoom : CameraZoomInOut
{
    bool isZoom;
    float zoomIn = 30f;

    private void Awake()
    {
        camera = gameObject.GetComponent<Camera>();
        cameraFOV = camera.fieldOfView;
    }
    public override void ZoomInOut()
    {
        Debug.Log(isZoom);
        if (!isZoom)
        {
            Debug.Log("줌들어옴");
            StartCoroutine(ZoomIn(zoomIn));
            isZoom = true;
        }
        else
        {
            StartCoroutine(ZoomOut(cameraFOV));
            isZoom = false;
        }

    }
    private IEnumerator ZoomIn(float zoomIn)
    {
        while (camera.fieldOfView <= zoomIn)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomIn, Time.deltaTime * zoomSpeed);

        }
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator ZoomOut(float cameraFOV)
    {
        while (camera.fieldOfView >= cameraFOV)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, cameraFOV, Time.deltaTime * zoomSpeed);

        }
        yield return new WaitForEndOfFrame();
    }
}
