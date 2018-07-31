using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryGameManager : Singleton<TemporaryGameManager>
{
    TemporaryGameManager temporaryGameManager;
    Transform transformCamera;

    private void Awake()
    {
        temporaryGameManager = this;
        transformCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }
    private void Start()
    {
        
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
}