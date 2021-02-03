using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class LevelSelectButton : MonoBehaviour
{
    private LevelSelectMenu levelSelectMenu = null;
    private TextMeshProUGUI levelText = null;
    private Button button = null;
    
    private int index = 0;

    private void Awake()
    {
        levelText = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }

    public void Initialize(LevelSelectMenu levelSelectMenu, int index, bool isUnlocked)
    {
        this.levelSelectMenu = levelSelectMenu;
        this.index = index;
        
        levelText.text = (index + 1).ToString();
        button.interactable = isUnlocked;
    }

    private void OnButtonClick()
    {
        levelSelectMenu.LoadLevel(index);
    }
}
