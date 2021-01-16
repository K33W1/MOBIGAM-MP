using System.IO;
using System.Collections.Generic;
using Kiwi.Common;
using UnityEngine;

public class AssetBundleManager : MonoBehaviourSingleton<AssetBundleManager>
{
#if UNITY_EDITOR
    public string AssetBundlesPath => Application.streamingAssetsPath;
#elif UNITY_ANDROID
    public string AssetBundlesPath => Application.persistentDataPath;
#endif

    private Dictionary<string, AssetBundle> loadedAssetBundles =
        new Dictionary<string, AssetBundle>();

    protected override void SingletonAwake()
    {
        
    }

    public AssetBundle GetAssetBundle(string assetBundleName)
    {
        if (loadedAssetBundles.TryGetValue(assetBundleName, out var assetBundle))
            return assetBundle;

        string localPath = Path.Combine(AssetBundlesPath, assetBundleName);
        AssetBundle newAssetBundle = AssetBundle.LoadFromFile(localPath);

        if (newAssetBundle == null)
        {
            Debug.LogError($"Asset bundle {assetBundleName} was not found!");
            return null;
        }

        loadedAssetBundles.Add(assetBundleName, newAssetBundle);
        return newAssetBundle;
    }

    public T GetAsset<T>(string bundleName, string assetName) where T : Object
    {
        AssetBundle assetBundle = GetAssetBundle(bundleName);
        return assetBundle != null ? assetBundle.LoadAsset<T>(assetName) : null;
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
