using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[DefaultExecutionOrder(-2000)]
public class LevelLoader : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bossWaypoint = null;
    [SerializeField] private Transform[] enemySpawnLocations = null;
    [SerializeField] private EnemyWaypoints enemyWaypoints = null;

    private AssetBundleManager AssetBundleManager => AssetBundleManager.Instance;

    private void Start()
    {
        // Get bundles
        AssetBundle animationsBundle = AssetBundleManager.GetAssetBundle("animations");
        AssetBundle audioBundle = AssetBundleManager.GetAssetBundle("audio");
        AssetBundle configsBundle = AssetBundleManager.GetAssetBundle("configs");
        AssetBundle imagesBundle = AssetBundleManager.GetAssetBundle("images");
        AssetBundle materialsBundle = AssetBundleManager.GetAssetBundle("materials");
        AssetBundle modelsBundle = AssetBundleManager.GetAssetBundle("models");
        AssetBundle prefabsBundle = AssetBundleManager.GetAssetBundle("prefabs");
        AssetBundle shadersBundle = AssetBundleManager.GetAssetBundle("shaders");
        AssetBundle fontsBundle = AssetBundleManager.GetAssetBundle("fonts");

        // Instantiate prefab assets
        GameObject gameUI = InstantiateAsset(prefabsBundle, "Game UI");
        GameObject musicPlayer = InstantiateAsset(prefabsBundle, "Music Player");
        GameObject vfx = InstantiateAsset(prefabsBundle, "VFX");
        Player player = InstantiateAsset<Player>(prefabsBundle, "Player");
        EnemyManager enemyManager = InstantiateAsset<EnemyManager>(prefabsBundle, "Enemy Manager");
        GameObject asteroidManager = InstantiateAsset(prefabsBundle, "Asteroid Manager");
        GameObject bulletPooler = InstantiateAsset(prefabsBundle, "Bullet Pooler");
        GameObject homingProjectilePooler = InstantiateAsset(prefabsBundle, "Homing Projectile Pooler");
        GameObject debrisPooler = InstantiateAsset(prefabsBundle, "Debris Pooler");
        ExplosionPooler explosionPooler = InstantiateAsset<ExplosionPooler>(prefabsBundle, "Explosion Pooler");

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

        // Get components
        PlayerFiringButton playerFiringButton = gameUI.GetComponentInChildren<PlayerFiringButton>();
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        EnemyPooler[] enemyPoolers = enemyManager.GetComponents<EnemyPooler>();

        // Initializations
        enemyManager.Boss.Initialize(player.ModelTransform, bossWaypoint);
        enemyManager.Initialize(enemySpawnLocations);
        playerFiringButton.Initialize(playerInput);
        foreach (EnemyPooler enemyPooler in enemyPoolers)
            enemyPooler.Initialize(enemyWaypoints, player.transform);
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
