using God;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points Instance;

    private int points = 0;

    private DisasterSpawner disasterSpawner;
    [SerializeField] private int disastersMax = 3;

    public bool IsFinished { private set; get; } = false;

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

        if ( disasterSpawner.DisasterCount >= disastersMax )
        {
            IsFinished = true;
            Debug.Log("Finished!!!");
        }
    }
}
