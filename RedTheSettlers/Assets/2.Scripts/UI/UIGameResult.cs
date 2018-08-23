using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// game 결과에 따라서,문구 출력 및, 버튼 이벤트
/// </summary>

namespace RedTheSettlers.UI
{
    public class UIGameResult : MonoBehaviour
    {
        [Header("Result Text")]
        [SerializeField]
        private Text gameResultText;

        [Header("Enter Scene Button")]
        [SerializeField]
        private GameObject MainSceneButton;

        [SerializeField]
        private GameObject CloseSceneButton;

        public void ChangeResultText()
        {
        }

        public void OnEnterScene()
        {
        }

        private void Start()
        {
        }

        private void Update()
        {
        }
    }
}