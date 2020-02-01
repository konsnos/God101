using God;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points Instance;

    private int points = 0;

    private DisasterSpawner disasterSpawner;
    [SerializeField] private int disastersMax = 3;

    public bool IsFinished { private set; get; } = false;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject resultUI;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoints(int value)
    {
        points += value;

        if (points < 0)
        {
            points = 0;
        }
    }

    public void CheckIfFinished()
    {
        if (disasterSpawner == null)
            disasterSpawner = FindObjectOfType<DisasterSpawner>();

        Invoke("ShowResults", 2f);
    }

    private void ShowResults()
    {
        if (disasterSpawner.DisasterCount >= disastersMax)
        {
            IsFinished = true;

            gameUI.SetActive(false);
            resultUI.SetActive(true);

            resultUI.GetComponent<Results>().UpdateGrade(points);
        }
    }
}
