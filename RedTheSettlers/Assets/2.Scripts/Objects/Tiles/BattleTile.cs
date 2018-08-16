using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.Tiles
{
    public class BattleTile : Tile {

        private void Start()
        {
            StartCoroutine(DropTile());
        }

        private IEnumerator DropTile()
        {
            int suddenDeathTimecount = 0;

            while (suddenDeathTimecount < 10)
            {
                suddenDeathTimecount++;
                yield return new WaitForSeconds(0.1f);
            }

            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}