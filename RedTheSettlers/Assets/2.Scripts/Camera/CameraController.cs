using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject BattleCamera, BoardCamera;
    public bool IsBoard;

    private void Start()
    {
        BattleCamera = GameObject.Find("Battle Camera").GetComponent<GameObject>();
        BoardCamera = GameObject.Find("Board Camera").GetComponent<GameObject>();
    }

    private void Update()
    {
        if (IsBoard)
        {
            ActiveFalse();
            BoardCamera.SetActive(true);
        }
        else
        {
            ActiveFalse();
            BattleCamera.SetActive(true);
        }
    }

    void ActiveFalse()
    {
        BattleCamera.SetActive(false);
        BoardCamera.SetActive(false);
    }
}
