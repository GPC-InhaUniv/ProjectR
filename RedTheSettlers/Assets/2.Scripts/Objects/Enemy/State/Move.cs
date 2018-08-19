using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class Move : EnemyState
    {
        const float speedCorrection = 50f;

        public Move(
            Animator animator,
            Transform transform,
            Rigidbody rigidbodyComponent, 
            Vector3 destinationPoint, 
            Vector3 currentPoint, 
            float moveSpeed,
            Tile currentTile
            )
        {
            this.animator = animator;
            this.transform.rotation = transform.rotation;
            this.rigidbodyComponent.velocity = rigidbodyComponent.velocity;
            this.destinationPoint = destinationPoint;
            this.currentPoint = currentPoint;
            this.moveSpeed = moveSpeed;
            this.currentTile = currentTile;
        }

        //ai에서 길찾기 시작 할때 수직 아래 방향으로 레이를 쏴서 현재 위치한 좌표의 타일을 얻어와서 currentTile에 저장
        public override void DoAction()
        {
            animator.SetFloat("Speed", Vector3.Distance(destinationPoint, currentPoint));
            Vector3 normalVector = (destinationPoint - currentPoint).normalized;
            transform.rotation = Quaternion.LookRotation(normalVector);
            rigidbodyComponent.velocity = normalVector * GameTimeManager.Instance.DeltaTime * moveSpeed * speedCorrection;
        }
    }
}