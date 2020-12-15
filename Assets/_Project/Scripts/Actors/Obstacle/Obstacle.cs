using UnityEditor;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ObstacleMovement))]
public class Obstacle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshFilter meshFilter = null;
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private SphereCollider sphereCollider = null;

    private ObstacleMovement movement = null;
    private ObstacleConfig config = null;

    private void Awake()
    {
        movement = GetComponent<ObstacleMovement>();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            if (config != null)
            {
                UpdateSettings();;
            }
        }
    }
#endif

    public void Spawn(ObstacleConfig config, Vector3 direction)
    {
        this.config = config;
        UpdateSettings();
        movement.Launch(direction);
    }

    private void UpdateSettings()
    {
        meshFilter.mesh = config.Mesh;
        meshRenderer.material = config.Material;
        sphereCollider.radius = config.Radius;
    }

    private void OnCollisionEnter(Collision _)
    {
        Debris debris = DebrisPooler.Instance.GetPooledObject();
        debris.transform.position = transform.position;
    }

    private void OnDisable()
    {
        ObstaclePooler.Instance.ReturnToPool(this);
    }
}
