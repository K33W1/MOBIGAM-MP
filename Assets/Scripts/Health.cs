using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private int health = 3;
    [SerializeField, Min(0)] private int maxHealth = 3;

    public event Action Died;

#if DEBUG
    private void Start()
    {
        Debug.Assert(health <= maxHealth && health >= 0);
    }
#endif

    public void Damage(int damage)
    {
        Debug.Assert(damage > 0);
        
        health -= damage;
        
        if (health <= 0)
            Died?.Invoke();
    }

    public void Heal(int heal)
    {
        Debug.Assert(heal > 0);

        health = Mathf.Min(health + heal, maxHealth);
    }
}
