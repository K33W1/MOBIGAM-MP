using System;
using System.Collections;
using Kiwi.Common;
using UnityEngine;
using UnityEngine.Advertisements;

[DisallowMultipleComponent]
public class AdManager : MonoBehaviourSingleton<AdManager>, IUnityAdsListener
{
    [Header("Settings")]
    [SerializeField] private bool isTestBuild = false;

    public event EventHandler<AdFinishEventArgs> AdFinished;

    public const string InterstitialAd = "video";
    public const string RewardedVideoAd = "rewardedVideo";
    public const string BannerAd = "banner";

#if UNITY_ANDROID || UNITY_EDITOR
    private const string StoreID = "3910932";
#elif UNITY_IOS
    private const string StoreID = "3910933";
#endif

    public float LastTimeAdPlayed { get; private set; }

    protected override void SingletonAwake()
    {
        LastTimeAdPlayed = Time.time;
        Advertisement.AddListener(this);
        Advertisement.Initialize(StoreID, isTestBuild);
    }

    [ContextMenu("Play Interstitial Advertisement")]
    public void PlayInterstitialAd()
    {
        StartCoroutine(PlayInterstitialAdCoroutine());
    }

    [ContextMenu("Play Rewarded Video Advertisement")]
    public void PlayRewardedAd()
    {
        StartCoroutine(PlayRewardedAdCoroutine());
    }

    public void ShowBannerAd(BannerPosition bannerPosition)
    {
        StartCoroutine(ShowBannerAdCoroutine(bannerPosition));
    }

    public void HideBannerAd()
    {
        StopAllCoroutines();

        if (Advertisement.Banner.isLoaded)
        {
            Advertisement.Banner.Hide();
        }
        else
        {
            Debug.LogWarning("Banner ad is already hidden!");
        }
    }

    private IEnumerator PlayInterstitialAdCoroutine()
    {
        while (!Advertisement.IsReady(InterstitialAd))
            yield return 0;

        Advertisement.Show(InterstitialAd);
        LastTimeAdPlayed = Time.time;
    }

    private IEnumerator PlayRewardedAdCoroutine()
    {
        while (!Advertisement.IsReady(RewardedVideoAd))
            yield return 0;

        Advertisement.Show(RewardedVideoAd);
        LastTimeAdPlayed = Time.time;
    }

    private IEnumerator ShowBannerAdCoroutine(BannerPosition bannerPosition)
    {
        while (!Advertisement.IsReady(BannerAd))
            yield return 0;

        Advertisement.Banner.SetPosition(bannerPosition);
        Advertisement.Banner.Show();
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
         Debug.LogError($"Advertisement error: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
         
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        AdFinished?.Invoke(this, new AdFinishEventArgs(placementId, showResult));
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
