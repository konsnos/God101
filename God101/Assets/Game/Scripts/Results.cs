using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gradeTxt;

    public void UpdateGrade(int grade)
    {
        gradeTxt.text = "Grade: " + grade + "%";
    }
}
