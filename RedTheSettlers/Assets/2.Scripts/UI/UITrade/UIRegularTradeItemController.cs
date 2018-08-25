using UnityEngine;
using System.Collections;
using RedTheSettlers.GameSystem;
using UnityEngine.UI;

namespace RedTheSettlers.UI
{
    public class UIRegularTradeItemController : MonoBehaviour
    {
        [SerializeField]
        private GameObject RegularTradeGroup;

        private float[] tempRegularGiveValue = new float[6]
       {0,0,0,0,0,0};  //순서대로 Cow,Iron,SOil,Water,Wheat,Wood

        private float[] tempRegularTakeValue = new float[6]
        {0,0,0,0,0,0};  //순서대로 Cow,Iron,SOil,Water,Wheat,Wood

        
        public void OnClickedRegularButton()
        {
            RegularTradeGroup.SetActive(true);
        }

    }
}