using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float fireRate = 0.25f;

    private PlayerInput input = null;

    private Element currentElement = Element.Blue;

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
            Vector3 direction = bulletSpawnPoint.forward;

            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.Launch(gameObject.layer, direction, currentElement);

            yield return new WaitForSeconds(fireRate);
        }
    }

    private void StopFire()
    {
        StopAllCoroutines();
    }
}
