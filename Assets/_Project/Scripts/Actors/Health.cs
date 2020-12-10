using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private int maxHealth = 3;
    [SerializeField, Min(0)] private int health = 3;
    [SerializeField] private bool isDebugInvincible = false;

    public event Action Died;
    public event Action<int> ValueChanged;

    public bool IsVulnerable { get; set; } = true;

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

        if (!IsVulnerable)
            return;

#if UNITY_EDITOR
        if (isDebugInvincible)
            return;
#endif

        health -= damage;
        ValueChanged?.Invoke(health);
        
        if (health <= 0)
            Died?.Invoke();
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
    }
}
