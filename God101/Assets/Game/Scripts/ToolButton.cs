using System;
using UnityEngine;
using UnityEngine.UI;

namespace God
{
    [RequireComponent(typeof(Button))]
    public class ToolButton : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture;
        [SerializeField] private Vector2 hotSpot = Vector2.zero;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
    }
}