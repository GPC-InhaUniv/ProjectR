using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {
    
	void Start () {
        StartCoroutine(UseFireball());
	}
	
    IEnumerator UseFireball()
    {
        while(true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(ObjectPoolManager.ObjectPoolInstance.SkillQueue.Count > 0)
                {
                    Instantiate(ObjectPoolManager.ObjectPoolInstance.SkillQueue.Dequeue(), gameObject.transform.position + Vector3.forward * 3, gameObject.transform.rotation);
                }
            }

            yield return null;
        }
    }
}
