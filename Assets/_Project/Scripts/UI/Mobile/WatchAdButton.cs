using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class WatchAdButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        AdManager.Instance.AdFinished += OnAdFinished;
    }

    public void OnButtonClick()
    {
        AdManager.Instance.PlayRewardedAd();
    }

    private void OnAdFinished(object sender, AdFinishEventArgs e)
    {
        if (e.ShowResult == ShowResult.Finished)
        {
            button.interactable = false;
        }
    }
}
