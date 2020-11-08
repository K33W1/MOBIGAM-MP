using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Enemy))]
public class EnemyUpdateColorOnSpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer meshRenderer = null;

    [Header("Materials")]
    [SerializeField] private Material redMaterial = null;
    [SerializeField] private Material greenMaterial = null;
    [SerializeField] private Material blueMaterial = null;

    private Enemy enemy = null;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy.Spawned += OnSpawn;
    }

    private void OnSpawn()
    {
        if (enemy.Element == Element.A)
        {
            meshRenderer.material = redMaterial;
        }
        else if (enemy.Element == Element.B)
        {
            meshRenderer.material = greenMaterial;
        }
        else
        {
            meshRenderer.material = blueMaterial;
        }
    }
}
