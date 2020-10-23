using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnemyShooting))]
public class Enemy : MonoBehaviour
{
    private EnemyShooting shooting = null;

    private void Awake()
    {
        shooting = GetComponent<EnemyShooting>();
    }

    public void Initialize(Transform target)
    {
        shooting.Initialize(target);
    }
}
