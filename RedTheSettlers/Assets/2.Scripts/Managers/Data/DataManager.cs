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
            bool cyheck = CheckedBundleVersion(AssetBundleNumbers.Player, "01024fadg3b");
            Debug.Log(cyheck);
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

            if (ShouldSaveForDB)
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
            string versionData = stringWrite(bundleNumbers, assetBundleData);
            
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
                LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "AssetBundle을 위한 Data폴더 생성");
            }
            else
                LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "파일이 이미 존재합니다.");
            FileInfo fileInfo = new FileInfo(FilePath);
            if (!fileInfo.Exists)
            {
                File.Create(FilePath);
            }
            string[] lines;
            lines = File.ReadAllLines(FilePath);
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {

                if (lines.Length - 1 < (int)bundleNumbers)
                {
                    writer.Write(versionData);
                    LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "기록된 정보가 없으므로 새로 적습니다,");
                    return true;
                }
                else
                {
                    if (lines[(int)bundleNumbers].Equals(versionData))
                    {
                        writer.Write(versionData);
                        LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "기록된 정보와 다르므로 업데이트 요망.");
                        return false;
                    }
                }
            }
            LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "기록된 정보와 일치. 업데이트 필요없음");
            return true;
        }

        public string stringWrite(AssetBundleNumbers bundleNumbers, string assetBundleData)
        {
            switch (bundleNumbers)
            {

                case AssetBundleNumbers.Player:
                    return assetBundleData;
                case AssetBundleNumbers.Skill:
                    return "\n" + assetBundleData;
                case AssetBundleNumbers.Enemy:
                    return "\n\n" + assetBundleData;
                case AssetBundleNumbers.MiddleBoss1:
                    return "\n\n\n" + assetBundleData;
                case AssetBundleNumbers.MiddleBoss2:
                    return "\n\n\n\n" + assetBundleData;
                case AssetBundleNumbers.Boss:
                    return "\n\n\n\n\n" + assetBundleData;
                case AssetBundleNumbers.Tile:
                    return "\n\n\n\n\n\n" + assetBundleData;
                default:
                    return "\n\n\n\n\n\n\n" + assetBundleData;
            }
        }



    }

}


