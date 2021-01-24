using Kiwi.DataObject;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[DefaultExecutionOrder(-2000)]
public class LevelLoader : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private PrefabArray[] levelSpawns = null;

    [Header("References")]
    [SerializeField] private Transform bossWaypoint = null;
    [SerializeField] private Transform[] enemySpawnLocations = null;
    [SerializeField] private EnemyWaypoints enemyWaypoints = null;

    private AssetBundleManager AssetBundleManager => AssetBundleManager.Instance;

    private void Start()
    {
        // Load bundles
        AssetBundleManager.GetAssetBundle("animations");
        AssetBundleManager.GetAssetBundle("audio");
        AssetBundleManager.GetAssetBundle("configs");
        AssetBundleManager.GetAssetBundle("images");
        AssetBundle materialsBundle = AssetBundleManager.GetAssetBundle("materials");
        AssetBundleManager.GetAssetBundle("models");
        AssetBundleManager.GetAssetBundle("prefabs");
        AssetBundleManager.GetAssetBundle("shaders");
        AssetBundle fontsBundle = AssetBundleManager.GetAssetBundle("fonts");

        // Instantiate prefab assets
        GameObject gameUI = InstantiateAsset("prefabs", "Game UI");
        GameObject musicPlayer = InstantiateAsset("prefabs", "Music Player");
        GameObject vfx = InstantiateAsset("prefabs", "VFX");
        Player player = InstantiateAsset<Player>("prefabs", "Player");
        EnemyManager enemyManager = InstantiateAsset<EnemyManager>("prefabs", "Enemy Manager");
        GameObject asteroidManager = InstantiateAsset("prefabs", "Asteroid Manager");
        GameObject bulletPooler = InstantiateAsset("prefabs", "Bullet Pooler");
        GameObject homingProjectilePooler = InstantiateAsset("prefabs", "Homing Projectile Pooler");
        GameObject debrisPooler = InstantiateAsset("prefabs", "Debris Pooler");
        ExplosionPooler explosionPooler = InstantiateAsset<ExplosionPooler>("prefabs", "Explosion Pooler");

        IntValue levelAsset = AssetBundleManager.Instance.GetAsset<IntValue>("configs", "Level To Load");
        PrefabArray allToSpawn = levelSpawns[levelAsset.Value];

        foreach (GameObject toSpawn in allToSpawn.Value)
        {
            InstantiateAsset("prefabs", toSpawn.name);
        }

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
        PlayerFiringButton playerFiringButton = gameUI.GetComponentInChildren<PlayerFiringButton>(true);
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        EnemyPooler[] enemyPoolers = enemyManager.GetComponents<EnemyPooler>();

        // Initializations
        enemyManager.Boss.Initialize(player.ModelTransform, bossWaypoint);
        enemyManager.Initialize(enemySpawnLocations);
        playerFiringButton.Initialize(playerInput);
        foreach (EnemyPooler enemyPooler in enemyPoolers)
            enemyPooler.Initialize(enemyWaypoints, player.ModelTransform);
    }

    private GameObject InstantiateAsset(string assetBundleName, string assetName)
    {
        GameObject asset = AssetBundleManager.GetAsset<GameObject>(assetBundleName, assetName);
        return Instantiate(asset);
    }

    private T InstantiateAsset<T>(string assetBundleName, string assetName) where T : Component
    {
        return InstantiateAsset(assetBundleName, assetName).GetComponent<T>();
    }
}
