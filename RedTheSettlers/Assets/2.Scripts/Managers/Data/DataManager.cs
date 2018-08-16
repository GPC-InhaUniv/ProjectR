using System;
using System.IO;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{

    [Serializable]
    public struct AssetBundleData
    {
        public string Player;
        public string Skill;
        public string Enemey;
        public string FirstBoss;
        public string SecondBoss;
        public string ThirdBoss;
        public string UI;
        public string Tile;
    }
    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
        public const string DirectoryName = "Data";
        public const string FilePath = DirectoryName + "/AssetBundleData.txt";
        private GameData gameData;

        public GameData GameData
        {
            get { return gameData; }
        }


        private GameDataLoader gameDataLoader;
        // Use this for initialization
        void Awake()
        {
            gameData = new GameData(4);
            gameDataLoader = new GameDataLoader();

            string json = JsonUtility.ToJson(gameData);
            Debug.Log(json);
            CheckedBundleVersion(AssetBundleNumbers.Player, "01024a35g3b");
        }

        public void CreateNewAccount(string id, string password)
        {
            gameDataLoader.MakeNewAccountInDB(id, password);
        }

        public void Login(string id, string password)
        {
            gameDataLoader.LoadLoginDataFromDB(id, password);
            
        }

        public void SaveGameData(GameData gameData, bool ShouldSaveForDB)
        {
            this.gameData = gameData;

            if(ShouldSaveForDB)
            {
                gameDataLoader.SetUpdateInDB(gameData);
            }
        }

        public void ResetData()
        {
            gameData.PlayerData = new PlayerData[4];
            gameDataLoader.SetUpdateInDB(gameData);
        }

        public bool CheckedBundleVersion(AssetBundleNumbers bundleNumbers, string assetBundleData)
        {
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
                LogManager.Instance.UserDebug(LogColor.Magenta, "DataManager", "AssetBundle을 위한 Data폴더 생성");
            }
            else
                LogManager.Instance.UserDebug(LogColor.Magenta, "DataManager", "파일이 이미 존재합니다.");


            using (StreamWriter file = new StreamWriter(FilePath))
            {
                FileInfo fileInfo = new FileInfo(FilePath);
                if (!fileInfo.Exists)
                {
                    File.Create(FilePath);
                }
                else
                {

                    string[] lines;
                    lines = File.ReadAllLines(FilePath);
                    for (int i = 0; i < lines.Length; i ++)
                    {
                        
                    }

                }
                
                
            }
            



            return true;
        }

        public void CreateFile()
        {
            string url = Application.dataPath;

        }


    }

}


