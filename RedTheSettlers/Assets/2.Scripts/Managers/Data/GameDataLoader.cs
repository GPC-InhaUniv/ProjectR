using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataLoader : MonoBehaviour
{


    private DatabaseReference reference;
    string jsonData;
    GameData copiedData;
    void Start()
    {

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://redthesettlers.firebaseio.com");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        SkillData skillData;
        skillData.skillNum = 2;
        skillData.slotNum = 3;

        DataManager.Instance.GameData.SkillList.Add(skillData);

        TileData tileData;
        tileData.LocationX = 2;
        tileData.LocationY = 6;
        tileData.TileLevel = 3;
        tileData.TileType = TileType.Soil;

        DataManager.Instance.GameData.TileList.Add(tileData);
    }

    public void LoginButton()
    {
        LoadLoginDataFromDB("ggolnam2", "3355aass");
    }

    public void SignUpButton()
    {

        MakeNewAccountInDB("ggolnam2", "3355aass");
    }



    public void MakeNewAccountInDB(string id, string password)
    {
        DataManager.Instance.GameData.PlayerPassword = password;
        jsonData = JsonUtility.ToJson(DataManager.Instance.GameData);

        Debug.Log(jsonData);

        //userDataDictionary.OrderByDescending(num => num.Key);

        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWith(
        searchtask =>
        {
            if (searchtask.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
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
                        //createAccountCallBack(false);
                        return;
                    }
                }
                reference.Child("Users").Child(id).SetRawJsonValueAsync(jsonData).ContinueWith(
                signUpTask =>
                {
                    if (signUpTask.IsFaulted)
                    {
                        Debug.Log("데이터베이스에 접근할 수 없습니다");
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

    public void LoadLoginDataFromDB(string id, string password)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWith(
        task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot datasnapshot in snapshot.Children)
                {
                    if (id.Equals(datasnapshot.Key))
                    {
                        Dictionary<string, object> userDataDictionary = (Dictionary<string, object>)datasnapshot.Value;
                        if (password.Equals(datasnapshot.Child("PlayerPassword").Value))
                        {
                            DataManager.Instance.GameData = JsonUtility.FromJson<GameData>(datasnapshot.GetRawJsonValue());
                            Debug.Log(DataManager.Instance.GameData.SkillList.Count);
                            return;
                        }
                        else
                        {
                            Debug.Log("비밀번호가 틀렸습니다");
                            return;
                        }
                    }
                }
                Debug.Log("회원가입이 되어있지 않습니다");
                return;
            }
        });
    }


}
