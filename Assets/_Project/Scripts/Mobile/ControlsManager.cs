using Kiwi.Core;
using UnityEngine;

[DisallowMultipleComponent]
public class ControlsManager : MonoBehaviourSingleton<ControlsManager>
{
    [SerializeField] private MobileControls defaultMobileControls = MobileControls.Joystick;

    public MobileControls CurrentMobileControls { get; private set; } = MobileControls.Joystick;

    protected override void SingletonAwake()
    {
        
    }

    private void Start()
    {
        ChangeControls(defaultMobileControls);
    }

    public void ChangeControls(MobileControls mobileControls)
    {
        CurrentMobileControls = mobileControls;
        
        if (mobileControls == MobileControls.Joystick)
        {
            UIServiceLocator.Instance.PlayerJoystick.gameObject.SetActive(true);
        }
        else if (mobileControls == MobileControls.Gyroscope)
        {
            UIServiceLocator.Instance.PlayerJoystick.gameObject.SetActive(false);
            DeviceRotation.ResetReferenceRotation();
        }
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
