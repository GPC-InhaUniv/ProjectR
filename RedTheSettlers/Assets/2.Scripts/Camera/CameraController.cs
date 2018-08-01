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
    public GameObject BoardCameraObj;
    public BoardCamera boardCamera;
    private void Start()
    {
        BoardCameraObj = GameObject.Find("Board Camera");
        boardCamera = gameObject.GetComponent<BoardCamera>();


        GameCamera gameCamera = BoardCameraObj.GetComponent<GameCamera>();

        TestBoardCamera(gameCamera);

        //BoardCameraObj.AddComponent<GameCamera>();
    }

    private void TestBoardCamera(GameCamera gameCamera)
    {
        AbstractCamera abstractCamera = boardCamera;
        //Debug.Log(new BoardCamera());
        Debug.Log("테스트보드카메라" + abstractCamera);
        gameCamera.PutInCamera(abstractCamera);
        Debug.Log("테스트보드카메라"+gameCamera);
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

    //void SwichingCamera(Camera camera)
    //{
    //    Debug.Log("스위칭카메라");
    //    ActiveCamera.enabled = false;
    //    if (camera != BoardCamera)
    //    {
    //        ActiveCamera = BoardCamera;
    //        ActiveCamera.enabled = true;
    //    }
    //    else
    //    {
    //        ActiveCamera = BattleCamera;
    //        ActiveCamera.enabled = true;
    //    }
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
