using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class SaveManager : MonoBehaviourSingleton<SaveManager>
{
    [Header("Managers")]
    [SerializeField] private SaveSystem saveSystem = null;

    protected override void SingletonAwake()
    {
        saveSystem.Load();
    }

    protected override void SingletonOnDestroy()
    {
        
    }

    private void OnApplicationQuit()
    {
        saveSystem.Save();
    }
}
