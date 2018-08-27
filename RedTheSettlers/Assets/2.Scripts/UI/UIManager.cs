using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTheSettlers.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private GameObject playerTurnUI;

        [SerializeField]
        private GameObject tradeUI, equipmentAndSkillUI, stateUI;

        [SerializeField]
        private GameObject battleUI;

        [SerializeField]
        private GameObject bossWarningUI;

        [SerializeField]
        private GameObject weatherEventSelectUI;

        private void ShowBoardUI()
        {
            playerTurnUI.SetActive(true);
        }

        public void OnClickedEquipAndSkillButton()
        {
            equipmentAndSkillUI.SetActive(true);
            playerTurnUI.SetActive(false);
        }

        public void OnClickedStateButton()
        {
            stateUI.SetActive(true);
            playerTurnUI.SetActive(false);
        }

        public void OnClickedTradeButton()
        {
            tradeUI.SetActive(true);
            playerTurnUI.SetActive(false);
        }

        public void OnClickedTurnCloseButton()
        {
            playerTurnUI.SetActive(false);
            equipmentAndSkillUI.SetActive(false);
            stateUI.SetActive(false);
            tradeUI.SetActive(false);
        }

        public void ShowBattleUI()
        {
            battleUI.SetActive(true);
        }

        public void ShowBossWarningUI()
        {
            bossWarningUI.SetActive(true);
        }

        public void ShowWheatherEvent(int[] weathers)
        {
            weatherEventSelectUI.SetActive(true);
            weatherEventSelectUI.GetComponentInChildren<UIWeatherSelect>().ReceiveEventNumbers(weathers);
        }
    }
}