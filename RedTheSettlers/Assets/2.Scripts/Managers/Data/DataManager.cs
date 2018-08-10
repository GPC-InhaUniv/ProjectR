using System;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{

    [Serializable]
    public struct AssetBundleData
    {
        public Hash128 Player;
        public Hash128 Skill;
        public Hash128 Enemey;
        public Hash128 FirstBoss;
        public Hash128 SecondBoss;
        public Hash128 ThirdBoss;
        public Hash128 UI;
        public Hash128 Tile;
    }
    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
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




    }

}


