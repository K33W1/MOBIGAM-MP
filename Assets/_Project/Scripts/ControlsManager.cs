using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class ControlsManager : MonoBehaviourSingleton<ControlsManager>
{
    public Controls CurrentControls { get; private set; } = Controls.Joystick;

    protected override void SingletonAwake()
    {
        
    }

    public void ChangeControls(Controls controls)
    {
        CurrentControls = controls;
        
        if (controls == Controls.Joystick)
        {
            UIServiceLocator.Instance.PlayerJoystick.gameObject.SetActive(true);
        }
        else if (controls == Controls.Gyroscope)
        {
            UIServiceLocator.Instance.PlayerJoystick.gameObject.SetActive(false);
        }
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
