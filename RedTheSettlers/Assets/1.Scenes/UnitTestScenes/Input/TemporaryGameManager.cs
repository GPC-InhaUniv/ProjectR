using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryGameManager : Singleton<TemporaryGameManager>
{
    private static TemporaryGameManager temporaryGameManager;
    private Transform transformCamera;
    //private new Transform Player;
    private new Rigidbody Player;
    public Vector3 moveDirection;

    private void Awake()
    {
        temporaryGameManager = this;
        transformCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        //Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        PlayerMove(moveDirection);
    }

    public void CameraMove(Vector3 direction)
    {
        transformCamera.transform.Translate(new Vector3(direction.x, direction.y));
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "여기까지 왔는가");
    }

    public void UserTrade(Vector3 position)
    {
        TemporaryTradeManager.Instance.Trade(position);
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "트레이드");
    }

    public void PlayerMove(Vector3 direction)
    {
        //Player.transform.Translate(direction * 10 * Time.deltaTime);
        Player.velocity = direction * 50 * Time.deltaTime;
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "움직이고 있는가? " + moveDirection);
    }
}