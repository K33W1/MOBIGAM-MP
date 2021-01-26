using UnityEngine;

[DisallowMultipleComponent]
public class PostToFacebookButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        FacebookManager.Instance.ScreenshotAndUpload();
    }
}
