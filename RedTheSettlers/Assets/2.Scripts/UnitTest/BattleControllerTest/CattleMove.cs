using UnityEngine;
using RedTheSettlers.GameSystem;

namespace RedTheSettlers.UnitTest
{
    public class CattleMove : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10f;
        private int hitDamage = 20;

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == GlobalVariables.TAG_ENEMY)
            {
                Debug.Log("충돌 에너미");
                //collision.gameObject.GetComponent<Enemy>().Damaged(hitDamage);
            }
            else if(collision.gameObject.tag == GlobalVariables.TAG_PLAYER)
            {
                //collision.gameObject.GetComponent<BattlePlayer>().HittedByEnemy(hitDamage);
                Debug.Log("충돌 플레이어");
            }
        }
    }
}