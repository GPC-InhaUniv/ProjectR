using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitArea : MonoBehaviour
{
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerAttack")
        {

        }
        Debug.Log("EnemyHitArea.OnTriggerEnter");
        enemy.StartDamage(0);
    }
}
