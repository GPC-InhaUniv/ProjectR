using RedTheSettlers.Players;
using System.Collections.Generic;
using RedTheSettlers.Tiles;

namespace RedTheSettlers.GameSystem
{
    /// <summary>
    /// 각 컨트롤러를 관리하고 중재하는 매니저
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        /*
        각 플레이어(보드4 + 전투1)를 가지고 있음

        컨트롤러로 부터 작업이 끝났다는 요청를 받는다.
        다음 컨트롤러로 작업을 넘겨준다.
        이 과정에서 데이터와 연동
        
        임시적 데이터 저장 및 ui 매니저로의 전달(presenter)
         */
        public List<TileData>[] PlayerCowTileData;
        public List<TileData>[] PlayerIronTileData;
        public List<TileData>[] PlayerSoilTileData;
        public List<TileData>[] PlayerWaterTileData;
        public List<TileData>[] PlayerWheatTileData;
        public List<TileData>[] PlayerWoodTileData;

        private void Start()
        {
            //각 자원별 타일 분류
            PlayerCowTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerIronTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerSoilTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerWaterTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerWheatTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
            PlayerWoodTileData = new List<TileData>[GlobalVariables.maxPlayerNumber];
        }

        /// <summary>
        /// 모든 타일을 검색해서 각 플레이어가 가진 타일을 자원별로 분류합니다.
        /// </summary>
        /// <param name="playerNumber"></param>
        public void SortItemList(int playerNumber)
        {
            for (int i = 0; i < DataManager.Instance.GameData.PlayerData[playerNumber].TileList.Count; i++)
            {
                if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Cow)
                {
                    PlayerCowTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Iron)
                {
                    PlayerIronTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Soil)
                {
                    PlayerSoilTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Water)
                {
                    PlayerWaterTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Wheat)
                {
                    PlayerWheatTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
                else if (DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i].TileType == ItemType.Wood)
                {
                    PlayerWoodTileData[playerNumber].Add(DataManager.Instance.GameData.PlayerData[playerNumber].TileList[i]);
                }
            }
        }
    }
}


