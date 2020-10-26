using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BulletMovement))]
[RequireComponent(typeof(BulletDamageDealer))]
public class Bullet : MonoBehaviour
{
    private BulletMovement movement = null;
    private BulletDamageDealer damageDealer = null;

    private void Awake()
    {
        movement = GetComponent<BulletMovement>();
        damageDealer = GetComponent<BulletDamageDealer>();
    }

    public void Launch(int layer, Vector3 direction, Element element)
    {
        gameObject.layer = layer;
        movement.Launch(direction);
        damageDealer.Element = element;
    }

    private void OnDisable()
    {
        BulletPooler.Instance.ReturnToPool(this);
    }
}
