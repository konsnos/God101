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

        [SerializeField] private ToolType toolType;
        [SerializeField] private DisasterType dealsWithDisaster;
        [SerializeField] private int pointsAwarded;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            //Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
            //MouseHandler.IsActing = true;

            DoGodAct();
        }

        private void DoGodAct()
        {
            Disaster disaster = FindObjectOfType<Disaster>();

            if (disaster == null)
            {
                Points.Instance.AddPoints(-5);
                return;
            }

            if (disaster.DisasterType == dealsWithDisaster)
            {
                Destroy(disaster.gameObject);
                Points.Instance.AddPoints(pointsAwarded);
                Points.Instance.CheckIfFinished();
                System.Threading.Tasks.Task task = FindObjectOfType<DisasterSpawner>().ScheduleDisasterAsync();
            }
            else
            {
                Points.Instance.AddPoints(-5);
            }
        }
    }

    public enum ToolType
    {
        Cloud,
        Vacuum_Cleaner,
        Hammer,
        Racket
    }
}