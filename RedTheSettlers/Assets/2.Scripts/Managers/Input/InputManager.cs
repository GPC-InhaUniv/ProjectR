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
    private InputState input;
    [SerializeField]
    private InputType inputType;

    private void Awake()
    {
        inputManager = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //input = new BoardGameState();
        TypeState(inputType);
    }

    public void InputDrag(Vector3 direction)
    {
        input.DragMove(direction);
    }

    public void EnterDirectionKey()
    {
        input.DirectionKey();
    }

    public void BattlePhase()
    {

    }

    public void Trade()
    {

    }

    public void TurnEnd()
    {

    }

    private void ChangeState(InputState inputState)
    {
        input = inputState;
    }


    public void TypeState(InputType inputType)
    {
        switch (inputType)
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