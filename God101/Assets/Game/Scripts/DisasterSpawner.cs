using System.Threading;
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

        [SerializeField] private GameObject[] disasters;
        [Tooltip("Radius of a circle to spawn inside a catastrophe.")]
        [SerializeField] private float radiusForSpawns;

        Task disasterTask;
        CancellationTokenSource cts;

        public int DisasterCount { private set; get; } = 0;

        private void Awake()
        {
            cts = new CancellationTokenSource();
            disasterTask = ScheduleDisasterAsync();

        }

        public async Task ScheduleDisasterAsync()
        {
            await Task.Delay((int)(UnityEngine.Random.Range(minDuration, maxDuration) * 1000), cts.Token);
;           SpawnDisaster();
        }

        public void SpawnDisaster()
        {
            if (Points.Instance.IsFinished) return;

            int disasterId = UnityEngine.Random.Range(0, disasters.Length);

            //var position = RandomCircle(transform.position, radiusForSpawns);
            Instantiate(disasters[disasterId], transform.position, Quaternion.identity);

            DisasterCount++;
        }

        Vector3 RandomCircle(Vector3 center, float radius)
        {
            float ang = UnityEngine.Random.value * 360;
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad) * UnityEngine.Random.Range(0, 1f);
            pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad) * UnityEngine.Random.Range(0, 1f);
            pos.z = center.z;
            return pos;
        }

        private void OnDestroy()
        {
            cts.Cancel();
            disasterTask.Dispose();
        }
    }

    public enum DisasterType
    {
        Fire,
        Tornado,
        Earthquake,
        None = 99
    }
}