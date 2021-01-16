using Kiwi.Common;
using UnityEngine;

public class EnemyPooler : ObjectPooler<Enemy>
{
    private EnemyWaypoints waypoints = null;
    private Transform player = null;

    public void Initialize(EnemyWaypoints waypoints, Transform player)
    {
        this.waypoints = waypoints;
        this.player = player;
    }

    protected override void InitializeObject(Enemy enemy)
    {
        enemy.Initialize(this, waypoints, player);
    }
}
