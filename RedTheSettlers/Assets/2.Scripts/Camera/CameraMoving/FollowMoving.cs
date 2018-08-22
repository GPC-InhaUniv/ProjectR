using System;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class FollowMoving : CameraMoving
    {
        Transform targetTransform;
        Vector3 cameraOffset;
        
        [SerializeField]
        [Range(0.01f, 1.0f)]
        float smooth = 0.1f;

        ICameraState cameraState;

        public FollowMoving(GameObject cameraObject)
        {
            this.cameraObject = cameraObject;
            FindTarget();
            cameraOffset = cameraObject.transform.position - targetTransform.position;


            cameraState = new CameraNomalState();
        }

        public override void Moving(Vector3 vector3)
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
            cameraState.CameraBehavior(vector3);
        }
        

        private void FindTarget()
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }





        private void StateTest()
        {
            //StartCoroutine(SetShakeState());
        }
        public void SetState(ICameraState state)
        {
            this.cameraState = state;
        }
        private IEnumerator SetShakeState()
        {
            cameraState = new CameraShakeState(cameraObject);
            yield return new WaitForSeconds(1f);
            cameraState = new CameraNomalState();
        }
        //StartCoroutine(MobileAttack());
        //IEnumerator MobileAttack()
        //{
        //    yield return 1f;

        //    while (playerStatusComponent.PlayerHp > 0)
        //    {
        //        bulletObjectPool.SetPlayerBulletOfPositionAndActive(bulletSpawn);
        //        yield return new WaitForSeconds(0.4f);
        //    }
        //}


        //int radius = 5;
        //double result = CalculateArea(radius);
    }
    
}
