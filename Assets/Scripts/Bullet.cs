using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BulletMovement))]
public class Bullet : MonoBehaviour
{
    private BulletMovement movement = null;

    private void Awake()
    {
        movement = GetComponent<BulletMovement>();
    }

    public void Launch(Vector3 direction)
    {
        movement.Launch(direction);
    }

    private void OnDisable()
    {
        BulletPooler.Instance.ReturnToPool(this);
    }
}
