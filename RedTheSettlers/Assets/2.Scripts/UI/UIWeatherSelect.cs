using RedTheSettlers.GameSystem;
using System;
using System.Collections;
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
        private GameObject firstCardImage;

        [SerializeField]
        private GameObject secondCardImage;

        [SerializeField]
        private GameObject thirdCardImage;

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

        private float speed = 1000f;


        private void ChangeWeatherCard()
        {
            //지용님에게 받아서 랜덤으로 뽑힌 해당 값에 따라 이미지 변경
        }

        private void MoveWeatherCard()
        {
            float moveSpeed = 800 * Time.deltaTime;

            Vector3 leftCardPosition;
            Vector3 middleCardPosition;
            Vector3 rightCardPosition;

            leftCardPosition = leftCardImage.transform.position;
            middleCardPosition = startCardImage.transform.position;
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
            //StartCoroutine(StartCoroutine());
        }

        IEnumerator StartCoroutine()
        {
            while (true)
            {

            }

            yield break;
        }

        // Update is called once per frame
        private void Update()
        {
            MoveWeatherCard();
        }
    }
}