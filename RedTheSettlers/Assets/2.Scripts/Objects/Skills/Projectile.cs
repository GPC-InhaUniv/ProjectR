using UnityEngine;
using RedTheSettlers.Enemys;

namespace RedTheSettlers.Skills
{
    public class Projectile : MonoBehaviour
    {
        private const int projectileDamage = 5;

        private void OnCollisionEnter(Collision collision)
        {
            GameObject target = collision.gameObject;

            if(target.CompareTag("Enemy"))
            {
                target.GetComponent<Enemy>().StartDamage(projectileDamage);
            }

            Destroy(gameObject);
        }
    }
}
