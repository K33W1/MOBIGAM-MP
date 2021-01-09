using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class MainMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
    }
}
