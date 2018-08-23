using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTheSettlers.GameSystem {
    /// <summary>
    /// 작성자 : 
    /// </summary>
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

        /// <summary>
        /// 작성자 : 박지용
        /// TradeUI 패널에서 가져온 tradeData를 반환하는 함수
        /// </summary>
        public TradeData GetTradeData()
        {
            TradeData tradeData = new TradeData();
            return tradeData;
        }
    }
}