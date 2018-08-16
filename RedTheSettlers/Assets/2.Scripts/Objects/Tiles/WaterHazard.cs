using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.Players;

namespace RedTheSettlers.Tiles
{
    public class WaterHazard : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<BattlePlayer>().ChangeSpeed(-1.0f);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<BattlePlayer>().ChangeSpeed(1.0f);
            }
        }
    }
}
