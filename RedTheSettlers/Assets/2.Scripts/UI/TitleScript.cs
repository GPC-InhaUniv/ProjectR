using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{

    public Text TitleText;
   private Color color;
    private float alpha;

   
    void Update()
    {
      
        StartCoroutine(FadeInCoroutine());
         
        

    }



    IEnumerator FadeInCoroutine()
    {


        while (TitleText.color.a >= 0)
        {

            int count = 0;
            while (count < 100)
            {
                alpha += Time.deltaTime / 2;
                TitleText.color = new Color(TitleText.color.r, TitleText.color.g, TitleText.color.b, alpha);
                yield return new WaitForSeconds(2f);
                alpha = 0;
                TitleText.color = new Color(TitleText.color.r, TitleText.color.g, TitleText.color.b, alpha);
                yield return null;
                alpha += Time.deltaTime / 2;
                TitleText.color = new Color(TitleText.color.r, TitleText.color.g, TitleText.color.b, alpha);
                yield return new WaitForSeconds(2f);
                count++;
            }
 
           
           
           

        }
        

        

    }

    

}
