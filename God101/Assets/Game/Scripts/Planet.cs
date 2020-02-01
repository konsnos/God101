using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace God
{
    [RequireComponent(typeof(Animator))]
    public class Planet : MonoBehaviour
    {
        private readonly int isEarthquaking = Animator.StringToHash("IsEarthquaking");

        public void MoveIt()
        {
            GetComponent<Animator>().SetBool(isEarthquaking, true);
        }

        public void StopIt()
        {
            GetComponent<Animator>().SetBool(isEarthquaking, false);
        }
    }
}