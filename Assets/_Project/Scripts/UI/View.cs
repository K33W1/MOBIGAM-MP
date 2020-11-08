using UnityEngine;

public abstract class View : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        OnShow();
    }

    public void Hide()
    {
        OnHide();
        gameObject.SetActive(false);
    }

    protected abstract void OnShow();
    protected abstract void OnHide();
}
