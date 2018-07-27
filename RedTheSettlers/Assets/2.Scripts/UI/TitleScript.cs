using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public Text TitleText;
    private Color color;
    private float alpha;
    [SerializeField, Range(0,2)]
    private float speed;

    private void Start()
    {
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        float count = 0;
        while (true)
        {           
            alpha = Mathf.Sin(count * Mathf.Deg2Rad);
            TitleText.color = new Color(TitleText.color.r, TitleText.color.g, TitleText.color.b, alpha);
            count += Time.deltaTime * 90f * speed ;

            if (count > 180f)
            {
                count = 0;
            }

            yield return null;
        }
    }



}
