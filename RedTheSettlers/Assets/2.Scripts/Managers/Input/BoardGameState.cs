using RedTheSettlers.InputManager;
using RedTheSettlers.LogManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 담당자 박상원
/// State 패턴 구현부
/// Board Game 부분 버튼 기능 및 카메라 이동
/// </summary>
public class BoardGameState : InputState
{
    private Vector3 firstClick;
    private Vector3 mouseDrag;
    private Vector3 dragDirection;
    //public float moveSpeed;

    public override void TouchOrClickButton(InputButtonType inputButtonType)
    {
        switch (inputButtonType)
        {
            case InputButtonType.Battle:
                break;
            case InputButtonType.Trade:
                break;
            case InputButtonType.TurnEnd:
                break;
            case InputButtonType.CharacterState:
                break;
            case InputButtonType.MiniMap:
                break;
            case InputButtonType.Character:
                break;
        }
    }

    public override void DragMove(Vector3 direction)
    {
        TemporaryGameManager.Instance.CameraMove(direction);
        LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "넘어왔나");
    }
}
