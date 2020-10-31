using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Element element = Element.Blue;

    public event Action Spawned;

    public Element Element { get => element; private set => element = value; }
    public Transform Target { get; private set; }
    public Transform Waypoint { get; private set; }

    private EnemyWaypoints waypointProvider = null;

    public void Initialize(EnemyWaypoints waypointProvider, Transform target)
    {
        this.waypointProvider = waypointProvider;
        Target = target;
    }

    public void Spawn(Element element)
    {
        Element = element;
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

        EnemyPooler.Instance.ReturnToPool(this);
    }
}
