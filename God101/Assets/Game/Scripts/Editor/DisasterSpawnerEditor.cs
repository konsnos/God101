using God;
using UnityEditor;
using UnityEngine;

namespace GodEditor
{
    [CustomEditor(typeof(DisasterSpawner))]
    public class DisasterSpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (Application.isPlaying)
            {
                if (GUILayout.Button("Spawn"))
                {
                    var script = (DisasterSpawner)target;

                    script.SpawnDisaster();
                }
            }
        }
    }
}