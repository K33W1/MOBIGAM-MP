using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
