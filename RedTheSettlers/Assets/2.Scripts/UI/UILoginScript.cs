using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
/// <summary>
/// 작성자 : 김하정
/// </summary>
public class UILoginScript : MonoBehaviour {

    //[HideInInspector]
    [Header("Player Info")]
    [SerializeField]
    private Text playerID;

    //[HideInInspector]
    [SerializeField]
    private Text playerPassword;

    [SerializeField]
    private Text loginAlertText;

    [SerializeField]
    private Text createAlertText;

	// Use this for initialization
	void Start () {
        ChangeText();
    }

    public void OnClickedGameQuitButton()
    {
        Application.Quit();
    }

    public void OnClickedLoginButton()
    {
        ChangeText();
    }

    private void ChangeText()
    {
        loginAlertText.text = "정보가 올바르지 않습니다.";
        createAlertText.text = "정보가 올바르지 않습니다.";
    }
}
