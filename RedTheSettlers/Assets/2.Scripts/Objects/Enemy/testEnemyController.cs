using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// **********************************************
/// enemy 동작 테스트를 위한 테스트옹 소스입니다.
/// **********************************************
/// </summary>
public class testEnemyController : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                Debug.Log("hit point : " + hitInfo.point);
                enemy.destinationPoint = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
                enemy.ChangeStage(EnemyStateType.Move);
            }
        }
    }
}
