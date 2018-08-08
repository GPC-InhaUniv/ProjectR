using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DragZoom : CameraZoomInOut
{
    private void Awake()
    {
        camera = gameObject.GetComponent<Camera>();
    }
    public override void ZoomInOut()
    {
        Debug.Log("드레그줌인아웃");
        if (Input.touchCount == 2)
        {
            Debug.Log("드레그줌인아웃 if");
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMagitude = (touchZeroPos - touchOnePos).magnitude;
            float touchDeltaMagitud = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMagitude - touchDeltaMagitud;

            camera.fieldOfView += deltaMagnitudediff * zoomSpeed;
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 40f, 160f);
        }
    }
}
