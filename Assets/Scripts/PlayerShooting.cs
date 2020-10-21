using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private new Camera camera = null;

    [Header("Settings")]
    //[SerializeField] private LayerMask shootableMask = new LayerMask();
    [SerializeField] private float shootDistance = 100.0f;
    

    private PlayerInput input = null;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        input.Fire += OnFire;
    }

    private void OnFire(Vector2 screenPos)
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(screenPos.x, screenPos.y, 1));
        Physics.Raycast(ray, out RaycastHit hitInfo, shootDistance);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.TryGetComponent(out Health health))
            {
                health.Damage(1);
            }
        }
    }
}
