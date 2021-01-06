using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LevelSelectMenu : MonoBehaviour
{
    [Header("Spawned Buttons")]
    [SerializeField] private LevelSelectButton levelSelectButtonPrefab = null;

    [Header("Settings")]
    [SerializeField] private string levelNamePrefix = "Level ";
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
        SceneManager.LoadScene(levelNamePrefix + (index + 1));
    }
}
