using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ControlsOptionsUI : MonoBehaviour
{
    private TMP_Dropdown dropdown = null;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.onValueChanged.AddListener(OnOptionChanged);
    }

    private void OnOptionChanged(int index)
    {
        ControlsManager.Instance.ChangeControls((Controls)index);
    }
}
