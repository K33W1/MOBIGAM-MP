using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target = null;

    private PlayerInput input = null;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        input.StartFire += StartFire;
        input.StopFire += StopFire;
    }

    private void StartFire()
    {
        throw new System.NotImplementedException();
    }

    private void StopFire()
    {
        throw new System.NotImplementedException();
    }
}
