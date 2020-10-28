using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Enemy))]
public class EnemyDamageHandler : MonoBehaviour, IDamageHandler
{
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
            health.Damage(damage.Damage);
        }
    }
}
