using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// 화면 또는 아이콘 드래그, 이동 방향 전달, UI 버튼 입력시
/// 해당 UI 버튼 해야 하는 일을 받아서 전달
/// </summary>
namespace RedTheSettlers.GameSystem
{
    public enum StateType
    {
        TitleStageState,
        MainStageState,
        BattleStageState,
        TradeInMainStageState,
        WeatherInMainStageState,
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
        private InputState input;

        [SerializeField]
        private StateType stateType;
        private bool enableInputKey = false;

        private void Awake()
        {
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

        public void OnBeginDrag()
        {
            input.OnBeginDragUI();
        }

        public void OnDrag()
        {
            input.OnDragUI();
        }

        public void EndDrag()
        {
            input.EndDragUI();
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
            if (Input.GetKey(KeyCode.Z))
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
                case StateType.MainStageState:
                    ChangeState(new MainStageState());
                    enableInputKey = false;
                    break;
                case StateType.BattleStageState:
                    ChangeState(new BattleStageState());
                    enableInputKey = true;
                    break;
                case StateType.TradeInMainStageState:
                    ChangeState(new TradeInMainStageState());
                    enableInputKey = false;
                    break;
                case StateType.WeatherInMainStageState:
                    ChangeState(new WeatherInMainStageState());
                    enableInputKey = false;
                    break;
                case StateType.TitleStageState:
                    ChangeState(new TitleStageState());
                    enableInputKey = false;
                    break;
            }
        }
    }
}