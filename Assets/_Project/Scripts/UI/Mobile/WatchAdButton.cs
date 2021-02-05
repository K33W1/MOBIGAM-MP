using Kiwi.DataObject;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class WatchAdButton : MonoBehaviour
{
    private BoolValue displayAds = null;

    private Button button;
    private TextMeshProUGUI text = null;

    private void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        displayAds = AssetBundleManager.Instance.GetAsset<BoolValue>("configs", "Display Ads");
    }

    private void OnEnable()
    {
        AdManager.Instance.AdFinished += OnAdFinished;
    }

    private void Start()
    {
        button.interactable = false;
    }

    public void OnButtonClick()
    {
        AdManager.Instance.PlayRewardedAd();
    }

    public void Enable()
    {
        button.interactable = true;
        text.text = "Watch a Video for + 10 Money";
    }

    public void Disable()
    {
        button.interactable = false;
        text.text = "No internet for a bonus video!";
    }

    private void OnAdFinished(object sender, AdFinishEventArgs e)
    {
        if (e.PlacementID == AdManager.RewardedVideoAd && e.ShowResult == ShowResult.Finished)
        {
            button.interactable = false;
        }
    }

    private void OnDisable()
    {
        if (AdManager.Instance == null)
            return;

        AdManager.Instance.AdFinished -= OnAdFinished;
    }
}
