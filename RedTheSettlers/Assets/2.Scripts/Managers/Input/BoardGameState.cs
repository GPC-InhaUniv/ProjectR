using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RedTheSettlers
{
    public class BoardGameState : InputState
    {
        private Vector3 firstClick;
        private Vector3 mouseDrag;
        private Vector3 dragDirection;
        [Range(1, 100)]
        public float moveSpeed;

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
}
