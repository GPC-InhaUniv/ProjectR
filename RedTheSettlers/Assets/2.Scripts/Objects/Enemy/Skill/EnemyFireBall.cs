using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class EnemyFireBall : MonoBehaviour
    {
        public Rigidbody rigidbodyComponent;

        private void Start()
        {
            rigidbodyComponent = GetComponent<Rigidbody>();
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            rigidbodyComponent.velocity = Vector3.zero;
        }
    }
}