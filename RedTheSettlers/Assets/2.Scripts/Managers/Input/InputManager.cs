using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public enum StateType
{
    TitleStage,
    MainStage,
    BattleStage,
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
    private bool enableInputKey = false;

    private void Awake()
    {
        inputManager = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //input = new MainTitleState();
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

    // 아직 Trade 쪽에 무엇을 전달해야 할지 정해지지 않아
    // 임의로 매개변수 지정
    public void InputTrade(Vector3 position)
    {
        input.UIMover(position);
    }

    private void EnterDirectionKey()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += Vector3.right;
        }

        input.DirectionKey(moveDirection);
    }

    private void InteractionKey()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            input.BattleAttack();
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
            case StateType.MainStage:
                ChangeState(new BoardGameState());
                enableInputKey = false;
                break;
            case StateType.BattleStage:
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
            case StateType.TitleStage:
                ChangeState(new MainTitleState());
                enableInputKey = false;
                break;
        }
    }
}