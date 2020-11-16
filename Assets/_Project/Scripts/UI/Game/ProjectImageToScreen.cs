using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
public class ProjectImageToScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Transform target = null;

    private Image image = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void LateUpdate()
    {
        Vector2 viewportPos = camera.WorldToViewportPoint(target.position);
        Vector2 screenPos = new Vector2(viewportPos.x * Screen.width, viewportPos.y * Screen.height);
        image.rectTransform.position = screenPos;
    }
}
