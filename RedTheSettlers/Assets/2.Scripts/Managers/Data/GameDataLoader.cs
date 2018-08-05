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
    }

    public void LoginButton()
    {
        LoadLoginDataFromDB("ggolnam2", "3355aass");
    }

    public void SignUpButton()
    {
        SkillData skillData;
        skillData.skillNum = 100;
        skillData.slotNum = 10;
        DataManager.Instance.GameData.PlayerData[0].SkillList.Add(skillData);
        MakeNewAccountInDB("ggolnam2", "3355aass");
    }

    public void UpdateButton()
    {
        SkillData skillData;
        skillData.skillNum = 6;
        skillData.slotNum = 1;
        SkillData skillData2;
        skillData2.skillNum = 4;
        skillData2.slotNum = 0;
        SkillData skillData3;
        skillData3.skillNum = 8;
        skillData3.slotNum = 2;

        TileData tileData;
        tileData.LocationX = 3;
        tileData.LocationY = 11;
        tileData.TileLevel = 5;
        tileData.TileType = TileType.Beef;
        TileData tileData2;
        tileData2.LocationX = 5;
        tileData2.LocationY = 16;
        tileData2.TileLevel = 7;
        tileData2.TileType = TileType.Soil;
        TileData tileData3;
        tileData3.LocationX = 8;
        tileData3.LocationY = 21;
        tileData3.TileLevel = 2;
        tileData3.TileType = TileType.Wood;
        for (int i = 0; i < 4; i ++)
        {
            DataManager.Instance.GameData.PlayerData[i].ResourceData.CowNum = 3;
            DataManager.Instance.GameData.PlayerData[i].ResourceData.IronNum = 8;
            DataManager.Instance.GameData.PlayerData[i].ResourceData.SoilNum = 2;
            DataManager.Instance.GameData.PlayerData[i].ResourceData.WaterNum = 10;
            DataManager.Instance.GameData.PlayerData[i].ResourceData.WheatNum = 5;
            DataManager.Instance.GameData.PlayerData[i].ResourceData.WoodNum = 7;
            DataManager.Instance.GameData.PlayerData[i].StatData.ArmorLevel = 3;
            DataManager.Instance.GameData.PlayerData[i].StatData.WeaponLevel = 2;
            DataManager.Instance.GameData.PlayerData[i].StatData.HealthPoint = 20;
            DataManager.Instance.GameData.PlayerData[i].StatData.MagicPoint = 10;
            DataManager.Instance.GameData.PlayerData[i].StatData.StaminaPoint = 3;
            DataManager.Instance.GameData.PlayerData[i].InGameData.BossKillCount = 2;
            DataManager.Instance.GameData.PlayerData[i].InGameData.TurnCount = 30;
            DataManager.Instance.GameData.PlayerData[i].InGameData.Weather = 3;
            DataManager.Instance.GameData.PlayerData[i].SkillList.Add(skillData);
            DataManager.Instance.GameData.PlayerData[i].SkillList.Add(skillData2);
            DataManager.Instance.GameData.PlayerData[i].SkillList.Add(skillData3);
            DataManager.Instance.GameData.PlayerData[i].TileList.Add(tileData);
            DataManager.Instance.GameData.PlayerData[i].TileList.Add(tileData2);
            DataManager.Instance.GameData.PlayerData[i].TileList.Add(tileData3);

        }

        SetPurchaseDataInDB(DataManager.Instance.GameData);
    }


    /// <summary>
    /// 서버에 아이디 중복 체크한 후 중복된 값이 없다면 회원가입을 완료합니다.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="password"></param>
    public void MakeNewAccountInDB(string id, string password)
    {

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
                DataManager.Instance.GameData.UserId = id;
                DataManager.Instance.GameData.UserPassword = password;
                jsonData = JsonUtility.ToJson(DataManager.Instance.GameData);
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
                        if (password.Equals(datasnapshot.Child("UserPassword").Value))
                        {
                            DataManager.Instance.GameData = JsonUtility.FromJson<GameData>(datasnapshot.GetRawJsonValue());
                            Debug.Log(DataManager.Instance.GameData.PlayerData[0].SkillList.Count);
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

    /// <summary>
    /// 서버에 현재 정보로 최신화 합니다. 
    /// </summary>
    /// <param name="gameData"></param>
    public void SetPurchaseDataInDB(GameData gameData)
    {
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
                string userId = DataManager.Instance.GameData.UserId;
                Debug.Log(userId);
                DataSnapshot snapshot = searchtask.Result;
                foreach (DataSnapshot datasnapshot in snapshot.Children)
                {
                    if (userId.Equals(datasnapshot.Key))
                    {
                        jsonData = JsonUtility.ToJson(gameData);
                        reference.Child("Users").Child(userId).SetRawJsonValueAsync(jsonData);
                        Debug.Log("데이터 갱신 성공");
                        return;
                    }
                    Debug.Log("데이터 갱신 실패");
                }
            }
        });
    }




}
