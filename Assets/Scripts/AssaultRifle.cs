using System;
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class AssaultRifle : MonoBehaviour, IWeapon
{
    [Header("Settings")]
    [SerializeField] private Element startingElement = Element.Blue;
    [SerializeField, Min(0)] private int damage = 1;
    [SerializeField, Min(0)] private int ammo = 60;
    [SerializeField, Min(0)] private int baseAmmoDrop = 20;
    [SerializeField, Min(0)] private float fireRate = 0.2f;
    [SerializeField, Min(0)] private float shootDistance = 100.0f;

    public Element Element { get; set; }

    private void Start()
    {
        Element = startingElement;
    }

    public void StartFire(Func<Ray> aimGetterFunc)
    {
        StartCoroutine(ShootLoop(aimGetterFunc));
    }


    public void StopFire()
    {
        StopAllCoroutines();
    }

    private IEnumerator ShootLoop(Func<Ray> rayFinderFunc)
    {
        while (true)
        {
            if (ammo > 0)
            {
                Physics.Raycast(rayFinderFunc(), out RaycastHit hitInfo, shootDistance);

                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.TryGetComponent(out IDamageHandler damageable))
                    {
                        damageable.Damage(new DamageInfo(Element, damage));
                    }
                }
            }
            else
            {
                Debug.Log("No ammo!");
            }

            yield return new WaitForSeconds(fireRate);
        }
    }

    public void TakeAmmoCrateDrop(AmmoCrateDrop drop)
    {
        Element = drop.Element;
    }

    public void TakeBonusAmmo(float bonusAmmoMult)
    {
        ammo += (int)(((float)baseAmmoDrop) * bonusAmmoMult);
    }
}
