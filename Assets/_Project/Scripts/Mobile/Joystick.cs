using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float handleRange = 1;
    [SerializeField, Min(0)] private float deadZone = 0;

    [Header("References")]
    [SerializeField] private RectTransform background = null;
    [SerializeField] private RectTransform handle = null;

    public Vector2 Direction { get; private set; }

    private Canvas canvas;
    private Camera cam;

    private RectTransform baseRect = null;

    private void Awake()
    {
        baseRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        Vector2 center = new Vector2(0.5f, 0.5f);
        background.pivot = center;
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam = null;
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            cam = canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        Vector2 radius = background.sizeDelta * 0.5f;

        Vector2 input = (eventData.position - position) / (radius * canvas.scaleFactor);
        float inputMagnitude = input.magnitude;

        if (inputMagnitude > deadZone)
        {
            if (inputMagnitude > 1)
            {
                input = input.normalized;
            }
        }
        else
        {
            input = Vector2.zero;
        }

        handle.anchoredPosition = input * radius * handleRange;

        Direction = input;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
