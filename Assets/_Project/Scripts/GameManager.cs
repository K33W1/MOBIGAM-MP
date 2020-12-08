using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Header("Managers")]
    [SerializeField] private SaveSystem saveSystem = null;

    [Header("Views")]
    [SerializeField] private View gameView = null;
    [SerializeField] private View pauseView = null;

    private bool isPaused = false;

    protected override void SingletonAwake()
    {
        saveSystem.Load();
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
            gameView.Show();
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
