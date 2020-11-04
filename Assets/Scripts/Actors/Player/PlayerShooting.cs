using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float fireRate = 0.25f;

    private Health health = null;
    private PlayerInput input = null;

    private Element currentElement = Element.Blue;

    private void Awake()
    {
        health = GetComponent<Health>();
        input = GetComponent<PlayerInput>();

        input.StartFire += StartFire;
        input.StopFire += StopFire;
        input.SwitchWeaponUp += OnSwitchWeaponUp;
        input.SwitchWeaponDown += OnSwitchWeaponDown;
    }

    private void OnSwitchWeaponUp()
    {
        int validElementsCount = ElementExtensions.ValidElements.Length;
        int newElementIndex = (int) currentElement % validElementsCount;
        currentElement = ElementExtensions.ValidElements[newElementIndex];
    }

    private void OnSwitchWeaponDown()
    {
        int validElementsCount = ElementExtensions.ValidElements.Length;
        int newElementIndex = (int)(validElementsCount + currentElement - 2) % validElementsCount;
        currentElement = ElementExtensions.ValidElements[newElementIndex];
    }

    private void StartFire()
    {
        StartCoroutine(FiringLoop());
    }

    private IEnumerator FiringLoop()
    {
        while (health.IsAlive)
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
