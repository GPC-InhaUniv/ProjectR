using System;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class FollowMoving : CameraMoving
    {
        ICameraState CameraState;

        private void Awake()
        {
            cameraObject = gameObject;
            CameraState = new CameraNomalState(cameraObject);
        }

        public override void Moving()
        {
            CameraState.CameraBehavior();
        }

        private void StateTest()
        {
            StartCoroutine(SetShakeState());
        }
        public void SetState(ICameraState state)
        {
            this.CameraState = state;
        }
        private IEnumerator SetShakeState()
        {
            CameraState = new CameraShakeState();
            yield return new WaitForSeconds(1f);
            CameraState = new CameraNomalState(cameraObject);
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

    }
    
}
