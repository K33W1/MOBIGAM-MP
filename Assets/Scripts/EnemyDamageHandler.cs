using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour, IDamageHandler
{
    [Header("Settings")]
    [SerializeField] private Element element = Element.None;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void Damage(DamageInfo damage)
    {
        if (element == damage.Element)
        {
            health.Damage(damage.Damage);
        }
    }
}
