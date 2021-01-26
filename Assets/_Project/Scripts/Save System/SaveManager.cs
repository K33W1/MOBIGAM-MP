using Kiwi.Core;
using UnityEngine;

[DisallowMultipleComponent]
public class SaveManager : MonoBehaviourSingleton<SaveManager>
{
    private SaveSystem saveSystem = null;
    private Shop shop = null;

    protected override void SingletonAwake()
    {
        saveSystem = AssetBundleManager.Instance.GetAsset<SaveSystem>("configs", "Save System");
        shop = AssetBundleManager.Instance.GetAsset<Shop>("configs", "Shop");

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
