using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnemyShooting))]
public class Enemy : MonoBehaviour
{
    public void Initialize(Transform target)
    {
        EnemyShooting enemyShooting = GetComponent<EnemyShooting>();

        enemyShooting.Initialize(target);
    }
}
