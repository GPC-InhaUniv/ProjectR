using RedTheSettlers.GameSystem;
using UnityEngine;

public class TemporaryGameManager : Singleton<TemporaryGameManager>
{
    //private Transform transformCamera;
    private Camera camera;
    private TemporaryCameraController tempCameraController;
    //private new Transform Player;
    private new Rigidbody Player;
    //public Vector3 moveDirection;

    private void Awake()
    {
        //transformCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        //camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        tempCameraController = GameObject.FindObjectOfType<TemporaryCameraController>();
        //Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //Player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
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
        //transformCamera.transform.Translate(new Vector3(direction.x,0,direction.y),Space.World);
        //camera.transform.Translate(new Vector3(direction.x, 0, direction.y), Space.World);
        tempCameraController.CameraMove(direction);
        //LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "이동 좌표 : " + direction);
    }

    public void CameraZoom(float value)
    {
        //transformCamera.transform.Translate(new Vector3(0, value, 0),Space.World);
        //camera.fieldOfView += value;
        tempCameraController.CameraZoom(value);
    }

    public void UserTrade(Vector3 position)
    {
        TemporaryTradeManager.Instance.Trade(position);
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "트레이드");
    }

    public void PlayerMove(Vector3 direction)
    {
        //Player.MovePosition(Player.position + (direction * 10) * Time.deltaTime);
    }
}