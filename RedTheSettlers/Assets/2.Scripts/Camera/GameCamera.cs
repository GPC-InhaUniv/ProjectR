using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GameCamera : MonoBehaviour
{
    [SerializeField]
    AbstractCamera abstractCamera;
    private void Start()
    {
        
    }
    //int CameraCount
    //{
    //    get
    //    {
    //        if(abstractCamera != null)
    //        {
    //            return abstractCamera.CameraModuleCount;
    //        }
    //        return -1;
    //    }
    //}
    public void PutInCamera(AbstractCamera abstractCamera)
    {
        Debug.Log("게임카메라 풋인카메라"+abstractCamera);
        this.abstractCamera = abstractCamera;
    }
    void TrunOnCamera()
    {
        abstractCamera.TurnOn();
    }
}