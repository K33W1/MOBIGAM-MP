using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Pistol : MonoBehaviour, IWeapon
{
    [Header("Settings")]
    [SerializeField] private Element startingElement = Element.Blue;
    [SerializeField, Min(0)] private int damage = 1;
    [SerializeField, Min(0)] private float shootDistance = 100.0f;

    public Element Element { get; set; }

    private void Start()
    {
        Element = startingElement;
    }

    public void StartFire(Func<Ray> aimGetterFunc)
    {
        Physics.Raycast(aimGetterFunc(), out RaycastHit hitInfo, shootDistance);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.TryGetComponent(out IDamageHandler damageable))
            {
                damageable.Damage(new DamageInfo(Element, damage));
            }
        }
    }

    public void StopFire()
    {
        // Do nothing
    }

    public void TakeAmmoCrateDrop(AmmoCrateDrop drop)
    {
        Element = drop.Element;
    }
    public void TakeBonusAmmo(float _)
    {
        // Do nothing
    }
}
