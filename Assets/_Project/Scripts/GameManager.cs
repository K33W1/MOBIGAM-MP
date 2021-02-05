using Kiwi.Core;
using UnityEngine;
using UnityEngine.Advertisements;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private bool isPaused = false;

    private bool wasBannerShownBeforePause = false;

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

            wasBannerShownBeforePause = AdManager.Instance.IsBannerShow;
            AdManager.Instance.HideBannerAd();
        }
        else
        {
            Time.timeScale = 1f;
            UIController.Instance.ShowLastView();

            if (wasBannerShownBeforePause)
            {
                AdManager.Instance.ShowBannerAd(BannerPosition.TOP_CENTER);
            }
        }
    }

    protected override void SingletonOnDestroy()
    {

    }
}
