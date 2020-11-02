using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyBluePooler : ObjectPooler<Enemy>
{
    [Header("Enemy Dependencies")]
    [SerializeField] private EnemyWaypoints waypoints = null;
    [SerializeField] private Transform player = null;

    protected override void InitializeObject(Enemy enemy)
    {
        enemy.Initialize(waypoints, player);
    }
}