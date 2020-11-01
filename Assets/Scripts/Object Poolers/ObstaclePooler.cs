using Kiwi.Common;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstaclePooler : ObjectPooler<Obstacle>
{
    protected override void InitializeObject(Obstacle obj)
    {
        // Do nothing
    }
}
