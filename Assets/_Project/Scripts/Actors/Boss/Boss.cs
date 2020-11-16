using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Boss : MonoBehaviour
{
    public event Action Spawned;
    public event Action Despawned;

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
