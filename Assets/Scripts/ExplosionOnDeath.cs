using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class ExplosionOnDeath : MonoBehaviour
{
    private void Awake()
    {
        Health health = GetComponent<Health>();
        health.Died += OnDeath;
    }

    private void OnDeath()
    {
        Explosion explosion = ExplosionPooler.Instance.GetPooledObject();
        explosion.transform.position = transform.position;
    }
}
