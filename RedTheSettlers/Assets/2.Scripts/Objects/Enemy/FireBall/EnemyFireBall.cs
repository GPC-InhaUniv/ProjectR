using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    public Rigidbody rigidbodyComponent;

    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        rigidbodyComponent.velocity = Vector3.zero;
    }
}
