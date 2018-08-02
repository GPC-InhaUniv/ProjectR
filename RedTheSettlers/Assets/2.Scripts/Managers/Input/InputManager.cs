using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public enum StateType
{
    TitleState,
    BoardState,
    BattleState,
    TradeState,
    WeatherState,
}

public enum InputButtonType
{
    GameStart,
    Option,
    Battle,
    Trade,
    TurnEnd,
    CharacterState,
    MiniMap,
    Character,
    Attack,
    Skill1,
    Skill2,
    Skill3,
    Item1,
    Item2,
    Pause,
}

public class InputManager : Singleton<InputManager>
{
    private static InputManager inputManager;

    private InputState input;
    [SerializeField]
    private StateType stateType;
    private Vector3 moveDirection;
    private bool enableInputKey = false;
    private float inputDelay = 0.1f;
    private float maxInputDelay = 0.04f;
    Queue<KeyCode> inputs = new Queue<KeyCode>();

    private void Awake()
    {
        inputManager = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //input = new BoardGameState();
        TypeState(stateType);
    }

    private void FixedUpdate()
    {
        if (enableInputKey)
        {
            EnterDirectionKey();
        }
    }

    public void InputButton(InputButtonType inputButtonType)
    {
        input.TouchOrClickButton(inputButtonType);
    }

    public void InputDrag(Vector3 direction)
    {
        input.DragMove(direction);
    }

    public void InputTrade(Vector3 position)
    {
        input.UIMover(position);
    }

    // 쓰레기 코드 대대적 수정 예정
    private void EnterDirectionKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputs.Enqueue(KeyCode.UpArrow);
            moveDirection = Vector3.forward;
            input.DirectionKey(moveDirection);
            transform.TransformDirection(Vector3.forward);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveDirection = Vector3.zero;
            input.DirectionKey(moveDirection);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputs.Enqueue(KeyCode.DownArrow);
            moveDirection = Vector3.back;
            input.DirectionKey(moveDirection);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveDirection = Vector3.zero;
            input.DirectionKey(moveDirection);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputs.Enqueue(KeyCode.LeftArrow);
            moveDirection = Vector3.left;
            input.DirectionKey(moveDirection);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveDirection = Vector3.zero;
            input.DirectionKey(moveDirection);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputs.Enqueue(KeyCode.RightArrow);
            moveDirection = Vector3.right;
            input.DirectionKey(moveDirection);
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveDirection = Vector3.zero;
            input.DirectionKey(moveDirection);
        }
        if (inputs.Contains(KeyCode.RightArrow) && inputs.Contains(KeyCode.UpArrow))
        {
            LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, inputs.Peek());
        }
        else
        {
            inputs.Clear();
        }
    }

    private void InputTimer()
    {
        inputDelay += 0.01f;
    }

    private void ChangeState(InputState inputState)
    {
        input = inputState;
    }

    public void TypeState(StateType stateType)
    {
        switch (stateType)
        {
            case StateType.BoardState:
                ChangeState(new BoardGameState());
                enableInputKey = false;
                break;
            case StateType.BattleState:
                ChangeState(new BattlePhaseState());
                enableInputKey = true;
                break;
            case StateType.TradeState:
                ChangeState(new TradeState());
                enableInputKey = false;
                break;
            case StateType.WeatherState:
                ChangeState(new WeatherState());
                enableInputKey = false;
                break;
            case StateType.TitleState:
                ChangeState(new MainTitleState());
                enableInputKey = false;
                break;
        }
    }
}