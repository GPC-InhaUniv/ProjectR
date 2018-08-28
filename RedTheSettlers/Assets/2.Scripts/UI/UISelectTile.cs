using RedTheSettlers.GameSystem;
using RedTheSettlers.Tiles;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// Tile 선택 시, 미개척/개척(플레이어)/개척(AI)인지 체크하고,
/// 해당 값을 출력해 주며 캠프짓기/캠프뺏기/업그레이드가 가능함.
///
/// [참고] 타일을 인풋으로 선택 했을 때 UI가 setactive되는 것은 UIManager에서 해야함.
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

        [Serializable]
        private struct TileItemImage
        {
            public GameObject cowTileImage;
            public GameObject waterTileImage;
            public GameObject wheatTileImage;
            public GameObject woodTileImage;
            public GameObject ironTileImage;
            public GameObject soilTileImage;
        }

        [SerializeField]
        private TileItemImage[] tileItemImage;

        [Header("Current Tile Event Button")]
        [SerializeField]
        private GameObject[] tileActionButton;

        [Header("test")]
        [SerializeField]
        private int selectTileOwner;

        [SerializeField]
        private int selectTileProperties;

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
            switch (selectTileProperties) //소,물,밀,나무,철,흙
            {
                case 0:
                    {
                        tileName.text = "목축지";
                        tileItemName.text = "소";
                        tileItemImage[0].cowTileImage.SetActive(true);
                        itemAcquireInfomation.text = "'소'는 배고픔(HP)를 채워줍니다.";
                    }
                    break;

                case 1:
                    {
                        tileName.text = "오아시스";
                        tileItemName.text = "물";
                        tileItemImage[0].waterTileImage.SetActive(true);
                        itemAcquireInfomation.text = "'물'은 갈증(MP)를 채워줍니다.";
                    }
                    break;

                case 2:
                    {
                        tileName.text = "밀밭";
                        tileItemName.text = "밀";
                        tileItemImage[0].wheatTileImage.SetActive(true);
                        itemAcquireInfomation.text = "'밀'은 스테미나(Move)를 채워줍니다.";
                    }
                    break;

                case 3:
                    {
                        tileName.text = "숲";
                        tileItemName.text = "나무";
                        tileItemImage[0].woodTileImage.SetActive(true);
                        itemAcquireInfomation.text = "'나무'는 업그레이드에 필요합니다.";
                    }
                    break;

                case 4:
                    {
                        tileName.text = "돌산";
                        tileItemName.text = "철";
                        tileItemImage[0].ironTileImage.SetActive(true);
                        itemAcquireInfomation.text = "'철'은 업그레이드에 필요합니다.";
                    }
                    break;

                case 5:
                    {
                        tileName.text = "흙산";
                        tileItemName.text = "흙";
                        tileItemImage[0].soilTileImage.SetActive(true);
                        itemAcquireInfomation.text = "'흙'은 업그레이드에 필요합니다.";
                    }
                    break;
            }
        }

        public void SetSelectTileInfo(BoardTile selectionTile)
        {
            selectTileProperties = (int)selectionTile.TileType;
            selectTileOwner = (int)selectionTile.tileOwner;
            selectTileItemLevel = selectionTile.TileLevel;
        }

        private void OnTileInformation()
        {
            CheckTilePossession();
            CheckTileProperties();

            tileItemLevel.text = "Lv." + selectTileItemLevel.ToString();
        }

        private void OnButton() //버튼 배열 0플레이어 1AI 2미개척
        {
        }
    }
}