using Kiwi.DataObject;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerDeathView : View
{
    [Header("References")]
    [SerializeField] private IntValue scoreValue = null;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI text = null;

    protected override void OnShow()
    {
        text.text = scoreValue.Value.ToString().PadLeft(6, '0');
    }

    protected override void OnHide()
    {

    }
}
