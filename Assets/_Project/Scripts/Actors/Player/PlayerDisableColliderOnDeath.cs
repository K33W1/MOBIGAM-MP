using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class PlayerDisableColliderOnDeath : MonoBehaviour
{
    private void Awake()
    {
        Health health = GetComponent<Health>();
        Collider collider = GetComponent<Collider>();

        health.Died += () => collider.enabled = false;
    }
}
