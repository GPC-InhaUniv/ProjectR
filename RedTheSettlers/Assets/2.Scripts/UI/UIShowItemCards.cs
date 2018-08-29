using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTheSettlers.GameSystem;
using UnityEngine.UI;

namespace RedTheSettlers.UI
{
    public class UIShowItemCards : MonoBehaviour {

        [SerializeField]
        private GameObject cardObject;

        // Use this for initialization
        void Start() {
            //MakeCard();
        }

        GameData gameData;

        private void MakeCard()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject card = Instantiate(cardObject) as GameObject;
            }
            //Debug.Log(gameData.PlayerData[0].TileList.Count);
        }
    }
}
