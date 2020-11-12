using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class BossDamageHandler : MonoBehaviour, IDamageHandler
{
    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void Damage(DamageInfo damage)
    {
        health.Damage(damage.Damage);
    }
}
