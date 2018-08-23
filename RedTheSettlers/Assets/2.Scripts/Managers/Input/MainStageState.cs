using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using UnityEngine;

/// <summary>
/// 담당자 박상원
/// State 패턴 구현부
/// Board Game 부분 버튼 기능 및 카메라 이동
/// </summary>
public class MainStageState : IInputState
{
    private Vector3 firstClick;
    private Vector3 dragPosition;
    private Vector3 dragDirection;
    private BoardTile tileInformation;
    private float cameraZoom;
    private float touchDistance;
    private float firstDistance;
    private float currentDistance;
    private const int reversValue = -1;
    private const int touchMaxCount = 2;

    /*public void TouchOrClickButton(InputButtonType inputButtonType)
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
    }*/
    public void OnStartDrag()
    {
        firstClick = Input.mousePosition;
    }
    public void OnDragging(float speed)
    {
        dragPosition = Input.mousePosition;
        dragDirection = (((dragPosition - firstClick).normalized * speed) * reversValue) * Time.deltaTime;
        TemporaryGameManager.Instance.CameraMove(dragDirection);
    }
    public void EndStopDrag()
    {
        dragPosition = Vector3.zero;
        firstClick = Vector3.zero;
        dragDirection = Vector3.zero;
    }
    public void ZoomInOut(float speed)
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetAxis("Mouse ScrollWheel") * reversValue < 0)
        {
            cameraZoom = (Input.GetAxis("Mouse ScrollWheel") * speed) * reversValue;
            TemporaryGameManager.Instance.CameraZoom(cameraZoom);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") * reversValue > 0)
        {
            cameraZoom = (Input.GetAxis("Mouse ScrollWheel") * speed) * reversValue;
            TemporaryGameManager.Instance.CameraZoom(cameraZoom);
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount == touchMaxCount)
        {
            Touch firstTouchPoint = Input.GetTouch(0);
            Touch secondTouchPoint = Input.GetTouch(1);

            Vector2 firstTouchPrevPoint = firstTouchPoint.position - firstTouchPoint.deltaPosition;
            Vector2 secondTouchPrevPoint = secondTouchPoint.position - secondTouchPoint.deltaPosition;

            float prevTouchDeltaPoint = (firstTouchPrevPoint - secondTouchPrevPoint).magnitude;
            float currentTouchDeltaPoint = (firstTouchPoint.position - secondTouchPoint.position).magnitude;

            float deltaMagnitude = prevTouchDeltaPoint - currentTouchDeltaPoint;
            TemporaryGameManager.Instance.CameraZoom(deltaMagnitude);
        }
#endif
    }
    public void TileInfo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(rayPoint, out hitPoint, Mathf.Infinity))
            {
                if (hitPoint.collider.tag == "Tile")
                {
                    tileInformation = hitPoint.collider.gameObject.GetComponent<BoardTile>();
                    LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "타일 정보 : " + tileInformation);
                    TemporaryGameManager.Instance.TileInfo(tileInformation);
                }
            }
        }
    }

    public void DragMove(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void SkillDirection()
    {
        throw new System.NotImplementedException();
    }

    public void OnDropSlot()
    {
        throw new System.NotImplementedException();
    }

    public void OnInPointer()
    {
        throw new System.NotImplementedException();
    }

    public void OnOutPointer()
    {
        throw new System.NotImplementedException();
    }

    public void DirectionKey(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void BattleAttack()
    {
        throw new System.NotImplementedException();
    }
}
