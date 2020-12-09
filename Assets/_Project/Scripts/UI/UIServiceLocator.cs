using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
[DefaultExecutionOrder(-1000)]
public class UIServiceLocator : MonoBehaviourSingleton<UIServiceLocator>
{
    [Header("References")]
    [SerializeField] private PlayerDeathView loseView = null;
    [SerializeField] private View winView = null;
    [SerializeField] private View pauseView = null;
    [SerializeField] private PlayerHealthUI healthUI = null;
    [SerializeField] private ScoreText scoreText = null;
    [SerializeField] private Joystick playerJoystick = null;

    public View CurrentView => uiController.CurrentView;
    public PlayerDeathView LoseView => loseView;
    public View WinView => winView;
    public View PauseView => pauseView;
    public PlayerHealthUI HealthUI => healthUI;
    public ScoreText ScoreText => scoreText;
    public Joystick PlayerJoystick => playerJoystick;

    private UIController uiController = null;

    protected override void SingletonAwake()
    {
        uiController = GetComponent<UIController>();
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
