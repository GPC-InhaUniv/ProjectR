using RedTheSettlers.GameSystem;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 김하정
/// </summary>
namespace RedTheSettlers
{
    namespace UI
    {
        public class UILoginScript : MonoBehaviour
        {

            //[HideInInspector]
            [Header("Player Info")]
            [SerializeField]
            private InputField playerID;

            //[HideInInspector]
            [SerializeField]
            private InputField playerPassword;

            [SerializeField]
            private Text loginAlertText;

            [SerializeField]
            private InputField SignUpID;
            [SerializeField]
            private InputField SignUpPassword;
            [SerializeField]
            private InputField PasswordConfirmation;

            [SerializeField]
            private Text createAlertText;

            // Use this for initialization
            void Start()
            {
                loginAlertText.text = "정보가 올바르지 않습니다.";
                createAlertText.text = "정보가 올바르지 않습니다.";
            }

            public void OnClickedGameQuitButton()
            {
                Application.Quit();
            }

            public void OnClickedLoginButton()
            {
                DataManager.Instance.Login(playerID.text, playerPassword.text);
                ChangeText();
            }

            public void OnClickedCreateAccountButton()
            {
                if (SignUpPassword.text == PasswordConfirmation.text)
                {
                    DataManager.Instance.CreateNewAccount(SignUpID.text, SignUpPassword.text);
                    ChangeText();
                }
                else
                    createAlertText.text = "비밀번호확인이 일치하지 않습니다.";

            }

            public void onClickedUpdateButton()
            {

                DataManager.Instance.SaveGameData();
            }

            public void onClickedResetButton()
            {
                DataManager.Instance.ResetData();
            }

            private void ChangeText()
            {
                loginAlertText.text = "확인중.";
                createAlertText.text = "확인중.";
            }
        }
    }
}
