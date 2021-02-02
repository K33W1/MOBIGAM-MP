using Kiwi.DataObject;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private BoolValue PlayerDebugInvulnerable = null;

    [Header("References")]
    [SerializeField] private Transform modelTransform;

    public Transform ModelTransform => modelTransform;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        PlayerDebugInvulnerable.ValueChanged += OnVulnerabilityChanged;
    }

    private void Start()
    {
        health.IsDebugInvincible = PlayerDebugInvulnerable.Value;
    }

    private void OnVulnerabilityChanged(bool value)
    {
        health.IsDebugInvincible = value;
    }

    private void OnDisable()
    {
        PlayerDebugInvulnerable.ValueChanged -= OnVulnerabilityChanged;
    }
}
