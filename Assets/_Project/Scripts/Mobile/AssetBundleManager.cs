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
    private Dictionary<AssetBundle, Dictionary<string, Object>> loadedAssets =
        new Dictionary<AssetBundle, Dictionary<string, Object>>();

    protected override void SingletonAwake()
    {
        
    }

    public T GetAsset<T>(string bundleName, string assetName) where T : Object
    {
        AssetBundle assetBundle = GetAssetBundle(bundleName);

        if (loadedAssets.TryGetValue(assetBundle, out var assets))
        {
            if (assets.TryGetValue(assetName, out var asset))
            {
                return (T) asset;
            }
        }
        else
        {
            assets = new Dictionary<string, Object>();
            loadedAssets.Add(assetBundle, assets);
        }

        T loadedAsset = assetBundle.LoadAsset<T>(assetName);
        assets.Add(assetName, loadedAsset);
        return loadedAsset;
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

    protected override void SingletonOnDestroy()
    {
        
    }
}
