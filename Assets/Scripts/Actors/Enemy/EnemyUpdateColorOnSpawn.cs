using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Enemy))]
public class EnemyUpdateColorOnSpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Material redMaterial = null;
    [SerializeField] private Material greenMaterial = null;
    [SerializeField] private Material blueMaterial = null;

    private MeshRenderer meshRenderer = null;
    private Enemy enemy = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        enemy = GetComponent<Enemy>();
        enemy.Spawned += OnSpawn;
    }

    private void OnSpawn()
    {
        if (enemy.Element == Element.Red)
        {
            meshRenderer.material = redMaterial;
        }
        else if (enemy.Element == Element.Green)
        {
            meshRenderer.material = greenMaterial;
        }
        else
        {
            meshRenderer.material = blueMaterial;
        }
    }
}
