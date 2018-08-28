using RedTheSettlers.GameSystem;
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

        public void SendTradeData(ItemData[] itemDatas, int requestPlayer, int receivePlayer)
        {
             
            GameManager.Instance.SendTradeData(itemDatas, requestPlayer, receivePlayer);
        }

        public void RecieveTradeResult(OtherPlayerState state)
        {
            tradeUI.GetComponentInChildren<UITradeCard>().RecieveTradeData(state);
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

        public void RequestStorageEventNumber(int eventNumber)
        {
            GameManager.Instance.SetWeatherEventNumber(eventNumber);
        }
    }
}