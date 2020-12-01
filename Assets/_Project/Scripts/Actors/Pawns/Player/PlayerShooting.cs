using System;
using System.Collections;
using Kiwi.Extensions;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private LayerMask projectileLayer = new LayerMask();

    [Header("Settings")]
    [SerializeField] private PlayerConfig _playerConfig = null;

    public event Action ShotFired;

    private Health health = null;
    private PlayerInput input = null;

    private Element currentElement = Element.C;

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
            bullet.Launch(projectileLayer.MaskToLayer(), direction, _playerConfig.BulletSpeed, currentElement);
            ShotFired?.Invoke();

            yield return new WaitForSeconds(_playerConfig.FireRate);
        }
    }

    private void StopFire()
    {
        StopAllCoroutines();
    }
}
