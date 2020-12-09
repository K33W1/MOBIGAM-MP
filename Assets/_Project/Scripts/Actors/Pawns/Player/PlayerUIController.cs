using UnityEngine;

[DisallowMultipleComponent]
public class PlayerUIController : MonoBehaviour
{
    private PlayerDeathView deathView = null;
    private PlayerHealthUI healthUI = null;
    private ScoreText scoreText = null;

    private void Awake()
    {
        deathView = UIServiceLocator.Instance.LoseView;
        healthUI = UIServiceLocator.Instance.HealthUI;
        scoreText = UIServiceLocator.Instance.ScoreText;
    }

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
