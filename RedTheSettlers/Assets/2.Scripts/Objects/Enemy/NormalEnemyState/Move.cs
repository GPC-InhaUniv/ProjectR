using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys.Normal
{
    public class Move : EnemyState
    {
        const float speedCorrection = 50f;

        public Move(Animator ContextAnimator, Quaternion ContextRoration, Vector3 ContextVelocity, Vector3 ContextDestinationPoint, Vector3 ContextCurrentPoint, float ContextMoveSpeed)
        {
            animator = ContextAnimator;
            rotation = ContextRoration;
            velocity = ContextVelocity;
            destinationPoint = ContextDestinationPoint;
            currentPoint = ContextCurrentPoint;
            moveSpeed = ContextMoveSpeed;
        }

        //ai에서 길찾기 시작 할때 수직 아래 방향으로 레이를 쏴서 현재 위치한 좌표의 타일을 얻어와서 currentTile에 저장
        public override void DoAction()
        {
            animator.SetFloat("Speed", Vector3.Distance(destinationPoint, currentPoint));
            Vector3 normalVector = (destinationPoint - currentPoint).normalized;
            rotation = Quaternion.LookRotation(normalVector);
            velocity = normalVector * GameTimeManager.Instance.DeltaTime * moveSpeed * speedCorrection;
        }
    }
}