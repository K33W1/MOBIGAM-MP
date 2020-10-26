using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShootingOld : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Transform weaponHolder = null;

    private PlayerInput input = null;

    private IWeapon currentWeapon = null;
    private int currentWeaponIndex = 0;

    private void Awake()
    {
        Debug.Assert(transform.childCount > 0);

        input = GetComponent<PlayerInput>();
        input.StartFire += OnStartFire;
        input.StopFire += OnStopFire;
        input.SwitchWeaponUp += SwitchWeaponUp;
        input.SwitchWeaponDown += SwitchWeaponDown;
    }

    private void Start()
    {
        foreach (Transform child in weaponHolder.GetComponentsInChildren<Transform>())
        {
            if (child != weaponHolder)
                child.gameObject.SetActive(false);
        }

        GameObject weaponObject = weaponHolder.GetChild(currentWeaponIndex).gameObject;
        weaponObject.SetActive(true);
        currentWeapon = weaponObject.GetComponent<IWeapon>();
    }

    public void TakeAmmoCrateDrop(AmmoCrateDrop drop)
    {
        currentWeapon.Element = drop.Element;
        currentWeapon.TakeBonusAmmo(drop.BonusAmmoMult);
    }

    private void OnStartFire()
    {
        throw new NotImplementedException();
    }

    private void OnStopFire()
    {
        currentWeapon.StopFire();
    }

    private void SwitchWeaponUp()
    {
        if (weaponHolder.childCount <= 1) return;
        EquipWeapon((currentWeaponIndex + 1) % weaponHolder.childCount);
    }

    private void SwitchWeaponDown()
    {
        if (weaponHolder.childCount <= 1) return;
        EquipWeapon((weaponHolder.childCount + currentWeaponIndex - 1) % weaponHolder.childCount);
    }

    private void EquipWeapon(int newWeaponIndex)
    {
        weaponHolder.GetChild(currentWeaponIndex).gameObject.SetActive(false);
        GameObject weaponObject = weaponHolder.GetChild(newWeaponIndex).gameObject;
        weaponObject.SetActive(true);
        currentWeapon = weaponObject.GetComponent<IWeapon>();
    }
}
