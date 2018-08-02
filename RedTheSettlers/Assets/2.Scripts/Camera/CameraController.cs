using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 카메라 컨트롤러가 해야할일
 * 카메라 스위칭
 * 카메라 안에있는 기능을 실행시키기
*/
public class CameraController : MonoBehaviour {
    
    [SerializeField]
    GameCamera BoardGameCamera, BattleGameCamera, ActiveCamera;
    
    private void Start()
    {
        BoardGameCamera = GameObject.Find("Board Camera").GetComponent<GameCamera>();
        BattleGameCamera = GameObject.Find("Battle Camera").GetComponent<GameCamera>();
        ActiveCamera = BoardGameCamera;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("x");
            SwichingCamera(ActiveCamera);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("c");
            ZoomIn(ActiveCamera);
        }

    }
    private void FixedUpdate()
    {
        ActiveCamera.MovingCamera();
    }

    private void ZoomIn(GameCamera activeCamera)
    {
        activeCamera.ZoomInCamera();
    }

    void SwichingCamera(GameCamera Camera)
    {
        ActiveCamera.TrunOffCamera();
        if(Camera == BoardGameCamera)
        {
            ActiveCamera = BattleGameCamera;
        }
        else
        {
            ActiveCamera = BoardGameCamera;
        }
        ActiveCamera.TrunOnCamera();
    }



    //public Camera BattleCamera, BoardCamera, ActiveCamera;
    //GameCamera gameCamera;
    //public bool IsZoom = false;
    //public float ZoomSpeed = 15f;
    //private void Start()
    //{
    //    gameCamera = new GameCamera();
    //    BoardCameraTest(gameCamera);

    //    BoardCamera = GameObject.Find("Board Camera").GetComponent<Camera>();
    //    BattleCamera = GameObject.Find("Battle Camera").GetComponent<Camera>();

    //    //BoardCamera.enabled = false;
    //    //BattleCamera.enabled = false;
    //    //InitializeingCamera();
    //}
    //void BoardCameraTest(GameCamera gameCamera)
    //{

    //    //ICamera module = new ~();
    //    AbstractCamera abstractCamera = new BoardCamera();
    //    //abstractCamera.addModule(module);
    //    //gameCamera.putInCamera(abstractCamera);
    //    BoardCamera = abstractCamera.camera;

    //}

    //private void Update()
    //{

    //    //if (Input.GetKeyDown(KeyCode.X))
    //    //{
    //    //    StartCoroutine(CameraTransition());
    //    //}
    //    //if (IsZoom==true)
    //    //{
    //    //    BoardCamera br = ActiveCamera.GetComponent<BoardCamera>();
    //    //    br.ZoomInOut(IsZoom);
    //    //}
    //}

    //void InitializeingCamera()
    //{
    //    ActiveCamera = BoardCamera;
    //    ActiveCamera.enabled = true;
    //}



    //IEnumerator CameraTransition()
    //{
    //    Debug.Log("코루틴");
    //    //while (true)
    //    //{
    //    //    if (BoardCamera.fieldOfView > 1)
    //    //    {
    //    //        BoardCamera.fieldOfView -= ZoomSpeed;
    //    //        yield return new WaitForSeconds(0.06f);
    //    //    }
    //    //    else
    //    //    {
    //    //        break;
    //    //    }
    //    //}
    //    //yield return new WaitForSeconds(1f);
    //    SwichingCamera(ActiveCamera);
    //    Debug.Log("애니메이션끝");
    //    yield return new WaitForSeconds(1f);
    //}



}
