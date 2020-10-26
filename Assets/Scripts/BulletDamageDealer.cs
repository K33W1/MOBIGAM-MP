using UnityEngine;

[DisallowMultipleComponent]
public class BulletDamageDealer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private int damage = 1;

    public Element Element { get; set; } = Element.None;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageHandler damageHandler))
            damageHandler.Damage(new DamageInfo(Element, damage));
    }
}
