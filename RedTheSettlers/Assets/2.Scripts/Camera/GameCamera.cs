using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField]
    AbstractCamera abstractCamera = null;
    //BoardCamera boardCamera;
    string cameraName;
    private void Start()
    {
        cameraName = gameObject.name;
        if(cameraName == "Board Camera")
        {
            abstractCamera = gameObject.AddComponent<BoardCamera>();
        }
        else
        {
            abstractCamera = gameObject.AddComponent<BattleCamera>();
        }
        
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
    public void ZoomInCamera()
    {
        abstractCamera.ZoomIn();
    }
    public void ZoomOutCamera()
    {
        abstractCamera.ZoomOut();
    }
    


}