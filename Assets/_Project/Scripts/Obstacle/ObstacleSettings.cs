using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle Settings", menuName = "Obstacle Settings")]
public class ObstacleSettings : ScriptableObject
{
    [SerializeField] private Mesh mesh = null;
    [SerializeField] private Material material = null;
    [SerializeField] private float radius = 1f;

    public Mesh Mesh => mesh;
    public Material Material => material;
    public float Radius => radius;
}
