using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle Config", menuName = "Configs/Obstacle")]
public class ObstacleConfig : ScriptableObject
{
    [SerializeField] private Mesh mesh = null;
    [SerializeField] private Material material = null;
    [SerializeField] private float radius = 1f;

    public Mesh Mesh => mesh;
    public Material Material => material;
    public float Radius => radius;
}
