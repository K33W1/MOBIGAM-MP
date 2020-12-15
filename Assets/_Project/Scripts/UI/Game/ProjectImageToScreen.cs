using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
public class ProjectImageToScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform target = null;

    private Image image = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void LateUpdate()
    {
        Vector2 viewportPos = playerCamera.WorldToViewportPoint(target.position);
        Vector2 screenPos = new Vector2(viewportPos.x * Screen.width, viewportPos.y * Screen.height);
        image.rectTransform.position = screenPos;
    }
}
