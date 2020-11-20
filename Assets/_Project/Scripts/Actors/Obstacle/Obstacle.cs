using TreeEditor;
using UnityEditor;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ObstacleMovement))]
public class Obstacle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshFilter meshFilter = null;
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private new SphereCollider collider = null;

    private ObstacleMovement movement = null;
    private ObstacleSettings settings = null;

    private void Awake()
    {
        movement = GetComponent<ObstacleMovement>();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            if (settings != null)
            {
                UpdateSettings();;
            }
        }
    }
#endif

    public void Spawn(ObstacleSettings settings, Vector3 direction)
    {
        this.settings = settings;
        UpdateSettings();
        movement.Launch(direction);
    }

    private void UpdateSettings()
    {
        meshFilter.mesh = settings.Mesh;
        meshRenderer.material = settings.Material;
        collider.radius = settings.Radius;
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
