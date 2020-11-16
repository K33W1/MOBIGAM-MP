using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Boss))]
public class BossUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider healthBarUI = null;
    [SerializeField] private WinView winView = null;

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
        healthBarUI.value = (float)value / health.MaxValue;
    }

    private void OnDeath()
    {
        healthBarUI.gameObject.SetActive(false);
        winView.Show();
    }

    private void OnSpawn()
    {
        healthBarUI.gameObject.SetActive(true);
    }

    private void OnDespawn()
    {
        healthBarUI.gameObject.SetActive(false);
    }
}
