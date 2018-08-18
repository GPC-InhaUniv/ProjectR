using RedTheSettlers.GameSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 강다희
/// 날씨카드 등장 시 랜덤으로 받은 이미지가 좌우로 배치되며,
/// 선택 시 나머지 카드들이 사라지는 연출이 일어남.
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
        private int firstBookedCard;

        private int secondBookedCard;
        private int tiredBookedCard;

        [Serializable]
        private struct ItemImage
        {
            public Button defaultImage;
            public Button cowCardImage;
            public Button waterCardImage;
            public Button wheatCardImage;
            public Button woodCardImage;
            public Button ironCardImage;
            public Button soilCardImage;
        }

        [Header("Select Button")]
        [SerializeField]
        private ItemImage[] itemImage;

        [Header("Card Image Position")]
        [SerializeField]
        private GameObject leftCardImage;

        [SerializeField]
        private GameObject startCardImage;

        [SerializeField]
        private GameObject rightCardImage;

        [SerializeField]
        private GameObject moveLeftImage;

        [SerializeField]
        private GameObject moveRightImage;

        private void ChangeWeatherCard()
        {
            //지용님에게 받아서 랜덤으로 뽑힌 해당 값에 따라 이미지 변경
        }

        private void MoveWeatherCard() //으아악 이동이 안돼 ㅠㅠㅠ
        {
            float moveSpeed = 10 * Time.deltaTime;

            Vector3 leftCardPosition;
            Vector3 startCardPosition;
            Vector3 rightCardPosition;

            leftCardPosition = leftCardImage.transform.position;
            startCardPosition = startCardImage.transform.position;
            rightCardPosition = rightCardImage.transform.position;

            moveLeftImage.transform.position = Vector3.MoveTowards(startCardPosition, leftCardPosition, moveSpeed);
        }

        private void OnClickWeatherCard()
        {
        }

        private void Start()
        {
            MoveWeatherCard();
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}