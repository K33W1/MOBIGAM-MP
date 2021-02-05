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
    private GameEvent bossSpawned = null;
    private BoolValue displayAds = null;

    private void Awake()
    {
        gameOver = AssetBundleManager.Instance.GetAsset<GameEvent>("configs", "Game Over");
        bossSpawned = AssetBundleManager.Instance.GetAsset<GameEvent>("configs", "Boss Spawned");
        displayAds = AssetBundleManager.Instance.GetAsset<BoolValue>("configs", "Display Ads");
    }

    private void OnEnable()
    {
        AdManager.AdFinished += OnAdFinished;
        bossSpawned.RegisterListener(OnGameOver);
        gameOver.RegisterListener(OnGameOver);
    }


    private void Start()
    {
        if (!displayAds.Value)
            return;

        AdManager.ShowBannerAd(BannerPosition.TOP_CENTER);
    }

    private void OnGameOver()
    {
        AdManager.HideBannerAd();

        if (!displayAds.Value)
            return;

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

        bossSpawned.UnregisterListener(OnGameOver);
        gameOver.UnregisterListener(OnGameOver);
    }
}
