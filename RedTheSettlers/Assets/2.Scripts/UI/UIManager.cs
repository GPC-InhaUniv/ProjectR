using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject boardUI;

    [SerializeField]
    private GameObject battleUI;

    [SerializeField]
    private GameObject gameResultUI;
}
