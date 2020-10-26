using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private new Camera camera = null;

    [Header("Settings")]
    [SerializeField] private float speedX = 1.0f;
    [SerializeField] private float speedY = 1.0f;
    [SerializeField] private float speedZ = 1.0f;

    private PlayerInput input = null;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Vector2 rawMove = input.Move;
        Vector3 move = new Vector3(rawMove.x * speedX, rawMove.y * speedY) * Time.deltaTime;

        transform.localPosition += move;
        ClampPosition();
        HorizontalRotation();
    }

    private void ClampPosition()
    {
        Vector3 pos = camera.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = camera.ViewportToWorldPoint(pos);
    }

    private void HorizontalRotation()
    {

    }
}
