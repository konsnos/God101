using System;
using System.Threading.Tasks;
using UnityEngine;

namespace God
{
    public class DisasterSpawner : MonoBehaviour
    {
        [Tooltip("Minimum time for disaster in seconds")]
        [SerializeField] private float minDuration;
        [Tooltip("Maximum time for disaster in seconds.")]
        [SerializeField] private float maxDuration;

        private void Awake()
        {
            Task task = ScheduleDisasterAsync();
        }

        private async Task ScheduleDisasterAsync()
        {
            await Task.Delay((int)(UnityEngine.Random.Range(minDuration, maxDuration) * 1000))
;           SpawnDisaster();
        }

        private void SpawnDisaster()
        {
            Debug.Log("Disaster!!");

            Task task = ScheduleDisasterAsync();
        }
    }

    public enum Disaster
    {
        Fire,
        Tornado,
        Earthquake
    }
}