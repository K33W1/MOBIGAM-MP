using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class SaveManager : MonoBehaviourSingleton<SaveManager>
{
    [Header("Managers")]
    [SerializeField] private SaveSystem saveSystem = null;
    [SerializeField] private Shop shop = null;

    protected override void SingletonAwake()
    {
        saveSystem.Load();
        shop.Initialize();
    }

    protected override void SingletonOnDestroy()
    {
        
    }

    private void OnApplicationQuit()
    {
        saveSystem.Save();
    }
}
