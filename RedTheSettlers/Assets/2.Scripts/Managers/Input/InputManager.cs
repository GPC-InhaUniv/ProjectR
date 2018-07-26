using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public enum InputType
{
    Title,
    Board,
    Battle,
    Trade,
    Weather,
}

public class InputManager : Singleton<InputManager>
{
    private static InputManager inputManager;
    private LogManager logManager;
    private InputState input;
    [SerializeField]
    private InputType inputType;

    private void Awake()
    {
        inputManager = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start ()
    {
        //input = new BoardGameState();
        logManager = FindObjectOfType<LogManager>();
        TypeState(inputType);
    }

    private void Update()
    {
        InputMouse();
    }

    // raycast를 InputManager에서 이용하도록 생각중.
    // 그에 따라 State 구현쪽에서 사용하는 raycast는 제거
    private void InputMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkRayPoint;
            if (Physics.Raycast(rayPoint, out checkRayPoint, Mathf.Infinity))
            {
                input.MouseDown(new Vector3(checkRayPoint.point.x,0,checkRayPoint.point.z));
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            input.MouseUp(Vector3.zero);
        }
        else if(Input.GetMouseButton(0))
        {
            Ray dragPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkDragPoint;
            if(Physics.Raycast(dragPoint,out checkDragPoint,Mathf.Infinity))
            {
                input.MouseDrag(new Vector3(checkDragPoint.point.x, 0, checkDragPoint.point.z));
            }
            input.DragMove();
            //LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "흠");
        }
        else if(!Input.GetMouseButton(0))
        {

        }
    }

    private void ChangeState(InputState inputState)
    {
        input = inputState;
    }

    public void TypeState(InputType inputType)
    {
        switch(inputType)
        {
            case InputType.Board:
                ChangeState(new BoardGameState());
                break;
            case InputType.Battle:
                ChangeState(new BattlePhaseState());
                break;
            case InputType.Trade:
                ChangeState(new TradeState());
                break;
            case InputType.Weather:
                ChangeState(new WeatherState());
                break;
            case InputType.Title:
                ChangeState(new MainTitleState());
                break;
        }
    }
}