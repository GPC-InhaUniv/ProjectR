using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Tiles;
using RedTheSettlers.Players;

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
        Dead = 3,
        Skill_1 = 4,
        Skill_2 = 5,
        Skill_3 = 6,
        Skill_4 = 7
    }
    /// <summary>
    /// 카메라컨트롤러 클래스
    /// 담당자 : 정진영
    /// 테스트용 기본조작
    /// 카메라 스위칭 : x
    /// </summary>
    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        GameCamera BoardGameCamera, BattleGameCamera, ActiveCamera;

        CameraStateType newCameraState;
        CameraStateType cameraState;

        Animator cloudAnimator;

        [SerializeField]
        Vector3 playerVector3;
        Transform playerTransform;
        //float ZoomValue;
        //Vector3 vector3; //배틀 카메라를 사용할때 비어있는 v3를 전달하기위해 선언함

        private void Start()
        {
            cloudAnimator = GameObject.FindWithTag("UICamera").GetComponentInChildren<Animator>();
            BoardGameCamera = GameObject.FindWithTag("BoardCamera").GetComponent<GameCamera>();
            BattleGameCamera = GameObject.FindWithTag("BattleCamera").GetComponent<GameCamera>();
            //playerTransform = GameObject.FindWithTag(GlobalVariables.TAG_PLAYER).transform;
            ActiveCamera = BoardGameCamera;
            cameraState = CameraStateType.Idle;
            //vector3 = new Vector3();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("x");

                if (ActiveCamera == BoardGameCamera)
                {
                    StartCoroutine(SwichingCamera(BattleGameCamera));
                }
                else
                {
                    StartCoroutine(SwichingCamera(BoardGameCamera));
                }
            }
            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    Debug.Log("c");
            //    ZoomInOut(ZoomValue);//ActiveCamera,
            //}

            //새로운 상태가 있으면 바꿔준다
            if (cameraState != newCameraState)
            {
                cameraState = newCameraState;
            }
        }

        /// <summary>
        /// 배틀카메라를 움직일때 사용함
        /// </summary>
        private void FixedUpdate()
        {
            if (ActiveCamera == BattleGameCamera)
            {
                Debug.Log(ActiveCamera + " " + playerVector3);
                if(playerVector3 == Vector3.zero)
                {
                    GetPlayerVector3();
                    return;
                }
                else
                {
                    ActiveCamera.MovingCamera(playerVector3, cameraState);
                    ActiveCamera.Looking(playerVector3);
                }
            }
        }

        /// <summary>
        /// Player에서 카메라의 상태를 변경함
        /// </summary>
        /// <param name="cameraState"></param>
        public void ChangeState(CameraStateType cameraStateType)
        {
            cameraState = cameraStateType;
        }

        /// <summary>
        /// 카메라 피치 줌인아웃
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
            ActiveCamera.MovingCamera(direction, cameraState);
        }

        /// <summary>
        /// 보드타일이 선택되었을때 해당 타일을 바라보며 줌
        /// </summary>
        public void LookingTile(BoardTile boardTile)
        {
            if(ActiveCamera==BoardGameCamera)
                ActiveCamera.Looking(boardTile.gameObject.transform.position);
        }
        //타일선택 해제했을때 뭐로할지 이야기해야함!!!!!!!!!!!

        /// <summary>
        /// 플레이어위치를 찾아옴
        /// </summary>
        private void GetPlayerVector3()
        {
            playerVector3 = GameObject.FindWithTag(GlobalVariables.TAG_PLAYER).transform.position;
        }
        /// <summary>
        /// 배틀/보드 카메라 전환
        /// </summary>
        /// <param name="stateType"></param>
        public void ChangeCamera(StateType stateType)
        {
            switch (stateType)
            {
                case StateType.BattleStageState:
                    SwichingCamera(BattleGameCamera);
                    break;
                case StateType.MainStageState:
                    SwichingCamera(BoardGameCamera);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 카메라 스위칭할때 애니메이션, 싱크
        /// StageManager와 연관
        /// </summary>
        IEnumerator SwichingCamera(GameCamera Camera)
        {
            Debug.Log("SwichingCameraasdsa");
            cloudAnimator.SetTrigger("Closing");

            yield return new WaitForSeconds(cloudAnimator.GetCurrentAnimatorStateInfo(0).length);

            ActiveCamera.TrunOffCamera();
            if (Camera == BoardGameCamera)
            {
                playerVector3 = new Vector3();
                ActiveCamera = BoardGameCamera;
            }
            else
            {
                GetPlayerVector3();
                //targetTransform = playerTransform;
                ActiveCamera = BattleGameCamera;
            }
            ActiveCamera.TrunOnCamera();

            //여기에서 배틀타일이 완성되었는지 판단하고 다음을 진행한다
            while (true)
            {
                if (true)
                {
                    break;
                }
            }
            cloudAnimator.SetTrigger("Opening");
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
