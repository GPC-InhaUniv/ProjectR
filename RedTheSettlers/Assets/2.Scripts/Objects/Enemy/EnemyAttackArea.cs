using RedTheSettlers.GameSystem;
using RedTheSettlers.Players;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class EnemyAttackArea : MonoBehaviour
    {
        public Enemy enemy;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == GlobalVariables.TAG_PLAYER)
            {
                other.GetComponent<BattlePlayer>().HittedByEnemy((int)enemy.Power);
            }
        }
    }
}