using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class PlayerHealthUI : MonoBehaviour
{
    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.ValueChanged += OnHealthChanged;
    }

    private void Start()
    {
        OnHealthChanged(health.Value);
    }

    private void OnHealthChanged(int value)
    {
        Image[] hearts = UIServiceLocator.Instance.PlayerHearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            Color color = hearts[i].color;
            color.a = i < value ? 1f : 0.25f;
            hearts[i].color = color;
        }
    }
}
