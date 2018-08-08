using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    
    AbstractCamera abstractCamera;
    string cameraName;
    private void Awake()
    {
        cameraName = gameObject.name;
        if(cameraName == "Board Camera")
        {
            abstractCamera = new BoardCamera(gameObject);
        }
        else
        {
            abstractCamera = new BattleCamera(gameObject);
        }
        abstractCamera.camera = gameObject.GetComponent<Camera>();
    }
    

    public void TrunOnCamera()
    {
        abstractCamera.TurnOn();
    }
    public void TrunOffCamera()
    {
        abstractCamera.TurnOff();
    }
    public void MovingCamera()
    {
        abstractCamera.MovingCamera();
    }
    public void ZoomInOutCamera()
    {
        abstractCamera.ZoomInOutCamera();
    }
    public void Looking(Transform target)
    {
        abstractCamera.LookAt(target);
    }
    


}