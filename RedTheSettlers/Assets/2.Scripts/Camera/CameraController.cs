using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 카메라 컨트롤러가 해야할일
 * 카메라 스위칭
 * 카메라 안에있는 기능을 실행시키기
*/
namespace RedTheSettlers.GameSystem
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        GameCamera BoardGameCamera, BattleGameCamera, ActiveCamera;
        Transform target;

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
                ZoomInOut(ActiveCamera);
            }
            //피치줌인아웃 들어갈자리(현재 DragZoom : CameraZoomInOut 안에 있음
        }
        private void FixedUpdate()
        {
            ActiveCamera.MovingCamera();
            ActiveCamera.Looking(target);
        }

        private void ZoomInOut(GameCamera activeCamera)
        {
            activeCamera.ZoomInOutCamera();
        }

        void SwichingCamera(GameCamera activeCamera)
        {
            ActiveCamera.TrunOffCamera();
            if (activeCamera == BoardGameCamera)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
                ActiveCamera = BattleGameCamera;
            }
            else
            {
                target = null;
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
}
