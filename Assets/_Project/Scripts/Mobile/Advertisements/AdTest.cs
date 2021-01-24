using UnityEngine;
using UnityEngine.Advertisements;

[DisallowMultipleComponent]
public class AdTest : MonoBehaviour
{
    private void Start()
    {
        //AdManager.Instance.ShowBannerAd(BannerPosition.TOP_CENTER);
        //AdManager.Instance.PlayInterstitialAd();
        AdManager.Instance.PlayRewardedAd();
    }
}
