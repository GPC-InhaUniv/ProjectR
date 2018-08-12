using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers
{
    public class SkillController : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(UseFireball());
        }

        IEnumerator UseFireball()
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (ObjectPoolManager.ObjectPoolInstance.SkillQueue.Count > 0)
                    {
                        Vector3 positionToCreate = transform.rotation * Vector3.forward * 2 + transform.position;

                        Instantiate(ObjectPoolManager.ObjectPoolInstance.SkillQueue.Dequeue(), positionToCreate, transform.rotation);
                    }
                }

                yield return null;
            }
        }
    }
}
