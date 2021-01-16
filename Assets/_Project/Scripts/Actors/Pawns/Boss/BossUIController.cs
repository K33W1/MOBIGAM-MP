using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Boss))]
public class BossUIController : MonoBehaviour
{
    private UIServiceLocator UIServiceLocator => UIServiceLocator.Instance;

    private Health health = null;
    private Boss boss = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        boss = GetComponent<Boss>();

        health.ValueChanged += OnHealthChanged;
        health.Died += OnDeath;
        boss.Spawned += OnSpawn;
        boss.Despawned += OnDespawn;
    }

    private void OnHealthChanged(int value)
    {
        UIServiceLocator.BossHealthBar.value = (float)value / health.MaxValue;
    }

    private void OnDeath()
    {
        UIServiceLocator.BossHealthBar.gameObject.SetActive(false);
        UIServiceLocator.WinView.Show();
    }

    private void OnSpawn()
    {
        UIServiceLocator.BossHealthBar.gameObject.SetActive(true);
    }

    private void OnDespawn()
    {
        UIServiceLocator.BossHealthBar.gameObject.SetActive(false);
    }
}
