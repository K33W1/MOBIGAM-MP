using UnityEngine;

[DisallowMultipleComponent]
public class QuitButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        Application.Quit();
    }
}
