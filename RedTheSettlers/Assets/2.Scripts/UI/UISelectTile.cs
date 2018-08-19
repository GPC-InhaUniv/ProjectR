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

        [Serializable]
        private struct TileOwnerImage
        {
            public GameObject tilePlayerImage;
            public GameObject tileAIFirstImage;
            public GameObject tileAISecondImage;
            public GameObject tileAIThirdImage;
            public GameObject tileUnexploredImage;
        }

        [SerializeField]
        private TileOwnerImage[] tileOwnerImage;

        [Header("Current Item Image")]
        [SerializeField]
        private GameObject[] tileItemImage;

        [Header("Current Tile Event Button")]
        [SerializeField]
        private GameObject[] tileActionButton;

        [Header("test")]
        [SerializeField]
        private int selectTileOwner;

        [SerializeField]
        private int selectTileProperties;

        [SerializeField]
        private int selectTileName;

        [SerializeField]
        private int selectTileItemLevel;

        private void Start()
        {
            OnTileInformation();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void CheckTilePossession()
        {
            if (selectTileOwner == 0) //플레이어 타일
            {
                tileOwnerImage[0].tilePlayerImage.SetActive(true);
                tileActionButton[0].SetActive(true);
            }
            else if (selectTileOwner == 1) //AI1 타일
            {
                tileOwnerImage[0].tileAIFirstImage.SetActive(true);
                tileActionButton[1].SetActive(true);
            }
            else if (selectTileOwner == 2) //AI2 타일
            {
                tileOwnerImage[0].tileAISecondImage.SetActive(true);
                tileActionButton[1].SetActive(true);
            }
            else if (selectTileOwner == 3) //AI3 타일
            {
                tileOwnerImage[0].tileAIThirdImage.SetActive(true);
                tileActionButton[1].SetActive(true);
            }
            else //미개척 타일
            {
                tileOwnerImage[0].tileUnexploredImage.SetActive(true);
                tileActionButton[2].SetActive(true);
            }
        }

        private void CheckTileProperties()
        {
            switch (selectTileProperties) //물 , 밀, 소, 나무, 철, 흙
            {
                case 0:
                    {
                        tileItemName.text = "물";
                    }
                    break;

                case 1:
                    {
                        tileItemName.text = "밀";
                    }
                    break;

                case 2:
                    {
                        tileItemName.text = "소";
                    }
                    break;

                case 3:
                    {
                        tileItemName.text = "나무";
                    }
                    break;

                case 4:
                    {
                        tileItemName.text = "철";
                    }
                    break;

                case 5:
                    {
                        tileItemName.text = "흙";
                    }
                    break;
            }
        }

        private void OnTileInformation()
        {
            //input으로 타일을 선택 했을 때, 뜨는 ... (setActive로 캔버스창도 떠야 함)
            CheckTilePossession();
            CheckTileProperties();

            tileItemLevel.text = "Lv." + selectTileItemLevel.ToString();
        }

        private void OnButton() //버튼 배열 0플레이어 1AI 2미개척
        {
        }
    }
}