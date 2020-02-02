using TMPro;
using UnityEngine;

namespace God
{
    public class Disaster : MonoBehaviour
    {
        [SerializeField] private DisasterType disasterType;
        [SerializeField] private string textOnSpawn;
        [SerializeField] private string textOnSolution;
        [SerializeField] private string textOnFail;

        public DisasterType DisasterType
        {
            get { return disasterType; }
        }

        private void Awake()
        {
            if (disasterType == DisasterType.Earthquake)
            {
                FindObjectOfType<Planet>().MoveIt();
            }

            UpdateText(textOnSpawn);
        }

        private void UpdateText(string text)
        {
            GameObject descriptionGO = GameObject.FindGameObjectWithTag("Description");
            TextMeshProUGUI descriptionTxt = descriptionGO.GetComponent<TextMeshProUGUI>();

            descriptionTxt.text = text;
        }

        public void ShowFail()
        {
            UpdateText(textOnFail);
        }

        private void OnDestroy()
        {
            if (disasterType == DisasterType.Earthquake)
            {
                FindObjectOfType<Planet>()?.StopIt();
            }

            UpdateText(textOnSolution);
        }
    }
}