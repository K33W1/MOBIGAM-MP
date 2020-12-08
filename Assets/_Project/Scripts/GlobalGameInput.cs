using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class GlobalGameInput : MonoBehaviourSingleton<GlobalGameInput>
{
    protected override void SingletonAwake()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.TogglePause();
        }
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
