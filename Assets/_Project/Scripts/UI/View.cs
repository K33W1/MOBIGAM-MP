using System;
using UnityEngine;

[DisallowMultipleComponent]
public class View : MonoBehaviour
{
    public event Action<View> Showed;

    public void Show()
    {
        gameObject.SetActive(true);
        OnShow();
        Showed?.Invoke(this);
    }

    public void Hide()
    {
        OnHide();
        gameObject.SetActive(false);
    }

    protected virtual void OnShow()
    {

    }

    protected virtual void OnHide()
    {

    }
}
