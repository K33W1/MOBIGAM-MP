using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Element element = Element.C;

    public event Action Spawned;

    public Element Element => element;
    public Transform Target { get; private set; }
    public Transform Waypoint { get; private set; }

    private EnemyWaypoints waypointProvider = null;

    public void Initialize(EnemyWaypoints waypointProvider, Transform target)
    {
        this.waypointProvider = waypointProvider;
        Target = target;
    }

    public void Spawn()
    {
        Waypoint = waypointProvider.GetWaypoint();

        Spawned?.Invoke();
    }

    private void OnDisable()
    {
        if (Waypoint != null)
        {
            waypointProvider.ReturnWaypoint(Waypoint);
            Waypoint = null;
        }

        EnemyAPooler.Instance.ReturnToPool(this);
    }
}
