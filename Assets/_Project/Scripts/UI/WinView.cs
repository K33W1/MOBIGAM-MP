using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class WinView : View
{
    [Header("References")]
    [SerializeField] private IntValue scoreValue = null;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText = null;

    protected override void OnShow()
    {
        scoreText.text = scoreValue.Value.ToString().PadLeft(6, '0');
    }

    protected override void OnHide()
    {
        
    }
}
