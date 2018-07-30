using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 카메라 컨트롤러가 해야할일
 * 카메라 스위칭
 * 카메라 안에있는 기능을 실행시키기
*/
public class CameraController : MonoBehaviour {
    
    public Camera BattleCamera, BoardCamera, ActiveCamera;
    public bool IsZoom = false;
    public float ZoomSpeed = 15f;
    private void Start()
    {
        BoardCamera = GameObject.Find("Board Camera").GetComponent<Camera>();
        BattleCamera = GameObject.Find("Battle Camera").GetComponent<Camera>();
        
        BoardCamera.enabled = false;
        BattleCamera.enabled = false;
        InitializeingCamera();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(CameraTransition());
        }
        if (IsZoom==true)
        {
            BoardCamera br = ActiveCamera.GetComponent<BoardCamera>();
            br.ZoomInOut(IsZoom);
        }
    }

    void InitializeingCamera()
    {
        ActiveCamera = BoardCamera;
        ActiveCamera.enabled = true;
    }

    void SwichingCamera(Camera camera)
    {
        Debug.Log("스위칭카메라");
        ActiveCamera.enabled = false;
        if (camera != BoardCamera)
        {
            ActiveCamera = BoardCamera;
            ActiveCamera.enabled = true;
        }
        else
        {
            ActiveCamera = BattleCamera;
            ActiveCamera.enabled = true;
        }
    }
    
    IEnumerator CameraTransition()
    {
        Debug.Log("코루틴");
        //while (true)
        //{
        //    if (BoardCamera.fieldOfView > 1)
        //    {
        //        BoardCamera.fieldOfView -= ZoomSpeed;
        //        yield return new WaitForSeconds(0.06f);
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        //yield return new WaitForSeconds(1f);
        SwichingCamera(ActiveCamera);
        Debug.Log("애니메이션끝");
        yield return new WaitForSeconds(1f);
    }



}
