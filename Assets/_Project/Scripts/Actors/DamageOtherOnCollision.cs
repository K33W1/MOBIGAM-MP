using System;
using UnityEngine;

[DisallowMultipleComponent]
public class DamageOtherOnCollision : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private int damage = 1;
    [SerializeField] private Element element = Element.None;

    public event Action DamagedOther;

    public Element Element
    {
        get => element;
        set => element = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageHandler damageHandler))
        {
            damageHandler.Damage(new DamageInfo(Element, damage));
            DamagedOther?.Invoke();
        }
    }
}
