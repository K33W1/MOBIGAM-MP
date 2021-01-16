using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private bool isPaused = false;

    protected override void SingletonAwake()
    {
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            UIServiceLocator.Instance.PauseView.Show();
        }
        else
        {
            Time.timeScale = 1f;
            UIController.Instance.ShowLastView();
        }
    }

    protected override void SingletonOnDestroy()
    {

    }
}
