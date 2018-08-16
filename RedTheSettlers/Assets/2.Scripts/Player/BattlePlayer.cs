using RedTheSettlers.GameSystem;
using RedTheSettlers.Skills;
using System.Collections;
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

    public class BattlePlayer : MonoBehaviour
    {
        private GameTimer playerTimer;
        private Animator animator;

        private int hp;
        private int mp;
        private float moveSpeed = 2.0f;
        private bool isAttacking = false;

        private Skill[] skillSet = new Skill[4];

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public IEnumerator MoveToTargetPostion(Vector3 targetPosition)
        {
            animator.SetBool("IsRunning", true);

            Quaternion targetAngle = Quaternion.LookRotation(targetPosition - transform.position);

            while (Quaternion.Angle(transform.rotation, targetAngle) > 0.1f ||
                    Vector3.Distance(transform.position, targetPosition) > 0.05f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.5f);
                transform.position += Vector3.Normalize(targetPosition - transform.position) * moveSpeed * Time.deltaTime;

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
                transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.5f);

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

        public void ChangeSpeed(float amount)
        {
            moveSpeed += amount;
        }
    }
}

