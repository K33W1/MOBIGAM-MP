using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class MoneyText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue money = null;
    [SerializeField] private TextMeshProUGUI text = null;

    private void Awake()
    {
        money.ValueChanged += UpdateText;
    }

    private void UpdateText(int value)
    {
        text.text = value.ToString().PadLeft(5, '0');
    }
}
