using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject gameResultCalculateUI;

    [SerializeField]
    private GameObject equipmentAndSkillUI;

    private void Start()
    {
        equipmentAndSkillUI.gameObject.SetActive(true);
    }

    public void OnClickedBuildCamp()
    {
        gameResultCalculateUI.gameObject.SetActive(true);
    }
}
