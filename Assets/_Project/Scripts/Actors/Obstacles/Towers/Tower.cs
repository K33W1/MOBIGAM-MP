using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TowerMovement))]
public class Tower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float xRotationRange = 10f;
    [SerializeField, Min(0)] private float yRotationRange = 10f;
    [SerializeField, Min(0)] private float zRotationRange = 10f;

    private TowerMovement towerMovement = null;

    private Collider[] colliders = null;

    private void Awake()
    {
        towerMovement = GetComponent<TowerMovement>();
        colliders = GetComponentsInChildren<Collider>();
    }

    private void Update()
    {
        if (transform.position.z <= -15f)
        {
            gameObject.SetActive(false);
        }
    }

    public void Initialize(Vector3 spawnPoint)
    {
        Quaternion rotation = Quaternion.Euler(
            Random.Range(-xRotationRange, xRotationRange),
            Random.Range(-yRotationRange, yRotationRange),
            Random.Range(-zRotationRange, zRotationRange));
        transform.SetPositionAndRotation(spawnPoint, rotation);

        towerMovement.Initialize(Vector3.back);

        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }

    private void OnDisable()
    {
        TowerPooler.Instance.ReturnToPool(this);
    }
}
