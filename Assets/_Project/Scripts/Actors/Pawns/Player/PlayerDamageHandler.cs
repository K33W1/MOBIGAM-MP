using System;
using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class PlayerDamageHandler : MonoBehaviour, IDamageHandler
{
    [Header("Game Events")]
    [SerializeField] private GameEvent gameOver = null;

    public event Action UndamagedHit;
    public event Action Damaged;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        gameOver.RegisterListener(SetInvulnerable);
    }

    private void SetInvulnerable()
    {
        health.IsVulnerable = false;
    }

    public void Damage(DamageInfo damage)
    {
        if (damage.Damage > 0)
        {
            health.Damage(damage.Damage);
            Damaged?.Invoke();
        }
        else
        {
            UndamagedHit?.Invoke();
        }
    }

    private void OnDisable()
    {
        gameOver.UnregisterListener(SetInvulnerable);
    }
}
