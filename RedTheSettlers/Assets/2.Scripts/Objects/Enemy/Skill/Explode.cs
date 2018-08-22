using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class Explode : MonoBehaviour
    {
        [SerializeField]
        private GameObject SkillRangeCircle;
        private ParticleSystem particle;
        private float skillRange;

        private void Start()
        {
            particle = GetComponent<ParticleSystem>();
            skillRange = GetComponent<SphereCollider>().radius / 5;
            SkillRangeCircle.transform.localScale = new Vector3(skillRange, 0f, skillRange);
            SkillRangeCircle.SetActive(false);
            gameObject.SetActive(false);
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