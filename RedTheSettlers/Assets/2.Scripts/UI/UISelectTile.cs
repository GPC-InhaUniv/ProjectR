using RedTheSettlers.GameSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// Tile 선택 시, 미개척/개척(플레이어)/개척(AI)인지 체크하고,
/// 해당 값을 출력해 주며 캠프짓기/캠프뺏기/업그레이드가 가능함.
/// </summary>

namespace RedTheSettlers.UI
{
    public class UISelectTile : MonoBehaviour
    {
        [Header("Current Tile Information")]
        [SerializeField]
        private Text tileName;

        [SerializeField]
        private Text tileItemName;

        [SerializeField]
        private Text tileItemLevel;

        [SerializeField]
        private Text tileItemExplain;

        [SerializeField]
        private Text itemAcquireInfomation;

        [Header("Current Owner Image")]
        [SerializeField]
        private GameObject[] tileOwnerImage;

        [Header("Current Item Image")]
        [SerializeField]
        private GameObject[] tileItemImage;

        [Header("Current Tile Event Button")]
        [SerializeField]
        private GameObject[] tileActionButton;

        [Header("test")]
        [SerializeField]
        private int selectTileState;

        [SerializeField]
        private int selectTileName;

        [SerializeField]
        private int selectTileItemLevel;

        [SerializeField]
        private int tileEventButton;

        private void Start()
        {
            checkTileState();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        //input이 나와야 함 ㅠㅠㅠㅠㅠㅠㅠㅠ

        private void checkTileState()
        {
            if (selectTileState == 0) //플레이어 타일
            {
            }

            if (selectTileState == 1) //AI1 타일
            {
            }

            if (selectTileState == 2) //AI2 타일
            {
            }

            if (selectTileState == 3) //AI3 타일
            {
            }
            else //미개척 타일 datamanager에서 값 가져와야 함.
            {
                tileOwnerImage[0].SetActive(true);
                tileItemLevel.text = "Lv." + selectTileItemLevel.ToString();
                tileActionButton[0].SetActive(true);
            }
        }
    }
}