using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private int maxHealth = 3;
    [SerializeField, Min(0)] private int health = 3;

    public event Action Died;
    public event Action<int> ValueChanged;

    public int Value => health;
    public bool IsAlive => health > 0;

    private void Start()
    {
        Debug.Assert(health <= maxHealth && health >= 0);
    }

    public void Damage(int damage)
    {
        Debug.Assert(damage > 0);

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
}
