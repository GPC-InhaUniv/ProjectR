using RedTheSettlers.Tiles;
using RedTheSettlers.Users;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RedTheSettlers.GameSystem
{
    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class DifficultyController : MonoBehaviour
    {
        private BattleLevel level;
        private ItemType tileType;


        public void SendBattleLevel(Tile selectionTile, List<Tile> PossessingTileList)
        {
            judgeLevel(selectionTile, PossessingTileList);
            //TileManager.Method(level, tileType) 로 넘길예정.
        }

        private void judgeLevel(Tile selectionTile, List<Tile> PossessingTileList)
        {
            tileType = selectionTile.TileType;
            int count = 0;
            for (int i = 0; i < PossessingTileList.Count; i++)
            {
                if (PossessingTileList[i].TileType == selectionTile.TileType)
                    count++;
            }
            if (count < 2)
            {
                level = BattleLevel.Level1;
            }
            else if (count == 2 || count == 3)
            {
                level = BattleLevel.Level2;
            }
            else
                level = BattleLevel.Level3;
        } 
        


        /*
        DifficultyController가 해야할 일.
        1. 소유 타일에 따라 정해진 난이도를 타일 매니저에 보내줌.

        2. 플레이어가 소유하고 있는 동일한 타일 갯수마다 몬스터 스탯 및 수 증가.

        3. 보스타일일 경우엔 선택 타일이 아닌 랜덤으로 타일이 배치됨
         - 소,물,밀,철,흙,나무 중 아무거나
         - 보스의 위치는 고정.

         */
    }
}
