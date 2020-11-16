using UnityEngine;

[DisallowMultipleComponent]
public class OpenViewButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private View viewToOpenOnClick = null;

    public void OnClick()
    {
        viewToOpenOnClick.Show();
    }
}
