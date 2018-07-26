using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 김하정
/// 용도 : 다른 플레이어와 함께하는 트레이드 카드 UI Unit Text.
/// 
/// 다운 카드 불러오기
/// 오브젝트가 꺼졌어도 텍스트 불러오기
/// 아래로 내렸을때 값 표시되게하기
/// 카드 판 범위
/// </summary>
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Range(0, 5)]
    public int Click;   //변수명 바꾸기

    
    private GameObject top_Table;
    private GameObject top_Card_iron;
    private GameObject top_Card_water;
    private GameObject top_Card_wheat;
    private GameObject top_Card_soil;
    private GameObject top_Card_forest;
    private GameObject top_Card_cow;

    private Text top_Card_Iron_Text;
    private Text top_Card_Water_Text;
    private Text top_Card_Wheat_Text;
    private Text top_Card_Soil_Text;
    private Text top_Card_Forest_Text;
    private Text top_Card_Cow_Text;


    private GameObject down_Table;
    private GameObject down_Card_iron;
    private GameObject down_Card_water;
    private GameObject down_Card_wheat;
    private GameObject down_Card_soil;
    private GameObject down_Card_forest;
    private GameObject down_Card_cow;

    private Text down_Card_Iron_Text;
    private Text down_Card_Water_Text;
    private Text down_Card_Wheat_Text;
    private Text down_Card_Soil_Text;
    private Text down_Card_Forest_Text;
    private Text down_Card_Cow_Text;

    private GameObject[] upCardObjectsArray;
    private GameObject[] downCardObjectsArray;
    private Text[] topCardTextArray;
    private int[] giveCardIndexArray;
    private int[] takeCardIndexArray;


    
    private void Start()
    {
        top_Table = GameObject.Find("Top_Table");
        //top_Card_iron = GameObject.Find("Top_Card_iron");
        //top_Card_water = GameObject.Find("Top_Card_water");
        //top_Card_wheat = GameObject.Find("Top_Card_wheat");
        //top_Card_soil = GameObject.Find("Top_Card_soil");
        //top_Card_forest = GameObject.Find("Top_Card_forest");
        //top_Card_cow = GameObject.Find("Top_Card_cow");


        //top_Card_iron = top_Table.transform.FindChild("Top_Card_iron").gameObject;
        //top_Card_water = top_Table.transform.FindChild("Top_Card_water").gameObject;
        //top_Card_wheat = top_Table.transform.FindChild("Top_Card_wheat").gameObject;
        //top_Card_soil = top_Table.transform.FindChild("Top_Card_soil").gameObject;
        //top_Card_forest = top_Table.transform.FindChild("Top_Card_forest").gameObject;
        //top_Card_cow = top_Table.transform.FindChild("Top_Card_cow").gameObject;




        //top_Card_Iron_Text = GameObject.Find("Top_Card_Iron_Text").GetComponent<Text>();
        //top_Card_Water_Text = GameObject.Find("Top_Card_Water_Text").GetComponent<Text>();
        //top_Card_Wheat_Text = GameObject.Find("Top_Card_Wheat_Text").GetComponent<Text>();
        //top_Card_Soil_Text = GameObject.Find("Top_Card_Soil_Text").GetComponent<Text>();
        //top_Card_Forest_Text = GameObject.Find("Top_Card_Forest_Text").GetComponent<Text>();
        //top_Card_Cow_Text = GameObject.Find("Top_Card_Cow_Text").GetComponent<Text>();


        //down_Table = GameObject.Find("Down_Table");
        //down_Card_iron = down_Table.transform.FindChild("Down_Card_iron").gameObject;
        //down_Card_water = down_Table.transform.FindChild("Down_Card_water").gameObject;
        //down_Card_wheat = down_Table.transform.FindChild("Down_Card_wheat").gameObject;
        //down_Card_soil = down_Table.transform.FindChild("Down_Card_soil").gameObject;
        //down_Card_forest = down_Table.transform.FindChild("Down_Card_forest").gameObject;
        //down_Card_cow = down_Table.transform.FindChild("Down_Card_cow").gameObject;

        //top_Card_iron.gameObject.SetActive(false);
        //top_Card_water.gameObject.SetActive(false);
        //top_Card_wheat.gameObject.SetActive(false);
        //top_Card_soil.gameObject.SetActive(false);
        //top_Card_forest.gameObject.SetActive(false);
        //top_Card_cow.gameObject.SetActive(false);
       
        upCardObjectsArray = new GameObject[6]
        {
            top_Card_water ,
            top_Card_cow,
            top_Card_wheat,
            top_Card_iron,
            top_Card_soil ,
            top_Card_forest,

        };

        downCardObjectsArray = new GameObject[6]
        {
            down_Card_water ,
            down_Card_cow,
            down_Card_wheat,
            down_Card_iron,
            down_Card_soil ,
            down_Card_forest

        };

        topCardTextArray = new Text[6]
        {
            top_Card_Water_Text,
            top_Card_Cow_Text,
            top_Card_Wheat_Text,
            top_Card_Iron_Text,
            top_Card_Soil_Text,
            top_Card_Forest_Text,
           
        };

        giveCardIndexArray = new int[6] { 0, 0, 0, 0, 0, 0 };

        takeCardIndexArray = new int[6] { 0, 0, 0, 0, 0, 0 };



    }








    private Transform parentToReturnTo;

    private GameObject placeHolder;

    public void OnBeginDrag(PointerEventData eventData)
    {

        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);

        LayoutElement layoutElement = placeHolder.AddComponent<LayoutElement>();    //더미 카드 오브젝트인 placeHolder에 card와 같이 LayoutElement를 붙여준다.(카드 크기와 똑같이 만들기 위하여)
        layoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;   //카드 오브젝트의 layout Element컴포넌트의 값을 더미 오브젝트의 layout element 컴포넌트에 넣어준다.
        layoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        layoutElement.flexibleWidth = 0;
        layoutElement.flexibleHeight = 0;

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());//더미오브젝트의 하이라키 인덱스를 현재 오브젝트의 하이라키 인덱스로 해준다.

        parentToReturnTo = this.transform.parent; //순서조심
        this.transform.SetParent(this.transform.parent.parent);

        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        int newSiblingIndex = parentToReturnTo.childCount;  //왜 카드개수가 +1로 나오는걸까?????

        for (int i = 0; i < parentToReturnTo.childCount; i++)   //Transform.childCount :  트랜스폼이 가진 자식 트랜스폼의 수를 나타냅니다. 
        {
            if (this.transform.position.x < parentToReturnTo.GetChild(i).transform.position.x)
            {
                newSiblingIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }

                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo); //오브젝트의 Parent를 정해주는 메소드
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex()); //카드를 놓았을때 카드의 순서가 바뀌지 않도록 더미 오브젝트의 하이라키 인덱스 값을 넣어준다.
        ////GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeHolder);

        /////////////////////////////////////

        for (int i = 0; i <= 5; i++)
        {
            if (Click == i)
            {

                if (this.transform.position.y >= top_Table.transform.position.y - top_Table.GetComponent<RectTransform>().rect.height /2 )
                {
                    upCardObjectsArray[i].gameObject.SetActive(true);


                    giveCardIndexArray[i] += 1;
                    //topCardTextArray[i].text = giveCardIndexArray[i].ToString();
                    Debug.Log(upCardObjectsArray[i].name + "는" + giveCardIndexArray[i] + "개");

                }
                else if (this.transform.position.y <= down_Table.transform.position.y + down_Table.GetComponent<RectTransform>().rect.height /2)
                {
                    downCardObjectsArray[i].gameObject.SetActive(true);
                    takeCardIndexArray[i] += 1;
                   
                    Debug.Log("내가 원하는 자원카드" + downCardObjectsArray[i].name + "는" + takeCardIndexArray[i] + "개");
                }

                //카드가 중간에 들어오면 빼줘야함.
                if (this.transform.position.y <= top_Table.transform.position.y
                    && this.transform.position.y >= top_Table.transform.position.y - top_Table.GetComponent<RectTransform>().rect.height / 2)
                {

                    giveCardIndexArray[i] -= 1;
                    //topCardTextArray[i].text = (Mathf.Clamp(giveCardIndexArray[i], 0, 100)).ToString();
                    Debug.Log(upCardObjectsArray[i].name + "는" + giveCardIndexArray[i] + "개");
                }
                else if (this.transform.position.y <= down_Table.transform.position.y
                    && this.transform.position.y >= down_Table.transform.position.y + down_Table.GetComponent<RectTransform>().rect.height /2)
                {

                    takeCardIndexArray[i] -= 1;

                    Debug.Log("내가 원하는 자원카드" + downCardObjectsArray[i].name + "는" + takeCardIndexArray[i] + "개");
                }

                Debug.Log(Click);
            }

        }


    }



}



