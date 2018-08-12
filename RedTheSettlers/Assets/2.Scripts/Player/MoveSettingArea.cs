using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Players;

public class MoveSettingArea : MonoBehaviour {

    public PlayerBattle playerbattle;
    private Coroutine coroutineMove;
    private Coroutine coroutineAttack;

    private void Start()
    {
        StartCoroutine(GetInput());
    }

    private IEnumerator GetInput()
    {
        while(true)
        {
            if (Input.GetMouseButton(0))
            {
                MoveByMousePointer();
                yield return new WaitForSeconds(0.25f);
            }

            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveByKeyboard();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                MakePlayerAttack();
            }

            yield return null;
        }
    }

    private void MoveByMousePointer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.name.Contains("Plane"))
            {
                Vector3 targetPosition = hit.point + new Vector3(0, playerbattle.transform.position.y, 0);
                if(coroutineMove == null)
                {
                    coroutineMove = StartCoroutine(playerbattle.MoveToTargetPostion(targetPosition));
                }
                else
                {
                    StopCoroutine(coroutineMove);
                    coroutineMove = StartCoroutine(playerbattle.MoveToTargetPostion(targetPosition));
                }
            }
        }
    }

    private void MoveByKeyboard()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (coroutineMove == null)
        {
            coroutineMove = StartCoroutine(playerbattle.MoveToDirection(direction));
        }

        else
        {
            StopCoroutine(coroutineMove);
            coroutineMove = StartCoroutine(playerbattle.MoveToDirection(direction));
        }
    }

    private void MakePlayerAttack()
    {
        if(coroutineAttack == null)
        {
            coroutineAttack = StartCoroutine(playerbattle.AttackEnemy());
        }
    }
}
