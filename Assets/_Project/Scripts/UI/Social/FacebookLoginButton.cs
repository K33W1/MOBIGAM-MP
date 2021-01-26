using UnityEngine;

[DisallowMultipleComponent]
public class FacebookLoginButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        FacebookManager.Instance.Login();
    }
}
