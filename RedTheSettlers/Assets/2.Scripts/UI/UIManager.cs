using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTheSettlers.UI
{
    /// <summary>
    /// 작성자 : 강다희, 김하정
    /// UI Manager
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private GameObject playerTurnUI;

        [SerializeField]
        private GameObject CommonPlayerItemUI;

        [SerializeField]
        private GameObject tradeUI, equipmentAndSkillUI, stateUI;

        [SerializeField]
        private GameObject battleUI;

        [SerializeField]
        private GameObject bossWarningUI;

        [SerializeField]
        private GameObject weatherEventSelectUI;

        [SerializeField]
        private GameObject selectTileUI;
 
        public void ShowBoardUI()
 
        {
            playerTurnUI.SetActive(true);
            CommonPlayerItemUI.SetActive(true);
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
            playerTurnUI.SetActive(false);
            tradeUI.SetActive(true);
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

        public void SendTileInfo(BoardTile selectionTile)
        {
            selectTileUI.SetActive(true);
            selectTileUI.GetComponentInChildren<UISelectTile>().SetSelectTileInfo(selectionTile);
        }

        public void SendBattleTileInfo(BoardTile tileInfo)
        {
            GameManager.Instance.BulidBattleTile(tileInfo);
        }

        /// <summary>
        /// 플레이어 공격 레벨 전달
        /// </summary>
        public void SendPlayerAttackLevel(int attackLevel)
        {
            //게임 매니저에 넣을 수 있는 함수.
            //setPlayerAttack
        }
        /// <summary>
        /// 플레이어 방어 레벨 전달
        /// </summary>
        public void SendPlayerDefenseLevel(int defenseLevel)
        {
            // 게임 매니저에 넣을 수 있는 함수
        }
        /// <summary>
        /// 교환 후 : 플레이어 자원 게산결과 전달
        /// </summary>
        public void SendPlayerItems(int wood, int iron, int soil)
        {
            GameManager gameManager = GameManager.Instance;

            gameManager.AddItemByType(0, ItemType.Wood, wood);
            gameManager.AddItemByType(0, ItemType.Iron, iron);
            gameManager.AddItemByType(0, ItemType.Soil, soil);
        }
    }
}