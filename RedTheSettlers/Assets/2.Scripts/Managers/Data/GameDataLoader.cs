using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace RedTheSettlers.GameSystem
{
    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class GameDataLoader
    {
        private DatabaseReference reference;
        private string jsonData;

        public GameDataLoader()
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://redthesettlers.firebaseio.com");
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        /// <summary>
        /// 서버에 아이디 중복 체크한 후 중복된 값이 없다면 회원가입을 완료합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        public void MakeNewAccountInDB(string id, string password)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWith(
            searchtask =>
            {
                if (searchtask.IsFaulted)
                {
                    Debug.Log("데이터베이스에 접근 실패.");
                    return;
                }
                else if (searchtask.IsCompleted)
                {
                    DataSnapshot snapshot = searchtask.Result;
                    foreach (DataSnapshot datasnapshot in snapshot.Children)
                    {
                        if (id.Equals(datasnapshot.Key))
                        {
                            Debug.Log("이미 계정이 존재합니다");
                            return;
                        }
                    }
                    DataManager.Instance.GameData.UserId = id;
                    DataManager.Instance.GameData.UserPassword = password;
                    jsonData = JsonUtility.ToJson(DataManager.Instance.GameData);
                    reference.Child("Users").Child(id).SetRawJsonValueAsync(jsonData).ContinueWith(
                    signUpTask =>
                    {
                        if (signUpTask.IsFaulted)
                        {
                            Debug.Log("데이터베이스에 접근 실패.");
                            return;
                        }
                        else if (signUpTask.IsCompleted)
                        {
                            Debug.Log("회원가입 성공");
                            //createAccountCallBack(true);
                            return;
                        }
                    });
                    return;
                }
            });
        }

        /// <summary>
        /// 서버를 통해 아이디,비밀번호를 체크 및 도중에 중단 된 게임 데이터를 불러옵니다.
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        public void LoadLoginDataFromDB(string id, string password)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWith(
            task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("데이터베이스에 접근 실패.");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (DataSnapshot datasnapshot in snapshot.Children)
                    {
                        Debug.Log(password);
                        if (id.Equals(datasnapshot.Key))
                        {
                            Dictionary<string, object> userDataDictionary = (Dictionary<string, object>)datasnapshot.Value;
                            if (password.Equals(datasnapshot.Child("UserPassword").Value))
                            {
                                DataManager.Instance.GameData = JsonUtility.FromJson<GameData>(datasnapshot.GetRawJsonValue());
                                return;
                            }
                            else
                            {
                                Debug.Log("비밀번호가 틀렸습니다");
                                return;
                            }
                        }
                    }
                    Debug.Log("존재하지 않는 아이디입니다.");
                    return;
                }
            });
        }

        /// <summary>
        /// 서버에 현재 정보로 최신화 합니다. 
        /// </summary>
        /// <param name="gameData"></param>
        public void SetUpdateInDB(GameData gameData)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWith(
            searchtask =>
            {
                if (searchtask.IsFaulted)
                {
                    Debug.Log("데이터베이스에 접근 실패.");
                    return;
                }
                else if (searchtask.IsCompleted)
                {
                    DataSnapshot snapshot = searchtask.Result;
                    foreach (DataSnapshot datasnapshot in snapshot.Children)
                    {
                        if (gameData.UserId.Equals(datasnapshot.Key))
                        {
                            jsonData = JsonUtility.ToJson(gameData);
                            reference.Child("Users").Child(gameData.UserId).SetRawJsonValueAsync(jsonData);
                            Debug.Log("데이터 갱신 성공");
                            return;
                        }
                        Debug.Log("데이터 갱신 실패");
                    }
                }
            });
        }
    }
}
