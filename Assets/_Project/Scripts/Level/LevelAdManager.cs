using Kiwi.DataObject;
using Kiwi.Events;
using UnityEngine;
using UnityEngine.Advertisements;

[DisallowMultipleComponent]
public class LevelAdManager : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("In seconds")]
    [SerializeField, Min(0)] private float timeBeforeAd = 180f;
    [SerializeField, Min(0)] private int reward = 10;
    [SerializeField] private bool forceShowAdOnGameOver = false;

    private static AdManager AdManager => AdManager.Instance;

    private GameEvent gameOver = null;

    private void Awake()
    {
        gameOver = AssetBundleManager.Instance.GetAsset<GameEvent>("configs", "Game Over");
    }

    private void OnEnable()
    {
        AdManager.AdFinished += OnAdFinished;
        gameOver.RegisterListener(OnGameOver);
    }

    private void Start()
    {
        AdManager.ShowBannerAd(BannerPosition.BOTTOM_CENTER);
    }

    private void OnGameOver()
    {
        AdManager.HideBannerAd();

        if (forceShowAdOnGameOver || (IsEnoughTimePassed() && Application.internetReachability != NetworkReachability.NotReachable))
        {
            AdManager.PlayInterstitialAd();
        }
    }

    private bool IsEnoughTimePassed()
    {
        return Time.time - AdManager.LastTimeAdPlayed >= timeBeforeAd;
    }

    private void OnAdFinished(object sender, AdFinishEventArgs e)
    {
        if (e.ShowResult == ShowResult.Finished)
        {
            IntValue money = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Money");
            money.Value += reward;
        }
    }

    private void OnDisable()
    {
        if (AdManager != null)
            AdManager.AdFinished -= OnAdFinished;

        gameOver.UnregisterListener(OnGameOver);
    }
}
