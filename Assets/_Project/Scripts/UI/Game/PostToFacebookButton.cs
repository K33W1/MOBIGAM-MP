using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PostToFacebookButton : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI text = null;

    private void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnButtonClicked()
    {
        FacebookManager.Instance.ScreenshotAndUpload();
    }

    public void Enable()
    {
        button.interactable = true;
        text.text = "Post to FB";
    }

    public void Disable()
    {
        button.interactable = false;
        text.text = "No internet for a post in FB";
    }
}
