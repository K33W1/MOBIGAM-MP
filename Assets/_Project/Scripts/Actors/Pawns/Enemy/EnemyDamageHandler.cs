using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Enemy))]
public class EnemyDamageHandler : MonoBehaviour, IDamageHandler
{
    public event Action UndamagedHit;
    public event Action Damaged;

    private Health health = null;
    private Enemy enemy = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        enemy = GetComponent<Enemy>();
    }

    public void Damage(DamageInfo damage)
    {
        if (enemy.Element == damage.Element)
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
        else
        {
            UndamagedHit?.Invoke();
        }
    }
}
