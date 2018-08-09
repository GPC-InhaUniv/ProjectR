using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
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
                Debug.Log("줌인");
                //StartCoroutine(ZoomIn(zoomIn));
                isZoom = true;
            }
            else
            {
                Debug.Log("줌아웃");
                //StartCoroutine(ZoomOut(cameraFOV));
                isZoom = false;
            }

        }
        private IEnumerator ZoomIn(float zoomIn)
        {
            while (true)
            {
                if (camera.fieldOfView <= zoomIn)
                {
                    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomIn, Time.deltaTime * zoomSpeed);
                }
                else
                {
                    break;
                }
            }
            yield return new WaitForSeconds(1f);//WaitForEndOfFrame();
        }
        private IEnumerator ZoomOut(float cameraFOV)
        {
            while (true)
            {
                if (camera.fieldOfView >= cameraFOV)
                {
                    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, cameraFOV, Time.deltaTime * zoomSpeed);
                }
                else break;

            }
            yield return new WaitForSeconds(1f);
        }
    }
}