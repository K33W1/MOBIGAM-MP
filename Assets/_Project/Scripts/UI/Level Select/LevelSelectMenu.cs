using Kiwi.DataObject;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LevelSelectMenu : MonoBehaviour
{
    [Header("Data Objects")]
    // [SerializeField] private IntValue levelToLoadDataObject = null;

    [Header("Spawned Buttons")]
    [SerializeField] private LevelSelectButton levelSelectButtonPrefab = null;

    [Header("Settings")]
    [SerializeField] private string levelName = "Level ";
    [SerializeField, Min(0)] private int levelsCount = 0;

    private void Start()
    {
        LevelSelectButton[] existingButtons =
            GetComponentsInChildren<LevelSelectButton>();
        foreach (LevelSelectButton button in existingButtons)
        {
            Destroy(button.gameObject);
        }

        for (int i = 0; i < levelsCount; i++)
        {
            LevelSelectButton levelSelectButton =
                Instantiate(levelSelectButtonPrefab, transform);
            levelSelectButton.Initialize(this, i);
        }
    }

    public void LoadLevel(int index)
    {
        IntValue levelAsset = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Level To Load");
        levelAsset.Value = index;
        SceneManager.LoadScene(levelName);
    }
}
