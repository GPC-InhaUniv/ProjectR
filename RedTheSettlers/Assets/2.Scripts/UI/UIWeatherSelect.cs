using RedTheSettlers.GameSystem;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 날씨이벤트 등장 시 랜덤으로 받은 카드 3장이 배치되며,
/// 선택 시 나머지 카드들이 사라짐.
/// </summary>

namespace RedTheSettlers.UI
{
    public class UIWeatherSelect : MonoBehaviour
    {
        [Header("Select Button")]
        [SerializeField]
        private Button selectImageButton;

        [Header("Booked Card")]
        [SerializeField]
        private GameObject firstCardImage;

        [SerializeField]
        private GameObject secondCardImage;

        [SerializeField]
        private GameObject thirdCardImage;

        [Serializable]
        private struct ItemImage
        {
            public GameObject goodEventCowCardImage;
            public GameObject goodEventWaterCardImage;
            public GameObject goodEventWheatCardImage;
            public GameObject goodEventWoodCardImage;
            public GameObject goodEventIronCardImage;
            public GameObject goodEventSoilCardImage;
            public GameObject badEventCowCardImage;
            public GameObject badEventWaterCardImage;
            public GameObject badEventWheatCardImage;
            public GameObject badEventWoodCardImage;
            public GameObject badEventIronCardImage;
            public GameObject badEventSoilCardImage;
        }

        [Header("Select Button")]
        [SerializeField]
        private ItemImage[] itemImage;

        [Header("Card Image Position")]
        [SerializeField]
        private GameObject leftCardImage;

        [SerializeField]
        private GameObject middleCardImage;

        [SerializeField]
        private GameObject rightCardImage;

        private float speed = 1000f;

        private int leftCardNum;

        private void ChangeWeatherCard(int[] SelectCards)
        {
            GameObject[] itemImages = new GameObject[12]; //흐아악 못하겠다아아

            if (leftCardNum == 0)
            {
                leftCardImage = itemImage[0].goodEventCowCardImage; //지용님이 넘겨주신 값 넣어주면 댐 itemImage[0].goodEventCowCardImage; 여기
                itemImage[0].goodEventWaterCardImage = leftCardImage;
                //지용님에게 받아서 랜덤으로 뽑힌 해당 값에 따라 이미지 변경
            }
        }

        private void MoveWeatherCard() //코루틴으로 바꾸면 더 부드러울텐데..
        {
            float moveSpeed = 800 * Time.deltaTime;

            Vector3 leftCardPosition;
            Vector3 middleCardPosition;
            Vector3 rightCardPosition;

            leftCardPosition = leftCardImage.transform.position;
            middleCardPosition = middleCardImage.transform.position;
            rightCardPosition = rightCardImage.transform.position;

            firstCardImage.transform.position = Vector3.MoveTowards(firstCardImage.transform.position, leftCardPosition, moveSpeed);
            secondCardImage.transform.position = Vector3.MoveTowards(secondCardImage.transform.position, middleCardPosition, moveSpeed);
            thirdCardImage.transform.position = Vector3.MoveTowards(thirdCardImage.transform.position, rightCardPosition, moveSpeed);
        }

        private void OnClickWeatherCard()
        {
        }

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            MoveWeatherCard();
        }
    }
}