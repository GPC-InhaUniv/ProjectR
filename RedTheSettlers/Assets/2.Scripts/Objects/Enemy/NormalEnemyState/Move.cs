using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class Move : EnemyState
    {
        const float speedCorrection = 50f;

        public Move(NormalEnemy enemy)
        {
            this.enemy = enemy;
        }

        //ai에서 길찾기 시작 할때 수직 아래 방향으로 레이를 쏴서 현재 위치한 좌표의 타일을 얻어와서 currentTile에 저장
        public override void DoAction()
        {
            enemy.anim.SetFloat("Speed", Vector3.Distance(enemy.destinationPoint, enemy.currentPoint));

            Vector3 normalVector = (enemy.destinationPoint - enemy.currentPoint).normalized;
            enemy.transform.rotation = Quaternion.LookRotation(normalVector);
            enemy.rigidbodyComponent.velocity = normalVector * GameTimeManager.Instance.DeltaTime * enemy.MoveSpeed * speedCorrection;
        }
    }
}