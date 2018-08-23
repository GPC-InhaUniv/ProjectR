using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// 화면 또는 아이콘 드래그, 이동 방향 전달, UI 버튼 입력시
/// 해당 UI 버튼 해야 하는 일을 받아서 전달
/// 최대한 커밋시 다른 코드와 오류가 나지 않도록 구조 수정 중
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
    /*public enum InputButtonType
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
    }*/

    public class InputManager : Singleton<InputManager>
    {
        private IInputState inputState;

        [SerializeField]
        private StateType stateType;
        private bool enableInputKey = false;
        private bool enableInputCameraDrag = false;
        [SerializeField, Range(1, 100)]
        private float moveSpeed;
        [SerializeField, Range(1, 100)]
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
            if (enableInputKey)
            {
                InteractionKey();
            }
            if (!enableInputKey && enableInputCameraDrag)
            {
                CameraZoomInOut();
                RayHitInfo();
            }
        }

        private void FixedUpdate()
        {
            if (enableInputKey)
            {
                EnterDirectionKey();
            }
        }

        /*public void InputButton(InputButtonType inputButtonType)
        {
            inputState.TouchOrClickButton(inputButtonType);
        }*/

        public void CameraZoomInOut()
        {
#if UNITY_EDITOR
            inputState.ZoomInOut(zoomSpeed);
#endif
#if UNITY_STANDALONE_WIN
            inputState.ZoomInOut(zoomSpeed);
#endif
#if UNITY_ANDROID
            LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "테스트");
#endif
        }

        public void OnBeginDrag()
        {
            inputState.OnStartDrag();
        }

        public void OnDrag()
        {
            inputState.OnDragging(moveSpeed);
        }

        public void EndDrag()
        {
            inputState.EndStopDrag();
        }

        public void OnDrop()
        {
            inputState.OnDropSlot();
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

            inputState.DirectionKey(moveDirection);
        }

        private void InteractionKey()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                inputState.BattleAttack();
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputState.SkillDirection();
            }
        }

        private void RayHitInfo()
        {
            inputState.TileInfo();
        }

        private void ChangeState(IInputState state)
        {
            inputState = state;
        }

        public void TypeState(StateType stateType)
        {
            switch (stateType)
            {
                case StateType.MainStageState:
                    ChangeState(new MainStageState());
                    enableInputKey = false;
                    enableInputCameraDrag = true;
                    break;
                case StateType.BattleStageState:
                    ChangeState(new BattleStageState());
                    enableInputKey = true;
                    enableInputCameraDrag = false;
                    break;
                case StateType.TradeInMainStageState:
                    ChangeState(new TradeInMainStageState());
                    enableInputKey = false;
                    enableInputCameraDrag = false;
                    break;
                case StateType.TitleStageState:
                    ChangeState(new TitleStageState());
                    enableInputKey = false;
                    enableInputCameraDrag = false;
                    break;
                case StateType.EquipSkillInMainStageState:
                    ChangeState(new EquipSkillInMainStageState());
                    enableInputKey = false;
                    enableInputCameraDrag = false;
                    break;
                default:
                    LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "해당되는 상태가 존재하지 않습니다.");
                    break;
            }
        }
    }
}