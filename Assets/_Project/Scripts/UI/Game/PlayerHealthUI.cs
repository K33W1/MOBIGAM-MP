using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerHealthUI : MonoBehaviour
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
        for (int i = 0; i < healthImages.Length; i++)
        {
            Color color = healthImages[i].color;
            color.a = i < value ? 1f : 0.25f;
            healthImages[i].color = color;
        }
    }
}
