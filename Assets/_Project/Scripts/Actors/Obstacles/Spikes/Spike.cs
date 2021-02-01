using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpikeMovement))]
public class Spike : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float xRotationRange = 10f;
    [SerializeField, Min(0)] private float yRotationRange = 10f;
    [SerializeField, Min(0)] private float zRotationRange = 10f;

    private SpikeMovement spikeMovement = null;

    private Collider[] colliders = null;

    private void Awake()
    {
        spikeMovement = GetComponent<SpikeMovement>();
        colliders = GetComponentsInChildren<Collider>();
    }

    private void Update()
    {
        if (transform.position.z <= -15f || transform.position.y <= -30f)
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

        spikeMovement.Initialize(Vector3.back);

        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }

    private void OnDisable()
    {
        SpikePooler.Instance.ReturnToPool(this);
    }
}
