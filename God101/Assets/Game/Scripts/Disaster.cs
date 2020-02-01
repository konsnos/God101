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
    }
}