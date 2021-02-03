using Kiwi.DataObject;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LevelSelectMenu : MonoBehaviour
{
    [Header("Spawned Buttons")]
    [SerializeField] private LevelSelectButton levelSelectButtonPrefab = null;

    [Header("Settings")]
    [SerializeField] private string levelName = "Level ";
    [SerializeField, Min(0)] private int levelsCount = 0;

    private IntList unlockedLevels = null;
    private IntValue levelToLoad = null;

    private void Awake()
    {
        unlockedLevels = AssetBundleManager.Instance.GetAsset<IntList>("configs", "Unlocked Levels");
        levelToLoad = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Level To Load");
    }

    public void Refresh()
    {
        InitLevelSelectButtons();
    }

    public void LoadLevel(int index)
    {
        if (unlockedLevels.Contains(index))
        {
            levelToLoad.Value = index;
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogError("Tried to load locked level!");
        }
    }

    private void InitLevelSelectButtons()
    {
        LevelSelectButton[] existingButtons = GetComponentsInChildren<LevelSelectButton>();
        foreach (LevelSelectButton button in existingButtons)
        {
            Destroy(button.gameObject);
        }

        for (int i = 0; i < levelsCount; i++)
        {
            LevelSelectButton levelSelectButton =
                Instantiate(levelSelectButtonPrefab, transform);
            levelSelectButton.Initialize(this, i, unlockedLevels.Contains(i));
        }
    }
}
