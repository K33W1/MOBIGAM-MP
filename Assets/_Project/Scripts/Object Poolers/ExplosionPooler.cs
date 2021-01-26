using Kiwi.Core;
using UnityEngine;

[DisallowMultipleComponent]
public class ExplosionPooler : ObjectPooler<Explosion>
{
    protected override void InitializeObject(Explosion obj)
    {
        // Do nothing
    }
}
