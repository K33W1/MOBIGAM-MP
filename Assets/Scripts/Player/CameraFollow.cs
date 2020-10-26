using Kiwi.Extensions;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float smoothing = 0.1f;
    [SerializeField] private Vector2 limits = new Vector2();

    private Vector3 origin = new Vector3();
    private Vector3 velocity = new Vector3();

    private void Start()
    {
        origin = transform.localPosition;
    }

    private void Update()
    {
        Vector3 localPos = transform.localPosition;
        Vector3 targetPos = target.localPosition;
        Vector3 desirePos = new Vector3(targetPos.x + origin.x, targetPos.y + origin.y, localPos.z);
        transform.localPosition = Vector3.SmoothDamp(localPos, desirePos, ref velocity, smoothing);

        Vector3 offset = transform.localPosition - origin;
        Vector3 clampOffset = new Vector3
        (
            Mathf.Clamp(offset.x, -limits.x, limits.x),
            Mathf.Clamp(offset.y, -limits.y, limits.y)
        );
        transform.localPosition = origin + clampOffset;
    }

    private void OnDrawGizmos()
    {
        Vector3 localOffset = Application.isPlaying ? origin : transform.localPosition;
        Vector3 center = transform.parent.position + localOffset;
        Vector3 right = transform.right * limits.x;
        Vector3 up = transform.up * limits.y;

        Vector3 topLeft = center - right + up;
        Vector3 topRight = center + right + up;
        Vector3 botLeft = center - right - up;
        Vector3 botRight = center + right - up;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(botLeft, botRight);
        Gizmos.DrawLine(topLeft, botLeft);
        Gizmos.DrawLine(topRight, botRight);
    }
}
