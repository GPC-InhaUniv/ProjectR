using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using UnityEngine;

/// <summary>
/// 담당자 박상원
/// State 패턴 구현부
/// Board Game 부분 버튼 기능 및 카메라 이동
/// </summary>
public class MainStageState : InputState
{
    private Vector3 firstClick;
    private Vector3 dragPosition;
    private Vector3 dragDirection;
    private GameObject tileInformation;
    private float cameraZoom;
    private const int reversValue = -1;

    public override void TouchOrClickButton(InputButtonType inputButtonType)
    {
        switch (inputButtonType)
        {
            case InputButtonType.Battle:
                break;
            case InputButtonType.Trade:
                break;
            case InputButtonType.TurnEnd:
                break;
            case InputButtonType.Status:
                break;
            case InputButtonType.Map:
                break;
            case InputButtonType.EquipAndSkill:
                break;
        }
    }
    public override void DragMove(float speed)
    {
        //TemporaryGameManager.Instance.CameraMove();
        //LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "넘어왔나");

        if (Input.GetMouseButtonDown(0))
        {
            /*Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                firstClick = new Vector3(rayPoint.origin.x, rayPoint.origin.y ,rayPoint.origin.z);
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "클릭 위치 : " + firstClick);
            }*/
            firstClick = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            /*Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                dragPosition = new Vector3(rayPoint.origin.x, rayPoint.origin.y, rayPoint.origin.z);
                dragDirection = (dragPosition - firstClick).normalized * Speed * Time.deltaTime;
                //GameManager.Instance.CameraMove(dragDirection);
                //TemporaryGameManager.Instance.CameraMove(dragDirection);
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "좌표 : " + dragPosition);
            }*/
            dragPosition = Input.mousePosition;
            dragDirection = (((dragPosition - firstClick).normalized * speed) * reversValue) * Time.deltaTime;
            TemporaryGameManager.Instance.CameraMove(dragDirection);
        }
        else if (!Input.GetMouseButton(0))
        {
            dragPosition = Vector3.zero;
            firstClick = Vector3.zero;
            dragDirection = (dragPosition - firstClick).normalized;
        }
    }
    public override void ZoomInOut(float speed)
    {
        if(Input.GetAxis("Mouse ScrollWheel") * reversValue < 0)
        {
            cameraZoom = (Input.GetAxis("Mouse ScrollWheel") * speed) * reversValue;
            TemporaryGameManager.Instance.CameraZoom(cameraZoom);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") * reversValue > 0)
        {
            cameraZoom = (Input.GetAxis("Mouse ScrollWheel") * speed) * reversValue;
            TemporaryGameManager.Instance.CameraZoom(cameraZoom);
        }
    }
    public override void TileInfo()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if(Physics.Raycast(rayPoint,out hitPoint,Mathf.Infinity))
            {
                if(hitPoint.collider.tag == "Tile")
                {
                    hitPoint.collider.gameObject.GetComponent<BoardTile>().tileType.GetType();
                    TemporaryGameManager.Instance.TileInfo(hitPoint.collider.gameObject.GetComponent<BoardTile>().tileType);
                }
            }
        }
    }
}
