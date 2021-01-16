using TMPro;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    private AssetBundleManager AssetBundleManager => AssetBundleManager.Instance;

    private void Awake()
    {
        // Get bundles
        AssetBundle configsBundle = AssetBundleManager.GetAssetBundle("configs");
        AssetBundle shadersBundle = AssetBundleManager.GetAssetBundle("shaders");
        AssetBundle fontsBundle = AssetBundleManager.GetAssetBundle("fonts");
        AssetBundle materialsBundle = AssetBundleManager.GetAssetBundle("materials");
        AssetBundle prefabsBundle = AssetBundleManager.GetAssetBundle("prefabs");

        // Instantiate prefab assets
        GameObject mainMenuUI = InstantiateAsset(prefabsBundle, "Main Menu UI");

#if UNITY_EDITOR
        // Reconnect shaders of all materials when in editor
        Material[] allMaterials = materialsBundle.LoadAllAssets<Material>();
        foreach (Material mat in allMaterials)
        {
            mat.shader = Shader.Find(mat.shader.name);
        }

        TMP_FontAsset[] fontAssets = fontsBundle.LoadAllAssets<TMP_FontAsset>();
        foreach (TMP_FontAsset fontAsset in fontAssets)
        {
            Material fontMaterial = fontAsset.material;
            fontMaterial.shader = Shader.Find(fontMaterial.shader.name);
        }
#endif
    }

    private GameObject InstantiateAsset(AssetBundle assetBundle, string assetName)
    {
        GameObject asset = assetBundle.LoadAsset<GameObject>(assetName);
        return Instantiate(asset);
    }

    private T InstantiateAsset<T>(AssetBundle assetBundle, string assetName) where T : Component
    {
        return InstantiateAsset(assetBundle, assetName).GetComponent<T>();
    }
}
