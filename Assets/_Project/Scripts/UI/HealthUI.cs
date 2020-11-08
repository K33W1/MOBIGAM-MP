using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class HealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health health = null;

    private Image[] healthImages = null;

    private void Awake()
    {
        health.ValueChanged += OnHealthChanged;
        healthImages = GetComponentsInChildren<Image>();
    }

    private void Start()
    {
        OnHealthChanged(health.Value);
    }

    private void OnHealthChanged(int value)
    {
        //Debug.Assert(value <= healthImages.Length);

        for (int i = 0; i < healthImages.Length; i++)
        {
            Color color = healthImages[i].color;
            color.a = i < value ? 1f : 0.5f;
            healthImages[i].color = color;
        }
    }
}
