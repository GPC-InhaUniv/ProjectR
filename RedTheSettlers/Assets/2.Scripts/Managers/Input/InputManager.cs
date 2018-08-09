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
        EquipSkillInMainStageState,
        WeatherInMainStageState,
    }
    // 추후 버튼 명칭 확정 후 그에 맞춰 수정
    public enum InputButtonType
    {
        PressToStart,
        SignUp,
        Login,
        Option,
        Battle,
        Trade,
        TurnEnd,
        Status,
        Map,
        EquipAndSkill,
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
        [SerializeField,Range(1,100)]
        private float moveSpeed;
        [SerializeField,Range(1,100)]
        private float zoomSpeed;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            //input = new MainTitleState();
            TypeState(stateType);
        }

        private void Update()
        {
            if(enableInputKey)
            {
                InteractionKey();
            }
            if(!enableInputKey)
            {
                MainStageDragAndZoom();
            }
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

        public void MainStageDragAndZoom()
        {
            input.DragMove(moveSpeed);
            input.ZoomOrOut(zoomSpeed);
        }

        public void OnBeginDrag()
        {
            input.OnStartDrag();
        }

        public void OnDrag()
        {
            input.OnDragging();
        }

        public void EndDrag()
        {
            input.EndStopDrag();
        }

        public void OnDrop()
        {
            input.OnDropOff();
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
                default:
                    LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "해당되는 상태가 존재하지 않습니다.");
                    break;
            }
        }
    }
}