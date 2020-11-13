using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Boss : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider slider = null;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.ValueChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        slider.value = (float)value / health.MaxValue;
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
    }
}
