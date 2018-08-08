using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FollowMoving : CameraMoving
{
    Transform targetTransform;
    Vector3 cameraOffset;
    [SerializeField]
    [Range(0.01f, 1.0f)]
    float smooth = 0.1f;

    private void Awake()
    {
        cameraObject = gameObject;
        FindTarget();
        cameraOffset = cameraObject.transform.position - targetTransform.position;
    }

    public override void Moving()
    {
        if (targetTransform == null)
        {
            Debug.Log("타겟이 없어서 타겟을 찾는다");
            FindTarget();
        }
        else
        {
            Vector3 newPos = targetTransform.position + cameraOffset;
            cameraObject.transform.position = Vector3.Slerp(cameraObject.transform.position, newPos, smooth);
        }
    }
    public void FindTarget()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
