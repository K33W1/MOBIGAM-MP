using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BulletMovement))]
[RequireComponent(typeof(DamageOtherOnCollision))]
[RequireComponent(typeof(BulletVisualChanger))]
public class Bullet : MonoBehaviour
{
    private BulletMovement movement = null;
    private DamageOtherOnCollision damageOtherOnCollision = null;
    private BulletVisualChanger visualChanger = null;

    private void Awake()
    {
        movement = GetComponent<BulletMovement>();
        damageOtherOnCollision = GetComponent<DamageOtherOnCollision>();
        visualChanger = GetComponent<BulletVisualChanger>();
    }

    public void Launch(int layer, Vector3 direction, float speed, Element element)
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = layer;
        }

        movement.Launch(direction, speed);
        damageOtherOnCollision.Element = element;
        visualChanger.OnElementChanged(element);
    }

    private void OnDisable()
    {
        BulletPooler.Instance.ReturnToPool(this);
    }
}
