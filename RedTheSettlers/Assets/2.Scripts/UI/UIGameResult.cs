using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// game 결과에 따라서,문구 출력 및, 버튼 이벤트
/// [참고]UIManager에서 게임결과 text 연결
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

        private int resultType;

        public void ChangeResultText()
        {
            if (resultType == 0)
            {
                gameResultText.text = "Game Clear";
            }
            else
            {
                gameResultText.text = "Game Over";
            }
        }

        public void OnEnterScene()
        {
            //스테이지 매니저 쪽에서 넘겨줘야 함.
        }

        public void CloseScene()
        {
            //스테이지 매니저 쪽에서 넘겨줘야 함.
        }

        private void Start()
        {
            resultType = 1; //유아이 매니저쪽에서 넘겨줘야 함.
            ChangeResultText();
        }

        private void Update()
        {
        }
    }
}