using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class CameraShakeState : ICameraState
    {
        GameObject cameraObject;
        float duration, magnitude;
        public CameraShakeState(GameObject cameraObject)
        {
            Debug.Log("CameraShakeState" + cameraObject);
            this.cameraObject = cameraObject;
            duration = 0.15f;
            magnitude = 4f;
        }

        public void CameraBehavior(Vector3 vector)
        {
            Debug.Log("CameraShakeState + CameraBehavior" + cameraObject);
            //StartCoroutine(Shake(duration, magnitude));
        }
        //IEnumerator Shake(float duration, float magnitude)
        //{
        //    Vector3 origianlPos = cameraObject.transform.localPosition;

        //    float elaspsed = 0.0f;

        //    while (elaspsed < duration)
        //    {
        //        float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
        //        float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

        //        cameraObject.transform.localPosition = new Vector3(x, y, origianlPos.z);

        //        elaspsed += Time.deltaTime;

        //        yield return null;
        //    }

        //    cameraObject.transform.localPosition = origianlPos;
        //}
    }
}