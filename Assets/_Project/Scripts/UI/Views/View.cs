using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Canvas))]
public abstract class View : MonoBehaviour
{
    public event Action<View> Showed;

    private Canvas canvas = null;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
    }

    public void Show()
    {
        canvas.enabled = true;
        OnShow();
        Showed?.Invoke(this);
    }

    public void Hide()
    {
        OnHide();
        canvas.enabled = false;
    }

    protected abstract void OnShow();

    protected abstract void OnHide();
}
