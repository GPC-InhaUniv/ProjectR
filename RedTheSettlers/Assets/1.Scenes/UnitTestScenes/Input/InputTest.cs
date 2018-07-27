using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    [SerializeField]
    InputManager inputManager;
    private void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
}
