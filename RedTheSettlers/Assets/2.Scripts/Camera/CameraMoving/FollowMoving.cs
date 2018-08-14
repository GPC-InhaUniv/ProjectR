using System;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class FollowMoving : CameraMoving
    {
        ICameraState cameraState;
        public FollowMoving(GameObject cameraObject)
        {
            this.cameraObject = cameraObject;
            cameraState = new CameraNomalState(this.cameraObject);
        }
        //private void Awake()
        //{
        //    cameraObject = gameObject;
        //    cameraState = new CameraShakeState(cameraObject);
        //}

        public override void Moving(Vector3 vector3)
        {
            cameraState.CameraBehavior(vector3);
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
            cameraState = new CameraNomalState(cameraObject);
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
