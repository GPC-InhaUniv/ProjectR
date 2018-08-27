using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using UnityEngine;

public class TemporaryGameManager : Singleton<TemporaryGameManager>
{
    private TemporaryCameraController tempCameraController;
    private CameraController cameraCtrl;
    private new Rigidbody rigidbody;
    private Transform player;
    private Vector3 moveDirection;
    private float playerRotation;
    private float moveSpeed;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        tempCameraController = GameObject.FindObjectOfType<TemporaryCameraController>();
        cameraCtrl = GameObject.FindObjectOfType<CameraController>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMove(moveDirection, playerRotation, moveSpeed);
    }

    public void CameraMove(Vector3 direction)
    {
        cameraCtrl.CameraDragMoving(direction);
    }

    public void CameraZoom(float value)
    {
        cameraCtrl.ZoomInOut(value);
    }

    public void PlayerMove(Vector3 direction, float rotation, float speed)
    {
        moveDirection = direction;
        playerRotation = rotation;
        moveSpeed = speed;
        //Player.MovePosition(Player.position + (direction * 10) * Time.deltaTime);
        rigidbody.rotation = Quaternion.Euler(0f, rotation, 0f);
        rigidbody.velocity = (direction * speed) * Time.deltaTime;
    }

    public void PlayerRotate(float rotation)
    {

    }

    public void TileInfo(BoardTile tileType)
    {
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "타일 정보 : " + tileType);
    }
}