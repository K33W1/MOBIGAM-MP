using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class UpdateTextOnIntValueChange : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue intValue = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private int leftPadWidth = 3;
    [SerializeField, Min(0)] private int rightPadWidth = 3;
    [SerializeField] private char paddingChar = ' ';

    private TextMeshProUGUI text = null;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        intValue.ValueChanged += UpdateText;
    }

    private void Start()
    {
        UpdateText(intValue.Value);
    }

    private void UpdateText(int value)
    {
        text.text = StringifyValue(value);
    }

    private string StringifyValue(int value)
    {
        return value
            .ToString()
            .PadLeft(leftPadWidth, paddingChar)
            .PadRight(rightPadWidth, paddingChar);
    }
}
