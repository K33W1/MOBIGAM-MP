using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
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

    private void OnStartFire(Vector2 screenPos)
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(screenPos.x, screenPos.y, 1));
        currentWeapon.StartFire(ray);
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
