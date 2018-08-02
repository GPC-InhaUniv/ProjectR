using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractCamera : MonoBehaviour
{
    //추상적 개념에 대한 인터페이스를 제공하고 객체 구현자(ICamera)에 대한 참조자를 관리한다
    //카메라에 뭐가 있어야할까 생각해보자
    //카메라는 TurnOnOff가 있고 zoomInOut이 있고 이동하기도 하고 목표를 바라보기도 하고... 등

    //public Camera CameraComponent
    //{
    //    get;
    //    private set;
    //}
    //public AbstractCamera()
    //{
    //    CameraComponent = 
    //}


    public Camera camera;
    public abstract void GetCamera();
    //camera = GetComponent<Camera>();
    //먼저 TurnOnOff를 만들어보자 - 이놈은 공통된거니 여기서 구현해주자
    public void TurnOn()
    {
        camera.enabled = true;
    }
    public void TurnOff()
    {
        camera.enabled = false;
    }

    //ZoomInOut

    //이동은 각 카메라마다 다르니 추상메소드로 지정
    public abstract void MovingCamera();



    //카메라 모듈을 가져와서 리스트에 담아보자
    //List<ICamera> cameraModules = new List<ICamera>();
    //public int CameraModuleCount //카메라에 담긴 모듈수
    //{
    //    get
    //    {
    //        return cameraModules.Count;
    //    }
    //}
    //void AddCameraModule(ICamera cameraModule)
    //{
    //    cameraModules.Add(cameraModule);
    //}
}