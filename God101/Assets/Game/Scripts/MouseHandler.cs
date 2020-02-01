using System;
using UnityEngine;

namespace God
{
    public class MouseHandler : MonoBehaviour
    {
        public static bool IsActing;

        private void Update()
        {
            CheckPosition();
            CheckInput();
        }

        private void CheckInput()
        {
            if (IsActing)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    DoAct();

                    IsActing = false;
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                }
            }
        }

        private void DoAct()
        {
            Debug.LogWarning("God act is happening at " + Input.mousePosition);
        }

        private void CheckPosition()
        {
            //Debug.Log("Mouse pointer: " + Input.mousePosition);
            transform.position = Input.mousePosition;
        }
    }
}