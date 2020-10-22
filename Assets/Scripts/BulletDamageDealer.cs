using UnityEngine;

[DisallowMultipleComponent]
public class BulletDamageDealer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageHandler damageHandler))
            damageHandler.Damage(new DamageInfo(Element.None, damage));
    }
}
