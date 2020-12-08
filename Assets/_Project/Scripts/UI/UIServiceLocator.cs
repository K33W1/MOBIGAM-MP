using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
[DefaultExecutionOrder(-1000)]
public class UIServiceLocator : MonoBehaviourSingleton<UIServiceLocator>
{
    [Header("References")]
    [SerializeField] private View pauseView = null;
    [SerializeField] private Joystick playerJoystick = null;

    public View CurrentView => uiController.CurrentView;
    public View PauseView => pauseView;
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
