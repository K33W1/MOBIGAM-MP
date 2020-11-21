using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Int Value", menuName = "Runtime Data Objects/Int Value")]
public class IntValue : ScriptableObject
{
    [SerializeField] private int value = 0;

    public event Action<int> ValueChanged;

    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            ValueChanged?.Invoke(value);
        }
    }
}
