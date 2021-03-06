﻿using System;
using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent deathGameEvent = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private int maxHealth = 3;
    [SerializeField, Min(0)] private int health = 3;

    public event Action Died;
    public event Action<int> ValueChanged;

    public bool IsVulnerable { get; set; } = true;
    public bool IsDebugInvincible { get; set; } = false;

    public int MaxValue => maxHealth;
    public int Value => health;
    public bool IsAlive => health > 0;

    private void Start()
    {
        Debug.Assert(health <= maxHealth && health >= 0);
    }

    public void Damage(int damage)
    {
        Debug.Assert(damage > 0);

        if (!IsVulnerable || IsDebugInvincible)
            return;

        health -= damage;
        ValueChanged?.Invoke(health);

        if (health <= 0)
        {
            Died?.Invoke();
            if (deathGameEvent)
            {
                deathGameEvent.Raise();
            }
        }
    }

    public void Heal(int heal)
    {
        Debug.Assert(heal > 0);

        health = Mathf.Min(health + heal, maxHealth);
        ValueChanged?.Invoke(health);
    }

    [ContextMenu("Force Death")]
    private void ForceDeath()
    {
        health = 0;
        ValueChanged?.Invoke(health);
        Died?.Invoke();
        if (deathGameEvent)
        {
            deathGameEvent.Raise();
        }
    }
}
