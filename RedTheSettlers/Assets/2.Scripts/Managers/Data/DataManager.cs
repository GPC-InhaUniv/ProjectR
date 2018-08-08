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
        public GameData GameData;

        private GameDataLoader gameDataLoader;
        // Use this for initialization
        void Awake()
        {

            GameData = new GameData(4);
            gameDataLoader = new GameDataLoader();
            string json = JsonUtility.ToJson(GameData);
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

        public void SaveGameData()
        {
            GameData.PlayerData[0].ResourceData.SoilNumber = 10;
            GameData.PlayerData[1].ResourceData.IronNumber = 7;
            GameData.PlayerData[2].ResourceData.WaterNumber = 5;
            GameData.PlayerData[3].ResourceData.WheatNumber = 20;
            gameDataLoader.SetUpdateInDB(GameData);
        }

        public void ResetData()
        {
            ItemData resource = new ItemData
            {
                IronNumber = 1
            };
            GameData.PlayerData[0].ResourceData = resource;
            GameData.PlayerData = new PlayerData[4];
            gameDataLoader.SetUpdateInDB(GameData);

        }

    }

}


