using RedTheSettlers.GameSystem;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.UnitTest;

/// <summary>
/// 작성자 : 강다희
/// 날씨이벤트 등장 시 랜덤으로 받은 카드 3장이 배치되며,
/// 선택 시 나머지 카드들이 사라짐.
/// </summary>

namespace RedTheSettlers.UI
{
    public class UIWeatherSelect : MonoBehaviour
    {
        private EventControllerTest2 eventControllerTest2; //게임매니저 함수 구현 시 삭제 예정

        [SerializeField]
        private GameObject[] EventItemCardImage;

        [Header("Card Image Position")]
        [SerializeField]
        private GameObject leftCardImage;

        [SerializeField]
        private GameObject middleCardImage;

        [SerializeField]
        private GameObject rightCardImage;

        [SerializeField]
        private GameObject cardPositionGroup;

        private int[] eventArray;
        private GameObject[] selectedCard;
        private int eventNumber;

        public float smoothing = 1f;

        private void Start()
        {
            eventControllerTest2 = GetComponent<EventControllerTest2>();  //게임매니저 함수 구현 시 삭제 예정
            selectedCard = new GameObject[3];
            ChangeWeatherCard();
            StartCoroutine(MoveWeatherCard());
        }

        public void ChangeWeatherCard()
        {
            eventArray = eventControllerTest2.PickWeatherEvent();  //게임매니저 함수 구현 시 삭제 예정

            for (int i = 0; i < eventArray.Length; i++)
            {
                selectedCard[i] = EventItemCardImage[eventArray[i]];
                selectedCard[i].SetActive(true);
            }
        }

        private IEnumerator MoveWeatherCard()
        {
            while (true)
            {
                float moveSpeed = 800 * Time.deltaTime;

                Vector3 leftCardPosition;
                Vector3 middleCardPosition;
                Vector3 rightCardPosition;

                leftCardPosition = leftCardImage.transform.position;
                middleCardPosition = middleCardImage.transform.position;
                rightCardPosition = rightCardImage.transform.position;

                selectedCard[0].transform.position = Vector3.MoveTowards(selectedCard[0].transform.position, leftCardPosition, moveSpeed);
                selectedCard[1].transform.position = Vector3.MoveTowards(selectedCard[1].transform.position, middleCardPosition, moveSpeed);
                selectedCard[2].transform.position = Vector3.MoveTowards(selectedCard[2].transform.position, rightCardPosition, moveSpeed);

                if (selectedCard[0].transform.position == leftCardPosition)
                {
                    break;
                }
                yield return null;
            }
        }

        public void OnClickWeatherCard(int Count)
        {
            if (selectedCard[0].transform.position == leftCardImage.transform.position)
            {
                if (Count == 0)
                {
                    Debug.Log("left");
                    eventNumber = eventArray[Count];
                    cardPositionGroup.SetActive(false);
                    selectedCard[1].SetActive(false);
                    selectedCard[2].SetActive(false);
                }
                else if (Count == 1)
                {
                    Debug.Log("middle");
                    eventNumber = eventArray[Count];
                    cardPositionGroup.SetActive(false);
                    selectedCard[0].SetActive(false);
                    selectedCard[2].SetActive(false);
                }
                else if (Count == 2)
                {
                    Debug.Log("right");
                    eventNumber = eventArray[Count];
                    cardPositionGroup.SetActive(false);
                    selectedCard[0].SetActive(false);
                    selectedCard[1].SetActive(false);
                }
                Invoke("SendEventNumber", 3.0f);
            }
        }

        public void SendEventNumber()
        {
            //UIManager.Instance.~~~(eventNumber);
        }
    }
}