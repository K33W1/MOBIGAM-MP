using Kiwi.Common;
using UnityEngine;
using UnityEngine.Advertisements;

[DisallowMultipleComponent]
public class AdvertisementManager : MonoBehaviourSingleton<AdvertisementManager>, IUnityAdsListener
{
    [Header("Settings")]
    [SerializeField] private bool isTestBuild = false;

    private const string PlayStoreId = "3910932";
    private const string AppStoreId = "3910933";

    private const string InterstitialAd = "video";
    private const string RewardedVideoAd = "rewardedVideo";

    protected override void SingletonAwake()
    {
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        Advertisement.AddListener(this);

        if (Application.platform == RuntimePlatform.Android)
        {
            Advertisement.Initialize(PlayStoreId, isTestBuild);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Advertisement.Initialize(AppStoreId, isTestBuild);
        }
        else
        {
            Debug.LogError("Could not determine platform!");
        }
    }

    [ContextMenu("Play Interstitial Advertisement")]
    private void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(InterstitialAd))
        {
            Debug.Log("Advertisement not ready!");
            return;
        }

        Advertisement.Show(InterstitialAd);
    }

    [ContextMenu("Play Rewarded Video Advertisement")]
    private void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(RewardedVideoAd))
        {
            Debug.Log("Advertisement not ready!");
            return;
        }

        Advertisement.Show(RewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
         
    }

    public void OnUnityAdsDidStart(string placementId)
    {
         
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed: OnAdFailed(placementId); break;
            case ShowResult.Skipped: OnAdSkipped(placementId); break;
            case ShowResult.Finished: OnAdFinished(placementId); break;
        }
    }

    private void OnAdFailed(string placementId)
    {
        Debug.Log("Ad failed!");
    }

    private void OnAdSkipped(string placementId)
    {
        Debug.Log("Ad was skipped!");
    }

    private void OnAdFinished(string placementId)
    {
        if (placementId == RewardedVideoAd)
        {
            Debug.Log("Finished rewarded video ad!");
        }
        else if (placementId == InterstitialAd)
        {
            Debug.Log("Finished interstitial ad!");
        }
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
