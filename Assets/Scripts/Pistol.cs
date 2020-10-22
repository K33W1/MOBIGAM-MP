using UnityEngine;

[DisallowMultipleComponent]
public class Pistol : MonoBehaviour, IWeapon
{
    [Header("Settings")]
    [SerializeField] private Element element = Element.Blue;
    [SerializeField, Min(0)] private int damage = 1;
    [SerializeField, Min(0)] private float shootDistance = 100.0f;

    public void StartFire(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hitInfo, shootDistance);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.TryGetComponent(out IDamageHandler damageable))
            {
                damageable.Damage(new DamageInfo(element, damage));
            }
        }
    }

    public void StopFire()
    {
        // Do nothing
    }
}
