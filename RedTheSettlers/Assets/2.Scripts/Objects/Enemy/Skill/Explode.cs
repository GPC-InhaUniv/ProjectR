using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public class Explode : MonoBehaviour
    {
        [SerializeField]
        public GameObject SkillRangeCircle;
        [SerializeField]
        public ParticleSystem particle;
        public bool isViewingCircle;
        public SphereCollider SphereColliderConponent;
        public float skillRange;

        private void Start()
        {
            particle = GetComponentInChildren<ParticleSystem>();
            SphereColliderConponent = GetComponentInChildren<SphereCollider>();
            Setting(1);
        }

        public void Setting(float radius)
        {
            SphereColliderConponent.radius = radius + 1;
            skillRange = SphereColliderConponent.radius / 5;
            SkillRangeCircle.transform.localScale = new Vector3(skillRange, 0f, skillRange);
            SkillRangeCircle.SetActive(false);
            isViewingCircle = false;
            particle.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!isViewingCircle && !particle.isEmitting)
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