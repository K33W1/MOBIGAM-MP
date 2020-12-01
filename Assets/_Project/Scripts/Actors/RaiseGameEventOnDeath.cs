using Kiwi.Events;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class RaiseGameEventOnDeath : MonoBehaviour
{
    [SerializeField] private GameEvent deathGameEvent = null;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.Died += RaiseDeathEvent;
    }

    private void RaiseDeathEvent()
    {
        deathGameEvent.Raise();
    }

    private void OnDisable()
    {
        health.Died -= RaiseDeathEvent;
    }
}
