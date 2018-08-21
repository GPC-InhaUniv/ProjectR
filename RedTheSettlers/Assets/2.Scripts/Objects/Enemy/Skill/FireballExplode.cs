using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class Explode : MonoBehaviour
    {
        ParticleSystem particle;
        public GameObject SkillRangeCircle;
        
        private void Start()
        {
            particle = GetComponent<ParticleSystem>();    
        }

        private void Update()
        {
            if (!particle.isEmitting)
            {
                SkillRangeCircle.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == GlobalVariables.TAG_PLAYER && particle.isEmitting)
            {

            }
        }
    }
}

