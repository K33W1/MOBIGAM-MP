using UnityEngine;

[DisallowMultipleComponent]
public class MainMenuPlayButton : MonoBehaviour
{
    [SerializeField] private View levelSelectView = null;

    public void OnClick()
    {
        levelSelectView.Show();
    }
}
