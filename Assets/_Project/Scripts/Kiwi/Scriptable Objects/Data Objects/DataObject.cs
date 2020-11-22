using System;
using UnityEngine;

namespace Kiwi.DataObject
{
    public abstract class DataObject<T> : ScriptableObject
    {
#pragma warning restore 649
        [SerializeField] private T value;

        public event Action<T> ValueChanged;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                ValueChanged?.Invoke(value);
            }
        }
    }
}