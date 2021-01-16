using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BossMovement))]
[RequireComponent(typeof(BossShooting))]
public class Boss : MonoBehaviour
{
    public event Action Spawned;
    public event Action Despawned;

    public void Initialize(Transform playerTransform, Transform waypoint)
    {
        GetComponent<BossShooting>().Initialize(playerTransform);
        GetComponent<BossMovement>().Initialize(waypoint);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        Spawned?.Invoke();
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        Despawned?.Invoke();
    }
}
