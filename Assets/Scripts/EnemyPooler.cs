using Kiwi.Common;
using UnityEngine;

public class EnemyPooler : ObjectPooler<Enemy>
{
    [Header("Enemy Dependencies")]
    [SerializeField] private Transform player = null;

    protected override void InitializeObject(Enemy enemy)
    {
        enemy.Initialize(player);
    }
}