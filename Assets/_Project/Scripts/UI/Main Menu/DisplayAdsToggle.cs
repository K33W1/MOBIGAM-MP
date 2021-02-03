using Kiwi.DataObject;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class DisplayAdsToggle : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private BoolValue displayAds = null;

    private Toggle toggle = null;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        toggle.SetIsOnWithoutNotify(displayAds.Value);
    }

    public void OnToggleValueChanged(bool value)
    {
        displayAds.Value = value;
    }
}