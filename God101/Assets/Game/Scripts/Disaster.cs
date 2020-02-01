using UnityEngine;

namespace God
{
    public class Disaster : MonoBehaviour
    {
        [SerializeField] private DisasterType disasterType;
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
        }

        private void OnDestroy()
        {
            if (disasterType == DisasterType.Earthquake)
            {
                FindObjectOfType<Planet>().StopIt();
            }
        }
    }
}