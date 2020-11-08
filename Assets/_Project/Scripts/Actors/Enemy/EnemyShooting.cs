using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Enemy))]
public class EnemyShooting : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Settings")]
    [SerializeField] private Vector2 cooldownRange = new Vector2(1f, 2f);
    [SerializeField, Range(0, 1)] private float hitChance = 0.5f;
    [SerializeField, Min(0)] private float bulletSpeed = 10f;

    private Enemy enemy = null;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShootingLoop());
    }

    private IEnumerator ShootingLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(cooldownRange.x, cooldownRange.y));
            if (Random.value < hitChance)
                ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Bullet bullet = BulletPooler.Instance.GetPooledObject();
        Vector3 direction = (enemy.Target.position - bulletSpawnPoint.position).normalized;

        bullet.transform.position = bulletSpawnPoint.position;
        bullet.Launch(gameObject.layer, direction, bulletSpeed, Element.None);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
