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
}
