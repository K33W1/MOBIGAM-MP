using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float x = 1f;
    [SerializeField, Min(0)] private float y = 1f;
    [SerializeField, Min(0)] private float z = 1f;

    public Vector3 GetRandomPointInside()
    {
        Vector3 point = transform.position;
        point.x += Random.Range(-x, x);
        point.y += Random.Range(-y, y);
        point.z += Random.Range(-z, z);
        return point;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(x * 2f, y * 2f, z * 2f));
    }
}
