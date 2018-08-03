using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private Enemy enemy;
    public Collider AttackCollider;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        AttackCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //플레이어에게 타격을 준다.
            
        }


    }
}
