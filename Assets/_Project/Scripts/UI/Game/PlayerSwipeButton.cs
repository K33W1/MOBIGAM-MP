using System;
using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class PlayerSwipeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float minSwipeDistance = 10f;
    [SerializeField, Min(0)] private float minSwipeDuration = 0.2f;
    [SerializeField, Min(0)] private float maxSwipeDuration = 1.5f;

    public event Action SwipeLeft;
    public event Action SwipeRight;

    private float timer = 0f;
    private bool isDown = false;
    private Vector2 startPos;

    private void Update()
    {
        if (isDown)
        {
            timer += Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        timer = 0f;
        isDown = true;
        startPos = e.position;
    }

    public void OnPointerUp(PointerEventData e)
    {
        isDown = false;

        if (timer < minSwipeDuration || timer > maxSwipeDuration)
            return;
        
        Vector2 diff = e.position - startPos;
        float dist = diff.magnitude;

        if (dist < minSwipeDistance)
            return;

        if (Mathf.Abs(diff.x) < Mathf.Abs(diff.y))
            return;

        if (diff.x > 0)
        {
            SwipeRight?.Invoke();
        }
        else
        {
            SwipeLeft?.Invoke();
        }
    }
}
