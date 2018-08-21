using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class FireballExplode : MonoBehaviour
    {
        ParticleSystem particle;

        private void Start()
        {
            particle = GetComponent<ParticleSystem>();    
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == GlobalVariables.TAG_PLAYER && particle.isEmitting)
            {

            }
        }
    }
}

