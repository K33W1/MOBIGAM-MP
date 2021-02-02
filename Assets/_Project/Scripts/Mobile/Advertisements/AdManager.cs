using System;
using System.Collections;
using Kiwi.Core;
using UnityEngine;
using UnityEngine.Advertisements;
using ShowResult = UnityEngine.Advertisements.ShowResult;

public class AdManager : MonoBehaviourSingleton<AdManager>, IUnityAdsListener
{
    [Header("Settings")]
    [SerializeField] private bool isTestBuild = false;

    public event Action AdStarted;
    public event Action<string> AdErrored;
    public event EventHandler<AdFinishEventArgs> AdFinished;

    public const string InterstitialAd = "video";
    public const string RewardedVideoAd = "rewardedVideo";
    public const string BannerAd = "banner";

#if UNITY_ANDROID || UNITY_EDITOR
    private const string StoreID = "3910933";
#elif UNITY_IOS
    private const string StoreID = "3910932";
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
        if (!Advertisement.Banner.isLoaded)
        {
            BannerLoadOptions loadOptions = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };

            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Load(BannerAd, loadOptions);
        }
        else
        {
            Advertisement.Banner.Show(BannerAd);
        }
    }

    private void OnBannerLoaded()
    {
        Advertisement.Banner.Show(BannerAd);
    }

    private void OnBannerError(string error)
    {
        Debug.Log("Banner Error: " + error);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private IEnumerator PlayInterstitialAdCoroutine()
    {
        while (!Advertisement.IsReady(InterstitialAd))
            yield return 0;

        HideBannerAd();
        Advertisement.Show(InterstitialAd);
        LastTimeAdPlayed = Time.time;
    }

    private IEnumerator PlayRewardedAdCoroutine()
    {
        while (!Advertisement.IsReady(RewardedVideoAd))
            yield return 0;

        HideBannerAd();
        Advertisement.Show(RewardedVideoAd);
        LastTimeAdPlayed = Time.time;
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {
        AdStarted?.Invoke();
    }

    public void OnUnityAdsDidError(string message)
    {
        AdErrored?.Invoke(message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        AdFinished?.Invoke(this, new AdFinishEventArgs(placementId, showResult));
    }

    protected override void SingletonOnDestroy()
    {

    }
}
