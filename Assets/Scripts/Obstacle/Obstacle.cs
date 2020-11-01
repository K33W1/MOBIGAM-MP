using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ObstacleMovement))]
public class Obstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damage = 1;

    private ObstacleMovement movement = null;

    private void Awake()
    {
        movement = GetComponent<ObstacleMovement>();
    }

    public void Spawn(Vector3 direction)
    {
        movement.Launch(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageHandler damageHandler))
        {
            damageHandler.Damage(new DamageInfo(Element.None, damage));
        }
    }
}
