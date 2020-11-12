using Kiwi.Common;
using UnityEngine;

public class EnemyPooler : ObjectPooler<Enemy>
{
    [Header("Enemy Dependencies")]
    [SerializeField] private EnemyWaypoints waypoints = null;
    [SerializeField] private Transform player = null;

    protected override void InitializeObject(Enemy enemy)
    {
        enemy.Initialize(this, waypoints, player);
    }
}
