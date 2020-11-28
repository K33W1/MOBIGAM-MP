using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
[RequireComponent(typeof(Enemy))]
public class EnemyShooting : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Settings")]
    [SerializeField] private EnemyShootingConfig config = null;

    public event Action ShotFired;

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
        yield return new WaitForSeconds(config.StartShootingDelay);

        while (true)
        {
            yield return new WaitForSeconds(config.AttemptShootRate);
            if (Random.value < config.ShootChance)
            {
                ShootBullet();
                yield return new WaitForSeconds(config.ShootCooldown);
            }
        }
    }

    private void ShootBullet()
    {
        Bullet bullet = BulletPooler.Instance.GetPooledObject();
        Vector3 direction = (enemy.Target.position - bulletSpawnPoint.position).normalized;

        bullet.transform.position = bulletSpawnPoint.position;
        bullet.Launch(gameObject.layer, direction, config.BulletSpeed, Element.None);

        ShotFired?.Invoke();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
