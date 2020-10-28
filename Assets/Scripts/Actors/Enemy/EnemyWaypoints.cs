using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    public static EnemyWaypoints Instance = null;

    private void Awake()
    {
        Instance = this;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (!EditorApplication.isPlaying)
            RefreshWaypoints();
    }

    [ContextMenu("Refresh Waypoints")]
    private void RefreshWaypoints()
    {
        waypoints.Clear();
        
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }
    }
#endif

    public Transform GetWaypoint()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogError("No more available enemy waypoints!");
            return null;
        }

        int randomIndex = Random.Range(0, waypoints.Count);
        Transform randomPos = waypoints[randomIndex];
        waypoints.RemoveAt(randomIndex);
        return randomPos;
    }

    public void ReturnWaypoint(Transform transform)
    {
        waypoints.Add(transform);
    }

    private void OnDestroy()
    {
        Instance = this;
    }
}
