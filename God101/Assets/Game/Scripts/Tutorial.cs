using UnityEngine;

namespace God
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject[] tutorials;

        private void OnEnable()
        {
            for (int i = 0; i < tutorials.Length; i++)
            {
                tutorials[i].SetActive(i == 0);
            }
        }
    }
}