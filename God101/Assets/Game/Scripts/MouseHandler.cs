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
            //CheckInput();
        }

        private void CheckInput()
        {
            if (IsActing)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    DoAct();
                }
            }
        }

        private void DoAct()
        {
            Debug.LogWarning("God act is happening at " + Input.mousePosition);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8; // Disasters

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;
            if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
            {
                var disaster = hit.collider.gameObject.GetComponent<Disaster>();
                Debug.Log("God act done at disaster " + disaster.DisasterType);

                IsActing = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }

        private void CheckPosition()
        {
            //Debug.Log("Mouse pointer: " + Input.mousePosition);
            transform.position = Input.mousePosition;
        }
    }
}