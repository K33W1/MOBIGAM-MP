using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class DisableColliderOnDeath : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();

    private void Awake()
    {
        Health health = GetComponent<Health>();

        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            health.Died += () => collider.enabled = false;
        }
    }
}
