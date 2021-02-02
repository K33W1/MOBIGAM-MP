using UnityEngine;

[DisallowMultipleComponent]
public class PauseButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        GameManager.Instance.TogglePause();
    }
}
