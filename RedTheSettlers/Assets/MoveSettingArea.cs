using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSettingArea : MonoBehaviour {

    public PlayerBattle playerbattle;
    private Coroutine coroutine;

    private void Start()
    {
        StartCoroutine(MouseClick());
    }

    private IEnumerator MouseClick()
    {
        while(true)
        {
            if (Input.GetMouseButton(0))
            {
                Move();
                yield return new WaitForSeconds(0.25f);
            }

            yield return null;
        }
    }

    private void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.name.Contains("Plane"))
            {
                Vector3 targetPosition = hit.point + new Vector3(0, playerbattle.transform.position.y, 0);
                if(coroutine == null)
                {
                    coroutine = StartCoroutine(playerbattle.MoveTo(targetPosition));
                }
                else
                {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(playerbattle.MoveTo(targetPosition));
                }
            }
        }
    }
}
