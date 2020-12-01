using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class InvulnerableOnGameEvent : MonoBehaviour
{
    [SerializeField] private GameEvent bossDied = null;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        bossDied.RegisterListener(BecomeInvulnerable);
    }

    private void BecomeInvulnerable()
    {
        health.IsVulnerable = false;
    }

    private void OnDisable()
    {
        bossDied.UnregisterListener(BecomeInvulnerable);
    }
}
