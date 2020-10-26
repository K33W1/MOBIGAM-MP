using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private Transform target = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float fireRate = 0.25f;

    private PlayerInput input = null;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        input.StartFire += StartFire;
        input.StopFire += StopFire;
    }

    private void StartFire()
    {
        StartCoroutine(FiringLoop());
    }

    private IEnumerator FiringLoop()
    {
        while (true)
        {
            Bullet bullet = BulletPooler.Instance.GetPooledObject();
            bullet.Launch((target.position - transform.position).normalized);
            bullet.transform.position = bulletSpawnPoint.transform.position;

            yield return new WaitForSeconds(fireRate);
        }
    }

    private void StopFire()
    {
        StopAllCoroutines();
    }
}
