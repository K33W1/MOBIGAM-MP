using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue stageScore = null;

    private TextMeshProUGUI text = null;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        stageScore.ValueChanged += i => text.text = i.ToString().PadLeft(6, '0');
    }
}
