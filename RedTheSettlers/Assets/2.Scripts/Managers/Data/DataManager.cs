using System;
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
        private string fileName;
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
            switch(bundleNumbers)
            {
                case AssetBundleNumbers.Player:
                    fileName = Application.dataPath + "/PlayerBundle.txt";
                    break;
                case AssetBundleNumbers.Skill:
                    fileName = Application.dataPath + "/SkillBundle.txt";
                    break;
                case AssetBundleNumbers.Enemy:
                    fileName = Application.dataPath + "/EnemyBundle.txt";
                    break;
                case AssetBundleNumbers.MiddleBoss1:
                    fileName = Application.dataPath + "/MiddleBoss1Bundle.txt";
                    break;
                case AssetBundleNumbers.MiddleBoss2:
                    fileName = Application.dataPath + "/MiddleBoss2Bundle.txt";
                    break;
                case AssetBundleNumbers.Boss:
                    fileName = Application.dataPath + "/BossBundle.txt";
                    break;
                case AssetBundleNumbers.Tile:
                    fileName = Application.dataPath + "/TileBundle.txt";
                    break;
                case AssetBundleNumbers.UI:
                    fileName = Application.dataPath + "/UIBundle.txt";
                    break;
            }



            return true;
        }

        public void CreateFile()
        {
            string url = Application.dataPath;

        }


    }

}


