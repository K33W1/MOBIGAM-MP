using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Enemy))]
public class EnemyShooting : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Settings")]
    [SerializeField, Range(0, 1)] private float shootChance = 0.5f;
    [SerializeField, Min(0)] private float shootCooldown = 2f;
    [SerializeField, Min(0)] private float attemptShootRate = 1f;
    [SerializeField, Min(0)] private float bulletSpeed = 10f;
    [SerializeField, Min(0)] private float startShootingDelay = 1f;

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
        yield return new WaitForSeconds(startShootingDelay);

        while (true)
        {
            yield return new WaitForSeconds(attemptShootRate);
            if (Random.value < shootChance)
            {
                ShootBullet();
                yield return new WaitForSeconds(shootCooldown);
            }
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
