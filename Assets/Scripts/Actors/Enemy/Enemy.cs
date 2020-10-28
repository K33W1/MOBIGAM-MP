using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Element element = Element.Blue;

    public event Action Spawned;

    public Element Element
    {
        get => element;
        private set => element = value;
    }
    public Transform Target { get; private set; }

    public void InitializeOnSpawn(Element element)
    {
        Element = element;

        Spawned?.Invoke();
    }

    public void Initialize(Transform target)
    {
        Target = target;
    }
}
