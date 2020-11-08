using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleInPlaceRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform objectToRotate = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float torque = 1f;

    private Vector3 axisOfRotation = new Vector3();

    private void OnEnable()
    {
        axisOfRotation = Random.insideUnitSphere.normalized;
    }

    private void Update()
    {
        float angle = torque * Time.deltaTime;
        objectToRotate.rotation *= Quaternion.AngleAxis(angle, axisOfRotation);
    }
}
