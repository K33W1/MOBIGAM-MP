using Kiwi.DataObject;
using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
public class LevelManager : MonoBehaviour
{
    private GameEvent bossDeath = null;
    private IntList unlockedLevels = null;
    private IntValue levelScore = null;
    private IntValue levelToLoad = null;

    private void Awake()
    {
        bossDeath = AssetBundleManager.Instance.GetAsset<GameEvent>("configs", "Boss Death");
        unlockedLevels = AssetBundleManager.Instance.GetAsset<IntList>("configs", "Unlocked Levels");
        levelScore = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Level Score");
        levelToLoad = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Level To Load");
    }

    private void OnEnable()
    {
        bossDeath.RegisterListener(OnWin);
    }

    private void Start()
    {
        levelScore.Value = 0;
    }

    private void OnWin()
    {
        unlockedLevels.Add(levelToLoad.Value + 1);
    }

    private void OnDisable()
    {
        bossDeath.UnregisterListener(OnWin);
    }

    private void OnDestroy()
    {
        levelScore.Value = 0;
    }
}
