using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private View pauseView = null;

    private bool isPaused = false;

    protected override void SingletonAwake()
    {
        pauseView = UIServiceLocator.Instance.PauseView;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseView.Show();
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
