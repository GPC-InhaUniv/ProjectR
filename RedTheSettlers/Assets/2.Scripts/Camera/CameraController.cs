using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;

/*
 * 카메라 컨트롤러가 해야할일
 * 카메라 스위칭
 * 카메라 안에있는 기능을 실행시키기
*/
namespace RedTheSettlers.GameSystem
{
    public enum CameraStateType
    {
        Idle = 0,
        Damage = 1,
        Skill_1 = 3,
        Skill_2 = 4
    }
    /// <summary>
    /// 카메라컨트롤러 클래스
    /// 담당자 : 정진영
    /// 테스트용 기본조작
    /// 카메라 스위칭 : x
    /// 
    /// </summary>
    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        GameCamera BoardGameCamera, BattleGameCamera, ActiveCamera;
        Transform targetTransform;
        CameraStateType cameraState;
        CameraStateType nowCameraState;

        Animator cloudAnimator;

        [SerializeField]
        Transform playerTransform;
        float ZoomValue;
        Vector3 vector3; //배틀 카메라를 사용할때 비어있는 v3를 전달하기위해 선언함

        private void Start()
        {
            cloudAnimator = GameObject.FindWithTag("UICamera").GetComponentInChildren<Animator>();
            BoardGameCamera = GameObject.FindWithTag("BoardCamera").GetComponent<GameCamera>();
            BattleGameCamera = GameObject.FindWithTag("BattleCamera").GetComponent<GameCamera>();
            playerTransform = GameObject.FindWithTag(GlobalVariables.TAG_PLAYER).transform;
            ActiveCamera = BoardGameCamera;
            nowCameraState = CameraStateType.Idle;
            vector3 = new Vector3();
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
                ZoomInOut(ZoomValue);//ActiveCamera,
            }

            //플레이어의 상태를 받아 카메라상태를 변경한다(임시)
            //if(nowCameraState != cameraState)
            //{
            //    ChangeState(cameraState);
            //}

            

            //GameManager에게 현재 상태를 받아와서 카메라를 스위치 해준다(미구현)
        }


        //플레이어상태변환 (임시로 만들어놓음)
        private void ChangeState(CameraStateType cameraState)
        {
            nowCameraState = cameraState;
        }

        /// <summary>
        /// 배틀카메라를 움직일때 사용함
        /// </summary>
        private void FixedUpdate()
        {
            if(ActiveCamera == BattleGameCamera)
            {
                Debug.Log(ActiveCamera);
                ActiveCamera.MovingCamera(vector3, nowCameraState);
            }
        }




        /// <summary>
        /// 카메라 스위칭할때 애니메이션, 싱크
        /// StageManager와 연관
        /// </summary>
        public void ZoomInOut(float ZoomValue)
        {
            if(ActiveCamera == BoardGameCamera)
                ActiveCamera.ZoomInOutCamera(ZoomValue);
        }

        /// <summary>
        /// 보드에서 드레그로 화면을 움직인다
        /// InputManager에서 호출하게됨
        /// </summary>
        public void CameraDragMoving(Vector3 direction)
        {
            ActiveCamera.MovingCamera(direction, nowCameraState);
        }

        /// <summary>
        /// 보드타일이 선택되었을때 해당 타일을 바라보며 줌
        /// </summary>
        public void LookingTile(BoardTile boardTile)
        {
            if(ActiveCamera==BoardGameCamera)
                ActiveCamera.Looking(boardTile.gameObject.transform);
        }


        /// <summary>
        /// (임시)카메라 스위칭할때 사용함
        /// 코루틴으로 변경해야함
        /// </summary>
        void SwichingCamera(GameCamera activeCamera)
        {
            cloudAnimator.SetTrigger("Closing");
            ActiveCamera.TrunOffCamera();
            if (activeCamera == BoardGameCamera)
            {
                targetTransform = playerTransform.transform;
                ActiveCamera = BattleGameCamera;
            }
            else
            {
                targetTransform = null;
                ActiveCamera = BoardGameCamera;
            }
            cloudAnimator.SetTrigger("Opening");
            ActiveCamera.TrunOnCamera();
            cloudAnimator.SetTrigger("Idle");
        }

        /// <summary>
        /// 카메라 스위칭할때 애니메이션, 싱크
        /// StageManager와 연관
        /// </summary>
        IEnumerator SwichingCameraasdsa(GameCamera activeCamera)//미완성
        {
            cloudAnimator.SetTrigger("Closing");
            //yield return wait
            ActiveCamera.TrunOffCamera();
            if (activeCamera == BoardGameCamera)
            {
                targetTransform = playerTransform.transform;
                ActiveCamera = BattleGameCamera;
            }
            else
            {
                targetTransform = null;
                ActiveCamera = BoardGameCamera;
            }
            cloudAnimator.SetTrigger("Opening");
            ActiveCamera.TrunOnCamera();
            cloudAnimator.SetTrigger("Idle");

            yield return null;
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
