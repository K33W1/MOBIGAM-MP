using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class AddIntValueOnDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue intValue = null;

    [Header("Settings")]
    [SerializeField] private int toAdd = 1;

    private void Awake()
    {
        Health health = GetComponent<Health>();
        health.Died += () => intValue.Value += toAdd;
    }
}
