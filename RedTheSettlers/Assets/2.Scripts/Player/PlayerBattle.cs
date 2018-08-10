using RedTheSettlers.GameSystem;
using RedTheSettlers.Enemys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Players
{
    public enum PlayerStateType
    {
        Attack,
        Move,
        CastSkill,
        Dead
    }

    public class PlayerBattle : MonoBehaviour
    {

        private GameTimer playerTimer;
        private Animator animator;

        private int hp;
        private int mp;
        private float moveSpeed = 2.0f;
        private bool isAttacking = false;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public IEnumerator MoveToTargetPostion(Vector3 targetPosition)
        {
            animator.SetBool("IsRunning", true);

            Quaternion targetAngle = Quaternion.LookRotation(targetPosition - transform.position);

            while (Quaternion.Angle(transform.rotation, targetAngle) > 0.05f ||
                    Vector3.Distance(transform.position, targetPosition) > 0.05f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.2f);
                transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                yield return null;
            }

            animator.SetBool("IsRunning", false);
        }

        public IEnumerator MoveToDirection(Vector3 Direction)
        {
            animator.SetBool("IsRunning", true);

            Quaternion targetAngle = Quaternion.LookRotation(Direction);

            int frameCount = 0;

            while (frameCount < 30)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.2f);

                transform.position += Direction * moveSpeed * Time.deltaTime;

                frameCount++;

                yield return null;
            }

            animator.SetBool("IsRunning", false);
        }

        public IEnumerator AttackEnemy()
        {
            if(isAttacking)
            {
                yield return null;
            }
            else
            {
                isAttacking = true;

                animator.SetTrigger("Attack");

                while(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    yield return null;
                }

                isAttacking = false;

            }
        }

        public IEnumerator HittedByEnemy(int damage)
        {
            yield return null;
        }

        public IEnumerator UseSkill(Skill skill)
        {
            yield return null;
        }
    }
}

