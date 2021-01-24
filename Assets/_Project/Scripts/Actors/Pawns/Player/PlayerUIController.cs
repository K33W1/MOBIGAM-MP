using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerUIController : MonoBehaviour
{
    [Header("Game Event")]
    [SerializeField] private GameEvent gameOver = null;

    private PlayerDeathView deathView = null;
    private RectTransform healthUI = null;
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
        gameOver.Raise();

        healthUI.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        deathView.Show();
    }
}
