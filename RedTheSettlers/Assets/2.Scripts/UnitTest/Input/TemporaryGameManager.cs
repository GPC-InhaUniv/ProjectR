using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using UnityEngine;

public class TemporaryGameManager : Singleton<TemporaryGameManager>
{
    private TemporaryCameraController tempCameraController;
    private CameraController cameraCtrl;
    private new Rigidbody Player;

    private void Awake()
    {
        tempCameraController = GameObject.FindObjectOfType<TemporaryCameraController>();
        cameraCtrl = GameObject.FindObjectOfType<CameraController>();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

    }

    /*private void FixedUpdate()
    {
        PlayerMove(moveDirection);
    }*/

    public void CameraMove(Vector3 direction)
    {
        cameraCtrl.CameraDragMoving(direction);
    }

    public void CameraZoom(float value)
    {
        cameraCtrl.ZoomInOut(value);
    }

    public void PlayerMove(Vector3 direction)
    {
        //Player.MovePosition(Player.position + (direction * 10) * Time.deltaTime);
    }

    public void TileInfo(BoardTile tileType)
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "타일 정보 : " + tileType);
    }
}