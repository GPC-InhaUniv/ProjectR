using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RedTheSettlers.Tiles;


namespace RedTheSettlers.GameSystem
{
    public abstract class CameraAngle
    {
        public GameObject cameraObject;
        public abstract void Looking(Transform target);
    }

    public class LookAtManual : CameraAngle
    {
        bool isWark = false;
        Transform originalTransform;
        Transform tileCenter;
        float smooth = 0.2f;
        Vector3 cameraOffset;

        public LookAtManual(GameObject gameObject)
        {
            cameraObject = gameObject;
            originalTransform = cameraObject.transform;
            tileCenter = TileManager.Instance.BoardTileGrid[GlobalVariables.BoardTileGridSize / 2, GlobalVariables.BoardTileGridSize / 2].transform;
            cameraOffset = cameraObject.transform.position - tileCenter.position;
        }
        public override void Looking(Transform target)
        {
            //보드에서 타겟이 있으면 그쪽을 보면서 이동까지 해줘야함
            Debug.Log("룩엣메뉴얼");
            if(isWark == false)
            {
                Vector3 newPos = target.position + cameraOffset;
                cameraObject.transform.position = Vector3.Slerp(cameraObject.transform.position, newPos, smooth);
                isWark = true;
            }
            else
            {
                cameraObject.transform.position = Vector3.Slerp(cameraObject.transform.position, originalTransform.position, smooth);
                isWark = false;
            }
        }
    }

    public class LookAtTarget : CameraAngle
    {
        public LookAtTarget(GameObject gameObject)
        {
            cameraObject = gameObject;
        }
        public override void Looking(Transform target)
        {
            if (target == null)
            {
                return;
            }
            if (target != null)
            {
                cameraObject.transform.LookAt(target);
            }
        }
    }
}
