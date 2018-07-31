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

    public void EnterDirectionKey()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection = Vector3.forward;
            input.DirectionKey(moveDirection);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection = Vector3.back;
            input.DirectionKey(moveDirection);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = Vector3.left;
            input.DirectionKey(moveDirection);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = Vector3.right;
            input.DirectionKey(moveDirection);
        }
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
                enableInputKey = true;
                break;
            case StateType.BattleState:
                ChangeState(new BattlePhaseState());
                enableInputKey = true;
                break;
            case StateType.TradeState:
                ChangeState(new TradeState());
                enableInputKey = true;
                break;
            case StateType.WeatherState:
                ChangeState(new WeatherState());
                enableInputKey = true;
                break;
            case StateType.TitleState:
                ChangeState(new MainTitleState());
                enableInputKey = true;
                break;
        }
    }
}