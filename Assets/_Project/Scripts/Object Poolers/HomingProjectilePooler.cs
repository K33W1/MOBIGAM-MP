using Kiwi.Core;
using UnityEngine;

[DisallowMultipleComponent]
public class HomingProjectilePooler : ObjectPooler<HomingProjectile>
{
    protected override void InitializeObject(HomingProjectile obj)
    {
        // Do nothing
    }
}
