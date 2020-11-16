using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float Value", menuName = "Common/FloatValue")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float value = 0;

    public event Action<float> ValueChanged;

    public float Value
    {
        get => value;
        set
        {
            this.value = value;
            ValueChanged?.Invoke(value);
        }
    }
}
