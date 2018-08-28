using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public abstract class CameraAngle
    {
        public GameObject cameraObject;
        public abstract void Looking(Transform target);
    }

    public class LookAtManual : CameraAngle
    {
        public LookAtManual(GameObject gameObject)
        {
            cameraObject = gameObject;
        }
        public override void Looking(Transform target)
        {
            //보드에서 타겟이 있으면 그쪽을 보면서 이동까지 해줘야함
            Debug.Log("룩엣메뉴얼");
            return;
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
