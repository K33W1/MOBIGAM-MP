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

    [Header("Data Objects")] 
    [SerializeField] private ElementDataObject elementDataObject = null;

    [Header("Settings")] [SerializeField] private PlayerConfig _playerConfig = null;

    public event Action ShotFired;

    private Health health = null;
    private PlayerInput input = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        input = GetComponent<PlayerInput>();

        input.StartFire += StartFire;
        input.StopFire += StopFire;
        input.SwitchWeaponUp += OnSwitchWeaponUp;
        input.SwitchWeaponDown += OnSwitchWeaponDown;
    }

    private void Start()
    {
        elementDataObject.Value = Element.C;
    }

    private void OnSwitchWeaponUp()
    {
        int validElementsCount = ElementExtensions.ValidElements.Length;
        int newElementIndex = (int) elementDataObject.Value % validElementsCount;
        elementDataObject.Value = ElementExtensions.ValidElements[newElementIndex];
    }

    private void OnSwitchWeaponDown()
    {
        int validElementsCount = ElementExtensions.ValidElements.Length;
        int newElementIndex = (int)(validElementsCount + elementDataObject.Value - 2) % validElementsCount;
        elementDataObject.Value = ElementExtensions.ValidElements[newElementIndex];
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
            bullet.Launch(projectileLayer.MaskToLayer(), direction, _playerConfig.BulletSpeed, elementDataObject.Value);
            ShotFired?.Invoke();

            yield return new WaitForSeconds(_playerConfig.FireRate);
        }
    }

    private void StopFire()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        elementDataObject.Value = Element.C;
    }
}
