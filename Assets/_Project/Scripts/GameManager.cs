using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Header("Managers")]
    [SerializeField] private SaveSystem saveSystem = null;

    private View lastView = null;
    private View pauseView = null;

    private bool isPaused = false;

    protected override void SingletonAwake()
    {
        pauseView = UIServiceLocator.Instance.PauseView;

        saveSystem.Load();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            lastView = UIServiceLocator.Instance.CurrentView;
            pauseView.Show();
        }
        else
        {
            Time.timeScale = 1f;
            lastView.Show();
            lastView = null;
        }
    }

    protected override void SingletonOnDestroy()
    {

    }

    private void OnApplicationQuit()
    {
        saveSystem.Save();
    }
}
