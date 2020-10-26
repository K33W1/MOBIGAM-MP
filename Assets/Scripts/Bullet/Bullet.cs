using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BulletMovement))]
[RequireComponent(typeof(BulletDamageDealer))]
[RequireComponent(typeof(BulletVisualChanger))]
public class Bullet : MonoBehaviour
{
    private BulletMovement movement = null;
    private BulletDamageDealer damageDealer = null;
    private BulletVisualChanger visualChanger = null;

    private void Awake()
    {
        movement = GetComponent<BulletMovement>();
        damageDealer = GetComponent<BulletDamageDealer>();
        visualChanger = GetComponent<BulletVisualChanger>();
    }

    public void Launch(int layer, Vector3 direction, Element element)
    {
        gameObject.layer = layer;
        movement.Launch(direction);
        damageDealer.Element = element;
        visualChanger.OnElementChanged(element);
    }

    private void OnDisable()
    {
        BulletPooler.Instance.ReturnToPool(this);
    }
}
