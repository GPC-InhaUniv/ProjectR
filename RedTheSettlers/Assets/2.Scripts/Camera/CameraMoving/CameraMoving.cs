using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public abstract class CameraMoving
    {
        public GameObject cameraObject;
        public abstract void Moving(Vector3 vector3, CameraStateType cameraState);
    }


    public class DragMoving : CameraMoving
    {
        public DragMoving(GameObject cameraObject)
        {
            this.cameraObject = cameraObject;
        }

        public override void Moving(Vector3 vector3, CameraStateType cameraState)
        {
            cameraObject.transform.Translate(new Vector3(vector3.x, 0, vector3.y), Space.World);
        }
    }



    public class FollowMoving : CameraMoving
    {
        Transform targetTransform;
        Vector3 cameraOffset;
        float smooth = 0.2f;


        Animator animator;
        ICameraState currentState;
        CameraStateType nowStateType;

        public FollowMoving(GameObject cameraObject)
        {
            animator = cameraObject.GetComponentInChildren<Animator>();
            this.cameraObject = cameraObject;
            FindTarget();
            cameraOffset = cameraObject.transform.position - targetTransform.position;


            currentState = new CameraNomalState(animator);
        }

        public override void Moving(Vector3 vector3, CameraStateType cameraState)
        {
            if (nowStateType != cameraState)
            {
                ChangeState(cameraState);
                currentState.CameraBehavior();
            }
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

        private void ChangeState(CameraStateType cameraState)
        {
            //ChangeState((EnemyStateType)stateType);
            switch (cameraState)
            {
                case CameraStateType.Idle:
                    currentState = new CameraNomalState(animator);
                    break;
                case CameraStateType.Damage:
                    currentState = new CameraShakeState(animator);
                    break;
                case CameraStateType.Skill_1:
                    currentState = new CameraSkillActionState(animator);
                    break;
                case CameraStateType.Skill_2:
                    currentState = new CameraSkillActionState(animator);
                    break;

                default:
                    break;
            }
        }
        
        private void FindTarget()
        {
            targetTransform = GameObject.FindGameObjectWithTag(GlobalVariables.TAG_PLAYER).transform;
        }

    }
}