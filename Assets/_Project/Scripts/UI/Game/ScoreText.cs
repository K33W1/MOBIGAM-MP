using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IntValue levelScore = null;

    private TextMeshProUGUI text = null;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        levelScore.ValueChanged += i => text.text = i.ToString().PadLeft(6, '0');
    }
}
