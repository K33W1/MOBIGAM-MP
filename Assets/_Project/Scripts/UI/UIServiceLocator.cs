using Kiwi.Common;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[DefaultExecutionOrder(-1001)]
public class UIServiceLocator : MonoBehaviourSingleton<UIServiceLocator>
{
    [Header("References")]
    [SerializeField] private PlayerDeathView loseView = null;
    [SerializeField] private Slider bossHealthBar = null;
    [SerializeField] private View winView = null;
    [SerializeField] private View pauseView = null;
    [SerializeField] private RectTransform healthUI = null;
    [SerializeField] private PlayerSwipeButton playerSwipeButton = null;
    [SerializeField] private ScoreText scoreText = null;
    [SerializeField] private Joystick playerJoystick = null;
    [SerializeField] private RectTransform closePlayerReticle = null;
    [SerializeField] private RectTransform farPlayerReticle = null;
    [SerializeField] private Image[] playerHearts = null;

    public PlayerDeathView LoseView => loseView;
    public Slider BossHealthBar => bossHealthBar;
    public View WinView => winView;
    public View PauseView => pauseView;
    public RectTransform HealthUI => healthUI;
    public PlayerSwipeButton PlayerSwipeButton => playerSwipeButton;
    public ScoreText ScoreText => scoreText;
    public Joystick PlayerJoystick => playerJoystick;
    public RectTransform ClosePlayerReticle => closePlayerReticle;
    public RectTransform FarPlayerReticle => farPlayerReticle;
    public Image[] PlayerHearts => playerHearts;

    protected override void SingletonAwake()
    {
        
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
