using Kiwi.DataObject;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerInvulnerableToggle : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private BoolValue PlayerInvulnerablity = null;

    private Toggle toggle = null;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        toggle.SetIsOnWithoutNotify(PlayerInvulnerablity.Value);
    }

    public void OnToggleValueChanged(bool value)
    {
        PlayerInvulnerablity.Value = value;
    }
}
