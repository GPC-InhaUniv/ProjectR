using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAITurn : MonoBehaviour
{
    [SerializeField]
    private Image aiPlayerImage;
    [SerializeField]
    private Image turnCircleImage;
    [SerializeField]
    private Text aiPlayerNameText;
    [SerializeField]
    private Text aiTurnContentText;

    private WaitForSeconds waitForSeconds;
    private int aiTurnCount = 1;

    IEnumerator ChangeSliderFillAmount()
    {
        ChangeAiPlayerNameText(aiTurnCount);
        turnCircleImage.fillAmount = 0;
        while (turnCircleImage.fillAmount < 1)
        {
            //turnCircleImage.fillAmount += 0.002f; 기존
            if (turnCircleImage.fillAmount == 0.2f)
                ChangeAiPlayerImage(aiTurnCount);
            else if(turnCircleImage.fillAmount == 0.5f)

            turnCircleImage.fillAmount += 0.008f;
            yield return null;
        }
        aiTurnCount++;   
        Debug.Log("Exit");
        if(aiTurnCount < GlobalVariables.MaxPlayerNumber)
            StartCoroutine(ChangeSliderFillAmount());
    }

    private void Start()
    {
        StartCoroutine(ChangeSliderFillAmount());
    }

    private void ChangeAiPlayerNameText(int turnCount)
    {
        if(turnCount == 1)
        {
            aiPlayerNameText.text = "First AI";
            aiPlayerNameText.color = new Color32(219, 31, 31, 255);
        }
        else if(turnCount == 2)
        {
            aiPlayerNameText.text = "Second AI";
            aiPlayerNameText.color = new Color32(31,79,219, 255);
        }
        else if(turnCount == 3)
        {
            aiPlayerNameText.text = "Third AI";
            aiPlayerNameText.color = new Color32(79, 146, 25, 255);
        }
    }

    private void ChangeAiPlayerImage(int turnCount, int image)
    {

    }











}
