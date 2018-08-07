using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 플레이어의 자원 정보 노출 및
/// 플레이어 소지 가능 자원 정보 bar 형식으로 노출해주는 UI스크립트.
/// [중요] UI Manager 스크립트에서 각 상황별로 처리할 예정.
/// </summary>

namespace RedTheSettlers
{
    namespace UI
    {
        public class UIPlayerHoldResourceController : MonoBehaviour
        {
            [Header("Player's Total Resource")]
            [SerializeField]
            private Text PlayerTotalResource;

            [Header("Player's Resource")]
            [SerializeField]
            private Text PlayerCowResource;

            [SerializeField]
            private Text PlayerWaterResource;

            [SerializeField]
            private Text PlayerWheatResource;

            [SerializeField]
            private Text PlayerWoodResource;

            [SerializeField]
            private Text PlayerIronResource;

            [SerializeField]
            private Text PlayerSoilResource;

            [Header("Total Bar")]
            [SerializeField]
            private Slider totalResourceBar;

            private int cowCardNum;
            private int waterCardNum;
            private int wheatCardNum;
            private int woodCardNum;
            private int ironCardNum;
            private int soilCardNum;
            private float cardmaxNum;

            private int computeResourceNum;

            private void ChangeResource()
            {
                cowCardNum = 10; //test

                PlayerCowResource.text = cowCardNum.ToString(); //test

                //PlayerCowResource.text = gameData.cowcow.ToString();
                //이런식으로 6종류 자원을 gameData에서 가져와서 텍스트에 넣어줘야 함.
            }

            private void ComputeTotalResource()
            {
                cowCardNum = Int32.Parse(PlayerCowResource.text);
                waterCardNum = Int32.Parse(PlayerWaterResource.text);
                wheatCardNum = Int32.Parse(PlayerWheatResource.text);
                woodCardNum = Int32.Parse(PlayerWoodResource.text);
                ironCardNum = Int32.Parse(PlayerIronResource.text);
                soilCardNum = Int32.Parse(PlayerSoilResource.text);

                computeResourceNum = cowCardNum + waterCardNum + wheatCardNum + woodCardNum + ironCardNum + soilCardNum;
                PlayerTotalResource.text = computeResourceNum.ToString();

                totalResourceBar.value = computeResourceNum / cardmaxNum;
            }

            private void Start()
            {
                cardmaxNum = 50;
                ChangeResource();
                ComputeTotalResource();
            }

            private void Update()
            {
            }
        }
    }
}