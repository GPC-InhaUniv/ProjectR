using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera BattleCamera, BoardCamera;
    public bool IsBoard = false;
    public float ZoomSpeed = 15f;
    private void Start()
    {
        BattleCamera = GameObject.Find("Battle Camera").GetComponent<Camera>();
        BoardCamera = GameObject.Find("Board Camera").GetComponent<Camera>();
        
    }

    private void Update()
    {
        //swichingCamera(IsBoard);
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(CameraTransition());
        }


        //if (IsBoard)
        //{
        //    swichingCamera();
        //    //BoardCamera.enabled = true;
        //}
        //else
        //{

        //    //BattleCamera.enabled = true;
        //}
    }

    void swichingCamera(bool isBoard)
    {
        Debug.Log("스위칭카메라");
        BoardCamera.enabled = isBoard;
        BattleCamera.enabled = !isBoard;
        //BattleCamera.enabled = false;
        //BoardCamera.enabled = false;
    }
    
    IEnumerator CameraTransition()
    {
        Debug.Log("코루틴");
        while (true)
        {
            if (BoardCamera.fieldOfView > 1)
            {
                BoardCamera.fieldOfView -= ZoomSpeed;
                yield return new WaitForSeconds(0.06f);
            }
            else
            {
                break;
            }
        }
        //yield return new WaitForSeconds(1f);
        swichingCamera(IsBoard);
        Debug.Log("애니메이션끝");
        yield return new WaitForSeconds(1f);
    }



}
