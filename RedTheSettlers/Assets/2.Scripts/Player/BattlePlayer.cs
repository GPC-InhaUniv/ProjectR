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
        [SerializeField]
        private GameObject AttackBox;

        private int hp;
        private int mp;
        private float standardSpeed = 2.0f;
        private float moveSpeed = 2.0f;

        private Skill[] skillSlot = new Skill[4];

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

        public void AttackEnemy(int damage)
        {
            StartCoroutine(AttackEnemyCoroutine(damage));
        }

        public IEnumerator AttackEnemyCoroutine(int damage)
        {
            animator.SetTrigger("Attack");

            AttackBox.SetActive(true);

            yield return new WaitForSeconds(1f);
            
            AttackBox.SetActive(false);
        }

        public void HittedByEnemy(int damage)
        {
            StartCoroutine(HittedByEnemyCoroutine(damage));
        }

        public IEnumerator HittedByEnemyCoroutine(int damage)
        {
            animator.SetBool("IsDamaged", true);

            yield return null;
        }

        public void UseSkill(int skillSlotNum)
        {
            skillSlot[skillSlotNum].ActivateSkill(this);
        }

        public void ChangeSpeed(float amount)
        {
            moveSpeed += amount;
        }

        public void SlowDownSpeedByWater()
        {
            moveSpeed = 1.0f;
        }

        public void RecoverySpeed()
        {
            moveSpeed = 2.0f;
        }
    }
}

