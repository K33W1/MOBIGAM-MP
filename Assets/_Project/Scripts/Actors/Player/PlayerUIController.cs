using UnityEngine;

[DisallowMultipleComponent]
public class PlayerUIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private PlayerDeathView deathView = null;
    [SerializeField] private PlayerHealthUI healthUI = null;
    [SerializeField] private ScoreText scoreText = null;

    private void Start()
    {
        healthUI.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public void OnAfterDeath()
    {
        healthUI.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        deathView.Show();
    }
}
