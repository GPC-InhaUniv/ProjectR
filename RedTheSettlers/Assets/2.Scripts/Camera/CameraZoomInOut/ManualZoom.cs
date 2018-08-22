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

        public ManualZoom(Camera camera)
        {
            this.camera = camera;
        }
        public override void ZoomInOut(float value)
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
        private void ZoomIn(float zoomIn)
        {
            //while (true)
            //{
            //    if (camera.fieldOfView <= zoomIn)
            //    {
            //        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomIn, Time.deltaTime * zoomSpeed);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            ////yield return new WaitForSeconds(1f);//WaitForEndOfFrame();
            //return camera.fieldOfView;
        }
        //private IEnumerator ZoomOut(float cameraFOV)
        //{
        //    while (true)
        //    {
        //        if (camera.fieldOfView >= cameraFOV)
        //        {
        //            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, cameraFOV, Time.deltaTime * zoomSpeed);
        //            yield return new WaitForSeconds(0.5f);
        //        }
        //        else break;

        //    }
        //    yield return new WaitForSeconds(1f);
        //}
    }
}