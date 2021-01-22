using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class TogglePauseButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameManager.Instance.TogglePause();
    }
}
