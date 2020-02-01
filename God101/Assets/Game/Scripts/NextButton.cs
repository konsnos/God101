using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace God
{
    [RequireComponent(typeof(Button))]
    public class NextButton : MonoBehaviour
    {
        [SerializeField] private GameObject currentGO;
        [SerializeField] private GameObject nextGO;
        [SerializeField] private string sceneName;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            if (nextGO != null)
            {
                currentGO.SetActive(false);
                nextGO.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}