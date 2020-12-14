using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraAnchor = null;

    [Header("Settings")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float landscapeZ = -8f;
    [SerializeField] private float portraitZ = -16f;

    private void Update()
    {
        GeneralOrientation generalOrientation =
            ScreenOrientationManager.Instance.CurrentGeneralOrientation;

        float z = generalOrientation == GeneralOrientation.Landscape
            ? landscapeZ
            : portraitZ;

        Vector3 currPos = cameraAnchor.position;
        Vector3 targetPos = new Vector3(currPos.x, currPos.y, z);

        cameraAnchor.position =
            Vector3.Lerp(currPos, targetPos, speed * Time.deltaTime);
    }
}
