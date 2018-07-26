using System.Collections;
using System.Collections.Generic;
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
    private InputState input;
    [SerializeField]
    private InputType inputType;

    private void Awake()
    {
        inputManager = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        input = new MainTitleState();
    }

    /*void InputCurrentState()
    {
        //input.CurrentState();
    }*/

    void ChangeState(InputState inputState)
    {
        input = inputState;
    }

    void TypeState(InputType inputType)
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