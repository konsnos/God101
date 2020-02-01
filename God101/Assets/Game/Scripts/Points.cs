using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points Instance;

    private int points = 0;

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
}
