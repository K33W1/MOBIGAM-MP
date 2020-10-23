using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class DisableOnDeath : MonoBehaviour
{
    private void Awake()
    {
        Health health = GetComponent<Health>();
        health.Died += () => gameObject.SetActive(false);
    }
}
