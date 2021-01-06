using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class PlayAgainButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
