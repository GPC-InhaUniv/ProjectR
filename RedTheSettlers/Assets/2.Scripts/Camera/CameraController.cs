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
        float value;
        Vector3 vector3; //카메라 이동할때 사용하는 백터(보드는 드래그용, 배틀은 )
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
                ZoomInOut(value);//ActiveCamera,
            }
            //피치줌인아웃 들어갈자리(현재 DragZoom : CameraZoomInOut 안에 있음

            //GameManager에게 현재 상태를 받아와서 카메라를 스위치 해준다(미구현)
        }

        private void FixedUpdate()
        {
            if(ActiveCamera == BattleGameCamera)
            {
                ActiveCamera.MovingCamera(vector3);
            }
            //ActiveCamera.MovingCamera(vector3);
            //ActiveCamera.Looking(target);
        }

        public void ZoomInOut(float value)//GameCamera activeCamera, 
        {
            ActiveCamera.ZoomInOutCamera(value);
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



        public void CameraMoving(Vector3 direction)
        {
            Debug.Log("카메라컨트롤러 카메라 무빙!");
            ActiveCamera.MovingCamera(direction);
            //camera.transform.Translate(new Vector3(direction.x, 0, direction.y), Space.World);
        }
        //드레그카메라에 들어가는 vector3을 계산하는 조건
        //    //Debug.Log("보드카메라 무빙카메라()");
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            dragOrigin = Input.mousePosition;
        //            return;
        //        }
        //        if (!Input.GetMouseButton(0)) return;
        //        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
        //Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);



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
