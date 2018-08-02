using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Attack,
    Move,
    CastSkill,
    Dead
}

public class PlayerBattle : MonoBehaviour {

    private GameTimer playerTimer;

    private int hp;
    private int mp;
    private float moveSpeed = 2.0f;
    
    public IEnumerator MoveToTargetPostion(Vector3 targetPosition)
    {
        Quaternion targetAngle = Quaternion.LookRotation(targetPosition - transform.position);

        while (Quaternion.Angle(transform.rotation, targetAngle) > 0.05f ||
                Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.2f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public IEnumerator MoveToDirection(Vector3 Direction)
    {
        Quaternion targetAngle = Quaternion.LookRotation(Direction);

        int frameCount = 0;

        while (frameCount < 30)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.2f);

            transform.position += Direction * moveSpeed * Time.deltaTime;

            frameCount++;

            yield return null;
        }
    }

    public IEnumerator UseSkill(SkillType skillType)
    {
        yield return null;
    }
}
